using System;
using System.Collections.Generic;
using System.Linq;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using AgilleApi.Domain.ViewModel;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Services;
using System.Linq.Expressions;
using System.Text;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Extensions;
using Microsoft.AspNetCore.Http;

namespace AgilleApi.Domain.Services.Commom;

public class ProprietyServices : SessionServices, IProprietyServices
{
    private readonly IProprietyRepository _repository;
    private readonly IProprietyContactRepository _contactRepository;
    private readonly IProprietyCharacteristicsRepository _characteristicsRepository;
    private readonly IProprietyAddressRepository _proprietyAddressRepository;
    private readonly IProprietyOwnerRepository _proprietyOwnerRepository;
    private readonly IProprietyAttachmentRepository _proprietyAttachmentRepository;
    private readonly ICoordenateRepository _coordenateRepository;
    private readonly IAddressRepository _addressRepository;

    private readonly IPersonServices _personServices;
    private readonly AddressServices _addressServices;
    private readonly AttachmentServices _attachmentServices;
    private readonly IEntitiesServices _entitiesServices;
    private readonly NotificationServices _notificationServices;

    private readonly ProprietyParser _proprietyParser;

    public ProprietyServices(
        IProprietyRepository repository, IProprietyContactRepository contactRepository,
        IProprietyCharacteristicsRepository characteristicsRepository, IProprietyAddressRepository proprietyAddressRepository,
        IAddressRepository addressRepository, IProprietyOwnerRepository proprietyOwnerRepository, IPersonServices personServices,
        IEntitiesServices entitiesServices, ICoordenateRepository coordenateRepository,
        AddressServices addressServices, AttachmentServices attachmentServices, ProprietyParser proprietyParser, IProprietyAttachmentRepository proprietyAttachmentRepository, 
        NotificationServices notificationServices, IHttpContextAccessor httpContextAccessor)
        : base(httpContextAccessor)
    {
        _repository = repository;
        _contactRepository = contactRepository;
        _characteristicsRepository = characteristicsRepository;
        _proprietyAddressRepository = proprietyAddressRepository;
        _addressRepository = addressRepository;
        _proprietyOwnerRepository = proprietyOwnerRepository;
        _proprietyAttachmentRepository = proprietyAttachmentRepository;
        _coordenateRepository = coordenateRepository;

        _personServices = personServices;
        _entitiesServices = entitiesServices;
        _addressServices = addressServices;
        _attachmentServices = attachmentServices;
        _proprietyParser = proprietyParser;
        _notificationServices = notificationServices;
    }

    public IEnumerable<ShortProprietyViewModel> Select()
    {
        return _repository
                .Query()
                 .Select(e => new ShortProprietyViewModel(e.Id, e.CibNumber, e.Name));
    }

    public IEnumerable<SelectPersonViewModel> SelectProprietaries(Guid proprietyId)
    {
        return _repository
            .Query()
            .Where(e => e.Id == proprietyId)
            .SelectMany(p => p.Owners)
            .Select(o => new List<PersonBase>(){ o.Owner, o.Owner.LegalRepresentative, o.Owner.InventoryPerson})
            .ToList()
            .SelectMany(item => item)
            .Where(o => o != null)
            .DistinctBy(e => e.Id)
            .Select(e => new SelectPersonViewModel
            {
                Id = e.Id,
                DisplayName = e.DisplayName,
                Name = e.Name,
                Document = e.Document,
                Cib = e.CibNumber
            })
            .ToList();
    }

    public IEnumerable<ProprietyViewModel> View(Metadata meta, ProprietyParams @params = null)
    {
        var query = Filter(GetAll(), meta, @params);
        return _repository
                .ExecuteQuery(query, meta)
                .Select(ConvertToViewModel)
                .ToList();
    }

    public ProprietyViewModel View(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, "Propriety");

        return ConvertToViewModel(entity);
    }

    public ProprietyDashboardViewModel Dashboard()
    {
        var query = _repository
                        .Query()
                        .Include(o => o.Owners)
                        .ThenInclude(p => p.Owner)
                        .ThenInclude(a => a.Addresses)
                        .ThenInclude(a => a.Address)
                        .Include(a => a.Address)
                        .ThenInclude(a => a.Address)
                        .ToList();
        
        var proprieties = query
                        .Select(CreateDashboardItem)
                        .ToList();

        var entity = _entitiesServices.View();
        return new(entity?.Name, proprieties);
    }

    public IEnumerable<TaxPayerDeclarationDashBoardViewModel> ViewCARData()
    {
        return _repository
                .Query()
                .Include(e => e.Declarations)
                .ThenInclude(e => e.Person)
                .Where(e => !string.IsNullOrEmpty(e.CARNumber))
                .Select(p => new TaxPayerDeclarationDashBoardViewModel(p.Id, p.CARNumber, p.CibNumber, p.Owners.FirstOrDefault().Owner.Name, p.Name, 
                ConvertDashboardItemToViewModel(p.Declarations.OrderByDescending(e => e.Year).FirstOrDefault(), p.Owners.FirstOrDefault().Owner.Name, p.Name)));    
    }

    private static TaxPayerDeclarationDashboardItemViewModel ConvertDashboardItemToViewModel(TaxPayerDeclaration entity, string owner, string name)
    {
        if (entity == null)
            return null;

        var ownerName = entity?.Person?.Name ?? owner;
        return new(entity, ownerName, name);
    }

    public ProprietyCARDataViewModel ViewCARData(string car)
    {
        return _repository
                .Query()
                .Where(e => e.CARNumber.Contains(car))
                .Select(p => new ProprietyCARDataViewModel(p.Id, p.CARNumber, p.CibNumber, p.Owners.FirstOrDefault().Owner.Name, p.Name))
                .FirstOrDefault();
    }

    public ProprietyViewModel Insert(ProprietyInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var entity = ConvertToEntity(model);

        UpdateProprietyContact(entity, model.Contact);
        UpdateProprietyCharacteristics(entity, model.Characteristics);
        UpdateProprietyAddress(entity, model.Address);

        _repository.Insert(entity);

        SetProprietyOwners(entity, model.OwnersDocument);
        SetProprietyAttachments(entity, model.Attachments);
        InsertCoordenates(entity.Id, model.Coordenates);
        
        return ConvertToViewModel(entity);
    }

    private Propriety BuildEntity(ProprietyInsertUpdateViewModel model, Propriety entity = null)
    {
        ValidateModel(model, false, isFileImport: true);

        entity = ConvertToEntity(model, entity);
        UpdateProprietyAddress(entity, model.Address, isFromImport: true);

        return entity;
    }

    public CsvResponseViewModel InsertCSV(CsvInsertViewModel fileBody)
    {
        var isValidAttachment = _attachmentServices.Exists(fileBody.AttachmentId);
        if (!isValidAttachment)
            throw new NotFoundException("Attachment not found.");

        var itens = new List<ItemCsvError>();
        var proprieties = _proprietyParser.Parse(fileBody.AttachmentId);
        var toPatch = ExistingProprieties(proprieties);

        var fails = new List<string>();
        var toInsert = new List<Propriety>();

        var addressesToUpdate = new List<ProprietyAddress>();

        proprieties.ForEach(p =>
        {
            try
            {
                var model = p.Item1;
                if (toPatch.ContainsKey(model.CibNumber))
                {
                    // Update propriety
                    var entity = toPatch[model.CibNumber];

                    addressesToUpdate.Add(entity.Address);
                    BuildEntity(model, entity);
                }
                else
                    // Create propriety
                    toInsert.Add(BuildEntity(model));
            }
            catch (DomainException e)
            {
                fails.Add(p.Item2);
                itens.Add(new((itens.Count + 1), e.ValidationMessages));
            }
        });

        if (toInsert.Any())
            _repository.InsertMany(toInsert);

        UpdateAddresses(addressesToUpdate);

        var props = toPatch.Select(e => e.Value).ToList();
        if (toPatch.Any())
            _repository.UpdateMany(props);

        AttachmentViewModel file = null;
        if (fails.Any())
        {
            var bytes = Encoding.Unicode.GetBytes(string.Join("\n", fails));
            file = _attachmentServices.InsertByBytes(bytes, "propriety-import-erros.csv", "text/csv", "Proprieties", "");
        }

        var response = new CsvResponseViewModel(file?.Url, itens);

        _notificationServices.InsertMany(new NotificationInsertViewModel()
        {
            UserIds = new List<Guid>() { GetCurrentSession().UserId },
            Title = "Importação de propriedades realizada com sucesso",
            Message = "Clique para verificar",
            Link = "",
            Body = response.ConvertToJson(),
            Priority = NotificationPriority.Normal,
        });

        return response;
    }

    private void UpdateAddresses(List<ProprietyAddress> toUpdate)
    {
        var addresses = toUpdate.Select(e => e.Address).ToList();

        if (toUpdate.Any())
            _proprietyAddressRepository.UpdateMany(toUpdate);

        if (addresses.Any())
            _addressRepository.UpdateMany(addresses);
    }

    private Dictionary<string, Propriety> ExistingProprieties(List<(ProprietyInsertUpdateViewModel, string)> itens)
    {
        var cibs = itens.Select(i => i.Item1).Select(i => i.CibNumber).Distinct().ToList();
        var existing = _repository.Query().Include(e => e.Address).ThenInclude(e => e.Address).Where(p => cibs.Contains(p.CibNumber)).ToList();
        return existing.ToDictionary(p => p.CibNumber, p => p);
    }

    public ProprietyViewModel Update(ProprietyInsertUpdateViewModel model, Guid id)
    {
        ValidateModel(model, false);

        var entity = Get(id);
        ThrowIfNull(entity, "Propriety");

        UpdateProprietyContact(entity, model.Contact);
        UpdateProprietyCharacteristics(entity, model.Characteristics);
        UpdateProprietyAddress(entity, model.Address);

        SetProprietyData(entity, model);
        SetProprietyOwners(entity, model.OwnersDocument);
        SetProprietyAttachments(entity, model.Attachments);

        DeleteCoordenates(entity.Id);
        InsertCoordenates(entity.Id, model.Coordenates);

        _repository.Update(entity);

        return ConvertToViewModel(Get(id));
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, "Propriety");

        var owners = entity.Owners.ToList();
        if(owners.Any())
            _proprietyOwnerRepository.DeleteMany(owners);

        var coordenates = entity.Coordenates.ToList();
        if (coordenates.Any())
            _coordenateRepository.DeleteMany(coordenates);

        _repository.Delete(entity);

        var contact = entity.Contact;
        var characteristics = entity.Characteristics;
        var address = entity.Address;
        var baseAddress = address.Address;

        _contactRepository.Delete(contact);
        _characteristicsRepository.Delete(characteristics);

        _proprietyAddressRepository.Delete(address);
        _addressRepository.Delete(baseAddress);
    }

    public void AddOwner(string personDocument, string proprietyCib)
    {
        var propriety = Get(proprietyCib);
        ThrowIfNull(propriety, $"Propriety(cib:{proprietyCib})");

        var person = _proprietyOwnerRepository
                        .Query()
                        .Include(e => e.Owner)
                        .Where(e => e.Owner.Document == personDocument)
                        .FirstOrDefault();
        if (person != null)
            throw new BadRequestException("Pessoa já é proprietária desse imóvel.");

        var personId = _personServices.GetIdsByDocuments(new List<string>(){ personDocument })?.FirstOrDefault();
        ThrowIfNull(personId, $"Person(Document:{personDocument})");

        var entity = new ProprietyOwners(propriety.Id, personId.Value);
        _proprietyOwnerRepository.Insert(entity);
    }

    public bool Exists(Guid id)
    {
        return _repository.Query().Where(e => e.Id == id).Any();
    }

    private void SetProprietyOwners(Propriety entity, List<string> documents)
    {
        var allOwners = _proprietyOwnerRepository
                            .Query()
                            .Where(e => e.ProprietyId == entity.Id)
                            .ToList();

        var personIds = _personServices.GetIdsByDocuments(documents).ToList();
        var toInsert = new List<ProprietyOwners>();

        personIds.ForEach(id => {
            if (!allOwners.Where(e => e.OwnerId == id).Any())
                toInsert.Add(new ProprietyOwners(entity.Id, id));
        });

        if (toInsert.Any())
            _proprietyOwnerRepository.InsertMany(toInsert);

        var toDelete = allOwners.Where(e => !personIds.Contains(e.OwnerId)).ToList();
        if (toDelete.Any())
            _proprietyOwnerRepository.DeleteMany(toDelete);
    }

    private void SetProprietyAttachments(Propriety entity, List<Guid> ids)
    {
        if (ids == null)
            ids = new();

        var allAttachments = _proprietyAttachmentRepository
                            .Query()
                            .Where(e => e.ProprietyId == entity.Id)
                            .ToList();

        var toInsert = new List<ProprietyAttachment>();
        
        ids.ForEach(id =>
        {
            if (!allAttachments.Where(e => e.AttachmentId == id).Any())
                toInsert.Add(new ProprietyAttachment(entity.Id, id));
        });

        if (toInsert.Any())
            _proprietyAttachmentRepository.InsertMany(toInsert);

        var toDelete = allAttachments.Where(e => !ids.Contains(e.AttachmentId)).ToList();
        if (toDelete.Any())
            _proprietyAttachmentRepository.DeleteMany(toDelete);
    }

    private void UpdateProprietyContact(Propriety entity, ProprietyContactViewModel contactInfo)
    {
        if (contactInfo == null)
            return;
        
        var contact = _contactRepository.Get(e => e.Id == entity.ContactId).FirstOrDefault();
        if (contact == null)
        {
            contact = new ProprietyContact();
            UpdateContact(contactInfo, contact);
            _contactRepository.Insert(contact);

            entity.Contact = contact;
            entity.ContactId = contact.Id;
        }
        else
        {
            UpdateContact(contactInfo, contact);
            _contactRepository.Update(contact);
        }  
    }

    private static void UpdateContact(ProprietyContactViewModel contactInfo, ProprietyContact contact)
    {
        contact.Email = contactInfo.Email;
        contact.PhoneNumber = contactInfo.PhoneNumber;
        contact.PhoneType = contactInfo.PhoneType;
        contact.Fax = contactInfo.Fax;
    }

    private void UpdateProprietyCharacteristics(Propriety entity, ProprietyCharacteristicsViewModel characteristicsInfo)
    {
        if (characteristicsInfo == null)
            return;
       
        var characteristics = _characteristicsRepository.Get(e => e.Id == entity.CharacteristicsId).FirstOrDefault();
        if (characteristics == null)
        {
            characteristics = new ProprietyCharacteristics();
            UpdateCharacteristics(characteristicsInfo, characteristics);
            _characteristicsRepository.Insert(characteristics);

            entity.Characteristics = characteristics;
            entity.CharacteristicsId = characteristics.Id;
        }
        else
        {
            UpdateCharacteristics(characteristicsInfo, characteristics);
            _characteristicsRepository.Update(characteristics);
        }
    }

    private static void UpdateCharacteristics(ProprietyCharacteristicsViewModel characteristicsInfo, ProprietyCharacteristics characteristics)
    {
        characteristics.HasElectricity = characteristicsInfo.HasElectricity;
        characteristics.HasFishingPotential = characteristicsInfo.HasFishingPotential;
        characteristics.HasInternet = characteristicsInfo.HasInternet;
        characteristics.HasNaturalWaterSpring = characteristicsInfo.HasNaturalWaterSpring;
        characteristics.HasPhone = characteristicsInfo.HasPhone;
        characteristics.HasPotentialForEcotourism = characteristicsInfo.HasPotentialForEcotourism;
    }

    public void UpdateProprietyAddress(Propriety entity, ProprietyAddressViewModel addressInfo, bool isFromImport = false)
    {
        if (addressInfo == null)
            return;

        ProprietyAddress proprietyAddress = null;

        if (!isFromImport)
            proprietyAddress = _proprietyAddressRepository
                                .Query()
                                .Include(e => e.Address)
                                .Where(e => e.Id == entity.AddressId)
                                .FirstOrDefault();
        else
            proprietyAddress = entity.Address;

        if (proprietyAddress == null)
        { 
            proprietyAddress = CreateProprietyAddress(entity, addressInfo);

            if (!isFromImport)
                _addressRepository.Insert(proprietyAddress.Address);

            entity.Address = proprietyAddress;        
        }
        else
        {
            var address = proprietyAddress.Address;

            proprietyAddress.PostalCode = addressInfo.PostalCode;
            address.Street = addressInfo.Street;
            address.Number = address.Number.Patch(addressInfo.Number);
            address.District = addressInfo.District;
            address.Complement = address.Complement.Patch(addressInfo.Complement);
            address.ZipCode = addressInfo.Zipcode;
            address.Type = addressInfo.Type;

            if (addressInfo.CityId.HasValue)
                address.CityId = addressInfo.CityId.Value;

            if (!isFromImport)
            {
                _addressRepository.Update(address);
                _proprietyAddressRepository.Update(proprietyAddress);
            }
        }
    }

    private static ProprietyAddress CreateProprietyAddress(Propriety entity, ProprietyAddressViewModel addressInfo)
    {
        var address = new Address(addressInfo.Street, addressInfo.Number, addressInfo.Complement, addressInfo.Zipcode,
                                        addressInfo.Type, addressInfo.CityId.Value, "", "", addressInfo.District);

        var proprietyAddress = new ProprietyAddress()
        {
            PostalCode = addressInfo.PostalCode,
            AddressId = address.Id,
            Address = address,
        };

        entity.Address = proprietyAddress;
        entity.AddressId = proprietyAddress.Id;

        return proprietyAddress;
    }

    private static void SetProprietyData(Propriety propriety, ProprietyInsertUpdateViewModel newData)
    {
        propriety.CibNumber = newData.CibNumber;
        propriety.Situation = newData.Situation;
        propriety.Name = newData.Name;
        propriety.Type = newData.Type ?? ProprietyType.Null;
        propriety.DeclaredArea = newData.DeclaredArea;

        propriety.IncraCode = newData.IncraCode;
        propriety.MunicipalRegistration = newData.MunicipalRegistration;
        propriety.CARNumber = newData.CARNumber;
        propriety.Registration = newData.Registration;

        propriety.HasSettlement = newData.HasSettlement;
        propriety.SettlementName = newData.SettlementName;
        propriety.SettlementType = newData.SettlementType;

        propriety.HasPropertyCertificate = newData.HasPropertyCertificate;
        propriety.CertificateNumber = newData.CertificateNumber;

        propriety.HasRegularizedLegalReserve = newData.HasRegularizedLegalReserve;
        propriety.LegalReserveArea = newData.LegalReserveArea;

        propriety.HasSquattersInTheArea = newData.HasSquattersInTheArea;
        propriety.OccupancyPercentage = newData.OccupancyPercentage;
        propriety.OccupancyTime = newData.OccupancyTime;
        
        propriety.PermanentPreservation = newData.PermanentPreservation;
        propriety.LegalReserve = newData.LegalReserve;
        propriety.BusyWithImprovements = newData.BusyWithImprovements;
        propriety.Reforestation = newData.Reforestation;

        propriety.GoodSuitabilityFarming = newData.GoodSuitabilityFarming;
        propriety.RegularFitnessFarming = newData.RegularFitnessFarming;
        propriety.RestrictedAptitudeFarming = newData.RestrictedAptitudeFarming;
        propriety.PlantedPasture = newData.PlantedPasture;

        propriety.LinkedCib = string.IsNullOrEmpty(newData.LinkedCib) ? null : newData.LinkedCib;

        if (newData.FromAttachmentId.HasValue)
            propriety.FromAttachmentId = newData.FromAttachmentId.Value;
    }

    private void InsertCoordenates(Guid proprietyId, List<CoordenateViewModel> coordenates)
    {
        if (coordenates == null)
            return;

        var entities = new List<Coordenate>();

        int index = 0;
        coordenates.ForEach(item =>
        {
            entities.Add(new Coordenate(index++, item.Lat, item.Lng, proprietyId));
        });

        if(entities.Any())
            _coordenateRepository.InsertMany(entities);
    }

    private void DeleteCoordenates(Guid proprietyId)
    {
        var coordenates = _coordenateRepository
                            .Query()
                            .Where(e => e.ProprietyId == proprietyId)
                            .ToList();
        
        if (coordenates.Any())
            _coordenateRepository.DeleteMany(coordenates);
    }

    public bool CibExist(string cib)
    {
        return _repository.Query().Where(e => e.CibNumber == cib).Any();
    }

    public void UpdateMany(List<Propriety> entities)
    {
        var relations = entities.Select(e => e.Address).ToList();
        var addresses = relations.Select(e => e.Address).ToList();

        _repository.UpdateMany(entities);

        _addressRepository.UpdateMany(addresses);
        _proprietyAddressRepository.UpdateMany(relations);
    }

    public Guid? GetIdByCib(string cib)
    {
        var sanitizedCib = cib.SanitazeCib();
        return _repository.Query().Where(e => e.CibNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "") == sanitizedCib).FirstOrDefault()?.Id;
    }

    public bool IsOwner(Guid id, Guid? proprietyId)
    {
        return _repository
                .Query()
                .Where(x => x.Id == proprietyId)
                .Where(x => x.Owners.Where(e => e.OwnerId == id).Any())
                .Any();
    }

    public Dictionary<string, Propriety> GetIdsByCib(List<string> cibs)
    {
        var sanitizedCibs = cibs.Select(e => e.SanitazeDocument()).ToList();

        return _repository
                .Query()
                .Include(e => e.Address)
                .ThenInclude(e => e.Address)
                .Where(e => sanitizedCibs.Contains(e.CibNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
                .ToDictionary(e => e.CibNumber, e => e);
    }

    private Propriety Get(string cib)
    {
        return GetAll()
                .Where(e => e.CibNumber == cib)
                .FirstOrDefault();
    }

    private Propriety Get(Guid id)
    {
        return GetAll()
                .Include(e => e.Coordenates)
                .Include(e => e.Attachments)
                .ThenInclude(e => e.Attachment)
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private IQueryable<Propriety> GetAll()
    {
        return _repository
                .Query()
                .Include(e => e.Address)
                .Include(e => e.Address.Address)
                .ThenInclude(c => c.City)
                .ThenInclude(s => s.State)
                .Include(e => e.Contact)
                .Include(e => e.Characteristics)
                .Include(e => e.Owners)
                .ThenInclude(o => o.Owner)
                .Include(e => e.Coordenates);
    }

    private static Propriety ConvertToEntity(ProprietyInsertUpdateViewModel propriety, Propriety entity = null)
    {
        if (propriety == null)
            return null;
        
        if (entity == null)
            entity = new Propriety();
        
        SetProprietyData(entity, propriety);

        return entity;
    }

    public static ProprietyViewModel ConvertToViewModel(Propriety propriety)
    {
        if (propriety == null)
            return null;

        return new ProprietyViewModel(propriety);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }

    private void ValidateModel(ProprietyInsertUpdateViewModel model, bool validate = true, bool isFileImport = false)
    {
        var messages = new List<string>();

        if (!_addressServices.CityExist(model.Address?.CityId) && model.Address != null)
            messages.Add("Cidade não encontrada.");

        if ((model.Address?.Zipcode?.Length ?? 0) > 9)
            messages.Add("Zipcode inválido.");

        if (!string.IsNullOrEmpty(model.LinkedCib) && !CibExist(model.LinkedCib))
            messages.Add("CIB vinculado não cadastrado.");

        if (model.Attachments != null)
            model.Attachments.ForEach(e =>
            {
                if (!_attachmentServices.Exists(e))
                    messages.Add($"Arquivo(Id: {e} não encontrado");
            });

        if (messages.Any())
            throw new NotFoundException(messages);

        if (string.IsNullOrEmpty(model.CibNumber))
            messages.Add("O número do CIB é obrigatório.");

        if (!string.IsNullOrEmpty(model.CibNumber) && CibExist(model.CibNumber) && validate)
            messages.Add("CIB já cadastrado.");

        if (!isFileImport && model.Type == ProprietyType.Null)
            messages.Add("O tipo da propriedade é obrigatório.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private static ProprietyDashboardItem CreateDashboardItem(Propriety propriety)
    {
        var cityId = propriety?.Address?.Address?.CityId;
        var owners = propriety.Owners.Select(o => o.Owner).ToList();
        var addresses = propriety.Owners
                                .SelectMany(o => o.Owner.Addresses)
                                .Select(a => a.Address)
                                .ToList();

        var hasOwnersFromAnotherEntity = addresses.Where(o => o.CityId != cityId).Any();
        return new(propriety.Id, (decimal)propriety.DeclaredArea, hasOwnersFromAnotherEntity);
    }

    private static IQueryable<Propriety> Filter(IQueryable<Propriety> query, Metadata metadata = null, ProprietyParams @params = null)
    {
        if (@params == null)
            return query;

        query = query
                .WhereIf(@params.Type.HasValue,             e => e.Type == @params.Type)
                .WhereIf(@params.HasSettlement,             e => e.HasSettlement == @params.HasSettlement)
                .WhereIf(@params.HasRegularizedLegalReserve,e => e.HasRegularizedLegalReserve == @params.HasRegularizedLegalReserve)
                .WhereIf(@params.HasSquattersInTheArea,     e => e.HasSquattersInTheArea == @params.HasSquattersInTheArea)
                .WhereIf(@params.HasPropertyCertificate,    e => e.HasPropertyCertificate == @params.HasPropertyCertificate)
                .WhereIf(@params.Name,                      e => e.Name.Contains(@params.Name))
                .WhereIf(@params.Cib,                       e => e.CibNumber.Contains(@params.Cib))
                .WhereIf(@params.CityName,                  e => EF.Functions.Collate(e.Address.Address.City.Name, "SQL_Latin1_General_CP1_CI_AI").Contains(EF.Functions.Collate(@params.CityName, "SQL_Latin1_General_CP1_CI_AI")));

        
        string sortColLowercase = metadata.SortColumn.ToLower();
        Expression<Func<Propriety, Object>>  filter = sortColLowercase switch
        {
            "name" => e => e.Name,
            "cib" => e => e.CibNumber,
            "carnumber" => e => e.CARNumber,
            "area" => e => e.DeclaredArea,
            "registration" => e => e.MunicipalRegistration,
            "city" => e => e.Address.Address.City.Name,
            _ => x => x.CreatedAt
        };

        if(string.IsNullOrEmpty(metadata.SortColumn))
            metadata.SortColumn = "createdat";

        var direction = metadata.SortDirection.ToLower();
        query = (direction == "desc") ? query.OrderByDescending(filter) : query.OrderBy(filter);

        return query;
    }
}
