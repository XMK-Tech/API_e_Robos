using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilleApi.Domain.Services.Commom;

public class PersonImportServices : SessionServices, IPersonImportServices
{
    private readonly IPhysicalPersonRepository _physicalPersonRepository;
    private readonly IJuridicalPersonRepository _juridicalPersonRepository;
    private readonly IPersonRepository _personRepository;
    
    private readonly IPersonServices _personServices;

    private readonly JuridicalPersonServices _juridicalPersonServices;
    private readonly PhysicalPersonServices _physicalPersonServices;
    private readonly AttachmentServices _attachmentServices;
    private readonly NotificationServices _notificationServices;
    private readonly IProprietySecondaryServices _proprietySecondaryServices;

    private readonly PersonParser _personParser;

    public PersonImportServices(
        JuridicalPersonServices juridicalPersonServices, PhysicalPersonServices physicalPersonServices, AttachmentServices attachmentServices,
        PersonParser personParser, IHttpContextAccessor httpContextAccessor, NotificationServices notificationServices,
        IPhysicalPersonRepository physicalPersonRepository, IJuridicalPersonRepository juridicalPersonRepository, IProprietySecondaryServices proprietySecondaryServices, IPersonRepository personRepository, IPersonServices personServices)
        : base(httpContextAccessor)
    {
        _juridicalPersonServices = juridicalPersonServices;
        _physicalPersonServices = physicalPersonServices;
        _attachmentServices = attachmentServices;
        _notificationServices = notificationServices;
        _proprietySecondaryServices = proprietySecondaryServices;

        _personParser = personParser;
        _physicalPersonRepository = physicalPersonRepository;
        _juridicalPersonRepository = juridicalPersonRepository;
        _personRepository = personRepository;
        _personServices = personServices;
    }

    public CsvResponseViewModel InsertCSV(CsvInsertViewModel fileBody)
    {
        ValidateAttachment(fileBody.AttachmentId);

        var persons = _personParser.Parse(fileBody.AttachmentId);
        var proprieties = SetupProprieties(persons);
        var secondaryPersons = SecondaryData(persons);
        var toPatch = PersonsToPatch(persons);

        var addressToDelete = new List<AddressPerson>();

        var itens = new List<ItemCsvError>();
        var fails = new List<string>();

        var juridicalPersons = new List<JuridicalPersonBase>();
        var physicalPersons = new List<PhysicalPersonBase>();

        persons.ForEach(p =>
        {
            try
            {
                if (toPatch.ContainsKey(p.Item1.Document))
                    // Directly updates the PersonBase entity
                    UpdateExistingPerson(proprieties, toPatch, addressToDelete, p.Item1); 
                else if (p.Item1 is JuridicalPersonInsertUpdateViewModel juridicalModel)
                    // Enter data through the entity JuridicalPersonBase
                    InsertJuridicalPerson(proprieties, secondaryPersons, juridicalPersons, juridicalModel); 
                else if (p.Item1 is PhysicalPersonInsertUpdateViewModel physicalModel)
                    // Enter data through the entity PhysicalPersonBase
                    InsertPhysicalPerson(proprieties, secondaryPersons, physicalPersons, physicalModel);
                else
                    throw new BadRequestException("Erro na identificação do tipo(juridico ou fisico) da pessoa.");
            }
            catch (DomainException e)
            {
                fails.Add(p.Item2);
                itens.Add(new(itens.Count + 1, e.ValidationMessages));
            }
        });

        if (physicalPersons.Any())
            _physicalPersonRepository.InsertMany(physicalPersons);

        if (juridicalPersons.Any())
            _juridicalPersonRepository.InsertMany(juridicalPersons);

        _personServices.DeleteManyAddresses(addressToDelete);

        var personsToUpdate = toPatch.Select(e => e.Value).ToList();
        if (toPatch.Any())
            _personRepository.UpdateMany(personsToUpdate);

        var url = GetErrosFileUrl(fails);
        var response = new CsvResponseViewModel(url, itens);
        PostNotification(response.ConvertToJson());

        return response;
    }

    private void InsertPhysicalPerson(Dictionary<string, Guid> proprieties, Dictionary<string, Guid> secondaryPersons, List<PhysicalPersonBase> physicalPersons, PhysicalPersonInsertUpdateViewModel physicalModel)
    {
        var entity = physicalPersons.Where(e => e?.Person?.Document == physicalModel.Document).FirstOrDefault();

        if (entity == null)
        {
            physicalModel.InventoryPersonId = GetSecondaryPersonId(secondaryPersons, physicalModel.InventoryPersonDocument);
            physicalModel.LegalRepresentativeId = GetSecondaryPersonId(secondaryPersons, physicalModel.LegalRepresentativeDocument);

            entity = _physicalPersonServices.Create(physicalModel);
            physicalPersons.Add(entity);
        }

        SetProprieties(entity.Person, proprieties, physicalModel.ProprietyCib);
    }

    private void InsertJuridicalPerson(Dictionary<string, Guid> proprieties, Dictionary<string, Guid> secondaryPersons, List<JuridicalPersonBase> juridicalPersons, JuridicalPersonInsertUpdateViewModel juridicalModel)
    {
        var entity = juridicalPersons.Where(e => e.Person.Document == juridicalModel.Document).FirstOrDefault();

        if (entity == null)
        {
            juridicalModel.InventoryPersonId = GetSecondaryPersonId(secondaryPersons, juridicalModel.InventoryPersonDocument);
            juridicalModel.LegalRepresentativeId = GetSecondaryPersonId(secondaryPersons, juridicalModel.LegalRepresentativeDocument);

            entity = _juridicalPersonServices.Create(juridicalModel);
            juridicalPersons.Add(entity);
        }

        SetProprieties(entity.Person, proprieties, juridicalModel.ProprietyCib);
    }

    private void UpdateExistingPerson(Dictionary<string, Guid> proprieties, Dictionary<string, PersonBase> toPatch, List<AddressPerson> addressToDelete, PersonViewModelBase personModel)
    {
        var entity = toPatch[personModel.Document];

        var address = _personServices.Update(entity, personModel).Item2;
        addressToDelete.AddRange(address);

        SetProprieties(entity, proprieties, personModel.ProprietyCib);
    }

    private string GetErrosFileUrl(List<string> fails)
    {
        AttachmentViewModel file = null;
        if (fails.Any())
        {
            var bytes = Encoding.Unicode.GetBytes(string.Join("\n", fails));
            file = _attachmentServices.InsertByBytes(bytes, "person-import-erros.csv", "text/csv", "Persons", "");
        }

        return file.Url ?? "";
    }

    private void PostNotification(string body)
    {
        _notificationServices.InsertMany(new NotificationInsertViewModel()
        {
            UserIds = new List<Guid>() { GetCurrentSession().UserId },
            Title = "Importação de proprietários realizada com sucesso",
            Message = "Clique para verificar",
            Link = "",
            Body = body,
            Priority = NotificationPriority.Normal,
        });
    }
    
    private Dictionary<string, PersonBase> PersonsToPatch(List<(PersonViewModelBase, string)> persons)
    {
        var documents = persons.Select(e => e.Item1.Document).Distinct().ToList();
        return PersonsToPatch(documents);
    }
    
    private Dictionary<string, PersonBase> PersonsToPatch(List<string> documents)
    {
        var persons = _personRepository.Query().Include(e => e.Addresses).ThenInclude(e => e.Address).Where(p => documents.Contains(p.Document)).ToList();
        return persons.ToDictionary(p => p.Document, p => p);
    }

    private Dictionary<string, Guid> SecondaryData(List<(PersonViewModelBase, string)> persons)
    {
        var secondary = new Dictionary<string, string>();
        persons.ForEach(p =>
        {
            AddPersonIfNeeded(secondary, p.Item1?.InventoryPersonDocument, p.Item1?.InventoryPersonName);
            AddPersonIfNeeded(secondary, p.Item1?.LegalRepresentativeDocument, p.Item1?.LegalRepresentativeName);
        });

        return SecondaryPersonSetup(secondary);
    }

    private static void AddPersonIfNeeded(Dictionary<string, string> secondary, string document, string name)
    {
        if (!string.IsNullOrEmpty(document) && !string.IsNullOrEmpty(name) &&  !secondary.ContainsKey(document))
            secondary.Add(document, name);
    }

    private Dictionary<string, Guid> SecondaryPersonSetup(Dictionary<string, string> data)
    {
        var documents = data.Keys.ToList();
        var persons = _personRepository
                        .Query()
                        .Where(e => documents.Contains(e.Document))
                        .ToList();

        var dict = new Dictionary<string, Guid>();
        var toUpdate = new List<PersonBase>();
        var toInsert = new List<PersonBase>();

        foreach(var item in data)
        {
            var doc = item.Key;
            var name = item.Value;

            var person = persons.Where(e => e.Document == doc).FirstOrDefault();
            if (person == null)
            {
                person = new() { Document = doc, Name = name };
                toInsert.Add(person);
            }
            else
            {
                person.Document = doc;
                person.Name = name;

                toUpdate.Add(person);
            }

            dict.Add(person.Document, person.Id);
        }

        if (toUpdate.Any())
            _personRepository.UpdateMany(toUpdate);

        if (toInsert.Any())
            _personRepository.InsertMany(toInsert);

        return dict;

    }

    private static Guid? GetSecondaryPersonId(Dictionary<string, Guid> personData, string document)
    {
        return (personData.ContainsKey(document)) ? personData[document] : null;
    }

    private Dictionary<string, Guid> SetupProprieties(List<(PersonViewModelBase, string)> persons)
    {
        var cibs = persons.Select(e => e.Item1.ProprietyCib).Distinct().ToList();
        return _proprietySecondaryServices.GetProprietyIds(cibs);        
    }
    
    private static void SetProprieties(PersonBase person, Dictionary<string, Guid> proprieties, string cib)
    {
        try
        {
            var ownering = new ProprietyOwners(proprieties[cib], person.Id);

            if (person.Proprieties == null)
                person.Proprieties = new List<ProprietyOwners>();

            person.Proprieties.Add(ownering);
        }
        catch
        {
            throw new BadRequestException($"Propriedade(Cib: {cib} não encontrada. O Usuário(Documento: {person?.Document}) foi criado mas não possui relação com a propriedade suscitada.");
        }
    }

    private void ValidateAttachment(Guid id)
    {
        var isValidAttachment = _attachmentServices.Exists(id);
        if (!isValidAttachment)
            throw new NotFoundException("Attachment not found.");
    }
}