using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class JuridicalPersonServices : Notifications, IJuridicalPersonServices
{
    private readonly IJuridicalPersonRepository _repository;
    private readonly IPersonServices _personServices;
    private readonly ServiceTypeServices _serviceTypeServices;

    public static readonly string Discriminator = "JuridicalPerson";

    public JuridicalPersonServices(
        IJuridicalPersonRepository repository,
        ServiceTypeServices serviceTypeServices, 
        IPersonServices personServices)
    {
        _repository = repository;
        _serviceTypeServices = serviceTypeServices;
        _personServices = personServices;
    }

    private IQueryable<JuridicalPersonBase> Filter(JuridicalPersonParams model, Metadata metadata)
    {
        IQueryable<JuridicalPersonBase> query = Query().Include(x => x.Person).ThenInclude(e => e.EmailPersons).ThenInclude(e => e.Email)
                                               .Include(x => x.Person).ThenInclude(x => x.SocialMedias)
                                               .Include(x => x.Person).ThenInclude(x => x.Phones).AsQueryable();

        Expression<Func<JuridicalPersonBase, Object>> filter = x => x.Person.Name;
        if (String.IsNullOrEmpty(metadata.SortColumn))
        {
            filter = e => e.Person.CreatedAt;
            metadata.SortColumn = "createdAt";
        }
        else if (metadata.SortColumn.ToLower() == "document")
            filter = e => e.Person.Document;
        else if (metadata.SortColumn.ToLower() == "displayname")
            filter = e => e.Person.DisplayName;
        else if (metadata.SortColumn.ToLower() == "profilepicurl")
            filter = e => e.Person.ProfilePicUrl;
        else if (metadata.SortColumn.ToLower() == "initialdate")
            filter = e => e.Person.Date;
        else if (metadata.SortColumn.ToLower() == "enddate")
            filter = e => e.Person.Date;
        else if (metadata.SortColumn.ToLower() == "name")
            filter = e => e.Person.Name;

        if (metadata.SortDirection.ToLower() == "asc")
            query = query.OrderBy(filter);
        else
            query = query.OrderByDescending(filter);

        if (!String.IsNullOrEmpty(model.DisplayName))
            query = query.Where(e => e.Person.DisplayName.Contains(model.DisplayName));

        if (!String.IsNullOrEmpty(model.Name))
            query = query.Where(e => e.Person.Name.Contains(model.Name));

        if (model.Id != Guid.Empty)
            query = query.Where(e => e.Id == model.Id);

        if (model.PersonId != Guid.Empty)
            query = query.Where(e => e.PersonId == model.PersonId);

        if (model.IsCardOperator != null)
        {
            if ((bool)model.IsCardOperator)
                query = query.Where(e => e.IsCardOperator);
            else
                query = query.Where(e => !e.IsCardOperator);
        }

        if (metadata.QuickSearch != null)
            query = query.Where(
                e =>
                e.Person.DisplayName.Contains(metadata.QuickSearch) ||
                e.Person.Name.Contains(metadata.QuickSearch) ||
                e.Person.Document.Contains(metadata.QuickSearch));

        if (!string.IsNullOrEmpty(model.Document))
            query = query.Where(e => e.Person.Document.Contains(model.Document));

        if (!string.IsNullOrEmpty(model.Name))
            query = query.Where(e => e.Person.Name.Contains(model.Name));

        if (!string.IsNullOrEmpty(model.DisplayName))
            query = query.Where(e => e.Person.DisplayName.Contains(model.DisplayName));

        return query;
    }
    
    private IQueryable<JuridicalPersonBase> Query()
    {
        return _repository.Query().Where(e => e.Person.Status == true && e.Discriminator.Equals(Discriminator));
    }

    public List<JuridicalPersonListViewModel> List(JuridicalPersonParams model, Metadata metadata)
    {
        var query = Filter(model, metadata).Include(j => j.Person).ThenInclude(p => p.EmailPersons);
        var entities = _repository.ExecuteQuery(query, metadata);

        ThrowIfNull(entities, "Entities");

        return ConvertToViewModel(entities);
    }

    public JuridicalPersonViewModel View(Guid id)
    {
        JuridicalPersonBase juridicalPerson = Get(id);
        ThrowIfNull(juridicalPerson, Discriminator);

        return ConvertToViewModel(juridicalPerson);
    }

    public JuridicalPersonBase GetByDocument(string document)
    {
        return _repository.Query()
                .Include(e => e.Person)
                .Include(e => e.Person.EmailPersons)
                .ThenInclude(e => e.Email)
                .Include(e => e.Person.Phones)
                .Include(e => e.Person.Addresses)
                .ThenInclude(e => e.Address)
                .ThenInclude(e => e.City)
                .ThenInclude(e => e.State)
                .ThenInclude(e => e.Country)
                .Where(e => e.Person.Document.Replace("-", "").Replace(".", "").Replace("/", "") == document.Replace("-", "").Replace(".", "").Replace("/", ""))
                .FirstOrDefault();
    }

    private JuridicalPersonBase Get(Guid id)
    {
        return _repository
                .Query()
                .Where(e => e.Person.Status == true && e.Discriminator.Equals(Discriminator))
                .Include(x => x.Person)
                .ThenInclude(e => e.EmailPersons)
                .ThenInclude(e => e.Email)
                .Include(x => x.Person)
                .ThenInclude(x => x.SocialMedias)
                .Include(x => x.Person)
                .ThenInclude(x => x.Phones)
                .Include(e => e.Person.Addresses)
                .ThenInclude(e => e.Address)
                .ThenInclude(e => e.City)
                .ThenInclude(e => e.State)
                .Include(e => e.Person)
                .ThenInclude(e => e.InventoryPerson)
                .Include(e => e.Person)
                .ThenInclude(e => e.LegalRepresentative)
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    public IEnumerable<JuridicalPersonViewModel> GetCardOperators()
    {
        return _repository
                .Query()
                .Include(e => e.Person)
                .Where(e => e.IsCardOperator)
                .ToList()
                .Select(ConvertToViewModel);
    }

    public void Insert(JuridicalPersonInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var juridicalPerson = ConvertToEntity(model);
        _repository.Insert(juridicalPerson);

        if (model.ServiceTypesDescriptionIds.Any())
            _serviceTypeServices.InsertRelations(juridicalPerson.Id, model.ServiceTypesDescriptionIds);
    }

    public JuridicalPersonBase Create(JuridicalPersonInsertUpdateViewModel model)
    {
        ValidateModel(model);
        return ConvertToEntity(model, isFromImport:true);
    }

    public void Update(JuridicalPersonInsertUpdateViewModel model, Guid id)
    {
        var juridicalPerson = _repository.Query().Where(e => e.Id == id).Include(e => e.Person).FirstOrDefault();
        ThrowIfNull(juridicalPerson, Discriminator);

        var person = juridicalPerson?.Person;
        ValidateModel(model, person?.Document, person?.CibNumber, person?.GeneralRecord);

        juridicalPerson = ConvertToEntity(model, juridicalPerson);
        _repository.Update(juridicalPerson);

        _serviceTypeServices.DeleteRelations(juridicalPerson.Id);
        if (model.ServiceTypesDescriptionIds.Any())
            _serviceTypeServices.InsertRelations(juridicalPerson.Id, model.ServiceTypesDescriptionIds);
    }
    
    public void Delete(Guid id)
    {
        var juridicalPerson = _repository.Query().Where(e => e.Id == id && e.Person.Status == true && e.Discriminator.Equals(Discriminator)).FirstOrDefault();
        ThrowIfNull(juridicalPerson, Discriminator);

        _personServices.Delete(juridicalPerson.PersonId);
        
        juridicalPerson.Deleted = true;
        _repository.Update(juridicalPerson);
    }
    
    public List<JuridicalPersonListViewModel> ConvertToViewModel(List<JuridicalPersonBase> models)
    {
        var result = new List<JuridicalPersonListViewModel>();
        if (models == null)
            return result;

        models.ForEach(entity => 
        {
            var mdl = View(entity.Id);
            var viewModel = new JuridicalPersonListViewModel(entity.Id,
                                                        entity.PersonId,
                                                        entity.Person.DisplayName,
                                                        entity.Person.Name,
                                                        mdl.Phones,
                                                        mdl.Emails,
                                                        entity.Person.Document,
                                                        entity.Person.ProfilePicUrl,
                                                        _personServices.ViewFirstEmail(entity.PersonId),
                                                        entity.MunicipalRegistration,
                                                        entity.IsCardOperator,
                                                        entity.CardRate);
            
            result.Add(viewModel);
        });
        
        return result;
    }

    public JuridicalPersonViewModel ConvertToViewModel(JuridicalPersonBase model)
    {
        if (model == null) 
            return null;

        var viewModel = new JuridicalPersonViewModel(model.Id,
                                        model.Person.Document,
                                        model.Person.Name,
                                        model.Person.DisplayName,
                                        model.Person.Date,
                                        model.PersonId,
                                        "",
                                        model.MunicipalRegistration,
                                        AddressServices.ConvertToViewModel(model.Person?.Addresses?.Select(e => e.Address)?.ToList()),
                                        _personServices.ViewEmails(model.PersonId),
                                        PhoneServices.ConvertToViewModel(model.Person?.Phones),
                                        SocialMediaServices.ConvertToViewModel(model.Person?.SocialMedias),
                                        model.IsCardOperator,
                                        model.CardRate)
        {
            ServiceTypes = _serviceTypeServices.GetRelations(model.Id),

            StartDate = model.Person.StartDate,
            EndDate = model.Person.EndDate,
            CibNumber = model.Person.CibNumber,
            ImmunityYears = model.Person.ImmunityYears,

            LegalRepresentative = model.Person?.LegalRepresentative?.Name,
            LegalRepresentativeId = model.Person?.LegalRepresentativeId,
            LegalRepresentativeDocument = model.Person?.LegalRepresentative?.Document,
            LegalRepresentativeObs = model.Person?.LegalRepresentativeObs,
            
            InventoryPerson = model.Person?.InventoryPerson?.Name,
            InventoryPersonId = model.Person?.InventoryPersonId,
            InventoryPersonDocument = model.Person?.InventoryPerson?.Document,
            InventoryObs = model.Person?.InventoryObs,

            SocialName = model.Person.SocialName,
            CreatedAt = model.CreatedAt,
        };

        return viewModel;
    }
    
    private JuridicalPersonBase ConvertToEntity(JuridicalPersonInsertUpdateViewModel viewModel, JuridicalPersonBase model = null, bool isFromImport = false)
    {
        if (viewModel == null) 
            return null;

        if (model == null)
        {
            var entityPerson = new JuridicalPersonBase(Discriminator, viewModel.MunicipalRegistration, viewModel.IsCardOperator, viewModel.CardRate);

            if (!isFromImport)
            {
                var personId = _personServices.Insert(viewModel, PersonType.Juridical, entityPerson.Id.ToString(), Discriminator).Id;
                entityPerson.PersonId = personId;
            }
            else
            {
                entityPerson.Person = _personServices.Create(viewModel, PersonType.Juridical, entityPerson.Id.ToString(), Discriminator);
            }
            
            return entityPerson;
        }
        else
        {
            _personServices.Update(model.Person, viewModel, model.Id.ToString(), Discriminator);
            model.Update(Discriminator, viewModel.MunicipalRegistration, viewModel.IsCardOperator, viewModel.CardRate);

            return model;
        }
    }
    
    public Dictionary<string, bool> DocumentsExists(IEnumerable<string> documents)
    {
        var sanitazedDocuments = documents.Distinct().ToList().Select(e => e.SanitazeDocument()).ToList();
        var existentDocuments = Query()
                                .Select(e => e.Person.Document.Replace("/", "").Replace(".", "").Replace("-", ""))
                                .Where(e => sanitazedDocuments.Contains(e))
                                .Distinct()
                                .ToList();

        return documents.Distinct().ToDictionary(e => e, e => existentDocuments.Contains(e));
    }

    public Dictionary<string, Guid?> GetIdsByDocument(IEnumerable<string> documents)
    {
        var sanitazedDocuments = documents.Distinct().ToList().Select(e => e.SanitazeDocument()).ToList();
        var juridicalPersons = Query()
                                .Select(e => new { e.Person.Document, e.Id })
                                .Where(e => sanitazedDocuments.Contains(e.Document.Replace("/", "").Replace(".", "").Replace("-", "")))
                                .ToList()
                                .DistinctBy(e => e.Document);

       return documents
                    .Distinct()
                    .ToDictionary(e => e, e => juridicalPersons.FirstOrDefault(x => x.Document.Replace("/", "").Replace(".", "").Replace("-", "") == e)?.Id);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if(entity == null)
            throw new NotFoundException($"{message} not found.");
    }

    private void ValidateModel(JuridicalPersonInsertUpdateViewModel model, string document = "", string cib = "", string generalRecord = "")
    {
        var messages = new List<string>();

        if (model.CardRate < 0 || model.CardRate > 100 && model.IsCardOperator)
            messages.Add("CardRate inválido. Intervalo correto: 0 a 100.");

        if (string.IsNullOrEmpty(model.Name))
            messages.Add("Nome é um campo obrigatório.");

        try
        {
            _personServices.ValidateModel(model, document, cib, generalRecord);
        }
        catch (DomainException ex)
        {
            messages.AddRange(ex.ValidationMessages);
        }

        if (messages.Any())
            throw new BadRequestException(messages);
    }
}