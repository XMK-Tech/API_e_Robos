using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Shared;
using AgilleApi.Domain.ViewModel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class PersonServices : Notifications, IPersonServices
{
    private readonly IPersonRepository _repository;
    private readonly IAddressPersonRepository _addressPersonRepository;

    private readonly ITenantServices _tenantServices;
    private readonly IPersonFinderServices _personFinderServices;
    private readonly IProprietySecondaryServices _proprietySecondaryServices;
    private readonly ISessionServices _sessionServices;
    private readonly AddressServices _addressServices;
    private readonly EmailServices _emailServices;
    private readonly SocialMediaServices _socialMediaServices;
    private readonly PhoneServices _phoneServices;
    private readonly MiddlewareClient _middlewareClient;
    private readonly NotificationServices _notificationServices;

    public static readonly string Discriminator = "Person";

    public PersonServices(
        IPersonRepository repository, IAddressPersonRepository addressPersonRepository,
        AddressServices addressServices, EmailServices emailServices,
        SocialMediaServices socialMediaServices, PhoneServices phoneServices,
        IPersonFinderServices personFinderServices, IProprietySecondaryServices proprietySecondaryServices, ITenantServices tenantServices, NotificationServices notificationServices, ISessionServices sessionServices, MiddlewareClient middlewareClient)
    {
        _repository = repository;
        _addressPersonRepository = addressPersonRepository;
        _addressServices = addressServices;
        _emailServices = emailServices;
        _socialMediaServices = socialMediaServices;
        _phoneServices = phoneServices;
        _personFinderServices = personFinderServices;
        _proprietySecondaryServices = proprietySecondaryServices;
        _tenantServices = tenantServices;
        _notificationServices = notificationServices;
        _sessionServices = sessionServices;
        _middlewareClient = middlewareClient;
    }
    private IQueryable<PersonBase> Query()
    {
        return _repository.Query().Where(e => e.Status == true);
    }

    public IEnumerable<SelectPersonViewModel> Select()
    {
        return Query().Select(e => new SelectPersonViewModel
        {
            Id = e.Id,
            DisplayName = e.DisplayName,
            Name = e.Name,
            Document = e.Document,
            Cib = e.CibNumber
        });
    }

    public SelectPersonViewModel ViewByUserId(Guid? userId)
    {
        return Query()
            .Where(e => e.UserId == userId)
            .Select(e => new SelectPersonViewModel
            {
                Id = e.Id,
                DisplayName = e.DisplayName,
                Name = e.Name,
                Document = e.Document,
                Cib = e.CibNumber
            }).FirstOrDefault();
    }

    private IQueryable<PersonBase> Filter(PersonParams model, Metadata metadata)
    {
        var query = Query()
                    .Include(e => e.EmailPersons)
                    .ThenInclude(e => e.Email)
                    .Include(x => x.SocialMedias)
                    .Include(x => x.Phones)
                    .AsQueryable();

        string sortColLowercase = metadata.SortColumn.ToLower();
        Expression<Func<PersonBase, Object>> filter = sortColLowercase switch
        {
            "name" => e => e.Name,
            "document" => e => e.Document,
            "displayname" => e => e.DisplayName,
            "initialdate" => e => e.StartDate,
            "enddate" => e => e.EndDate,
            "generalrecord" => e => e.GeneralRecord,
            _ => x => x.CreatedAt
        };

        if (string.IsNullOrEmpty(metadata.SortColumn))
            metadata.SortColumn = "createdat";

        var direction = metadata.SortDirection.ToLower();
        query = (direction == "desc") ? query.OrderByDescending(filter) : query.OrderBy(filter);

        query = query
                .WhereIf(model.DisplayName, e => e.DisplayName.Contains(model.DisplayName))
                .WhereIf(model.Name, e => e.Name.Contains(model.Name))
                .WhereIf(model.Id != Guid.Empty, e => e.Id == model.Id)
                .WhereIf(metadata.QuickSearch, e => e.DisplayName.Contains(metadata.QuickSearch) || e.Name.Contains(metadata.QuickSearch) || e.Document.Contains(metadata.QuickSearch))
                .WhereIf(model.Document, e => e.Document.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(model.Document.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
                .WhereIf(model.Cib, e => e.CibNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(model.Cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
                .WhereIf(model.Email, e => e.EmailPersons.Any(emails => emails.Email.Value.Contains(model.Email)))
                .WhereIf(model.CreatedAt, e => e.CreatedAt.ToShortDateString() == model.CreatedAt.Value.ToShortDateString())
                .WhereIf(model.AgiPrevPerson, e => e.AgiPrevPersonType != 0);

        return query;
    }

    public IEnumerable<PersonListViewModel> List(PersonParams model, Metadata metadata)
    {
        var query = Filter(model, metadata).Include(p => p.EmailPersons);
        var entities = _repository.ExecuteQuery(query, metadata);

        ThrowIfNull(entities, "Entities");

        return entities.Select(e => ConvertToViewModel(e, false));
    }

    public PersonListViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Include(e => e.Addresses)
                        .ThenInclude(e => e.Address)
                        .ThenInclude(e => e.City)
                        .ThenInclude(e => e.State)
                        .Include(e => e.Phones)
                        .FirstOrDefault(e => e.Id == id);

        ThrowIfNull(entity, "Entity");

        return ConvertToViewModel(entity, true);
    }

    public List<AddressViewModel> ViewAddresses(Guid personId, string discriminator)
    {
        discriminator = (string.IsNullOrEmpty(discriminator)) ? Discriminator : discriminator;

        return _addressServices.List(new AddressParams() { Owner = discriminator, OwnerId = personId.ToString() })?.ToList();
    }

    public List<string> ViewEmails(Guid personId)
    {
        return _emailServices.List(personId).Select(e => e.Value)?.ToList();
    }

    public EmailViewModel ViewFirstEmail(Guid personId)
    {
        return _emailServices.List(personId)?.FirstOrDefault();
    }
    public PersonBase InsertUpdate(PersonInsertUpdateViewModelAgiPrev model, AgiPrevPersonType agiPrevPersonType, Guid? id = null)
    {
        PersonBase entity = ValidatePersonAgiPrev(model, id);
        var emails = new List<string>() { model.Email };

        if (entity == null)
        {
            entity = _repository.Insert(ConvertToEntity(model, agiPrevPersonType));
            _emailServices.Insert(emails, entity.Id);
            return entity;
        }
        else
        {
            _repository.Update(ConvertToEntity(model, agiPrevPersonType, entity));
            _emailServices.Update(emails, entity.Id);
            return _repository.GetById((Guid)id);
        }
    }
    private PersonBase ValidatePersonAgiPrev(PersonInsertUpdateViewModelAgiPrev model, Guid? id)
    {
        if (string.IsNullOrEmpty(model.Email))
            throw new ConflictException("E-mail é um campo obrigatório");

        PersonBase entity = null;
        if (id != null && id != Guid.Empty)
            entity = _repository.GetById((Guid)id);

        var query = _repository.Query().Where(x => x.AgiPrevCode.ToLower() == model.AgiPrevCode.ToLower());

        if (entity == null && query.Any())
            throw new ConflictException("Esse codigo já existe");
        else if (entity != null && query.Any(x => x.Id != entity.Id))
            throw new ConflictException("Esse codigo já existe");
        return entity;
    }

    public SelectPersonViewModel CreateUser(PersonInsertUpdateViewModelAgiPrev model, Guid id)
    {
        var person = InsertUpdate(model, AgiPrevPersonType.Operator, id);
        var defaultPermissions = new List<DefaultPermissionPostViewModel>()
        {
            new DefaultPermissionPostViewModel(DefaultPermissionType.ManageUsers, true)
        };
        var entity = CreateUser(id, person, permissionName: "Agiprev", defaultPermissions: defaultPermissions);
        return new SelectPersonViewModel()
        {
            Id = entity.Id,
            DisplayName = entity.DisplayName,
            Name = entity.Name,
            Document = entity.Document,
            Cib = entity.CibNumber,
            UserId = entity.UserId
        };
    }

    public PersonBase Insert(PersonViewModelBase model, PersonType type, string ownerId, string discriminator)
    {
        ValidateModel(model);

        var entity = ConvertToEntity(model, type);
        _repository.Insert(entity);

        discriminator = (string.IsNullOrEmpty(discriminator)) ? Discriminator : discriminator;

        if (model.Addresses.Any())
        {
            model.Addresses.ForEach(addresse =>
            {
                addresse.Owner = String.IsNullOrEmpty(addresse.Owner) ? discriminator : addresse.Owner;
                addresse.OwnerId = ownerId;
            });

            InsertAddress(model.Addresses, entity.Id);
        }

        if (model.SocialMedias.Any())
            _socialMediaServices.Insert(model.SocialMedias, entity.Id);

        if (model.Emails.Any())
            _emailServices.Insert(model.Emails, entity.Id);

        if (model.Phones.Any())
            _phoneServices.Insert(model.Phones, entity.Id);

        if (model.Proprieties.Any())
            _proprietySecondaryServices.SetOwnerProprieties(entity.Id, model.Proprieties);

        return entity;
    }

    public PersonBase Create(PersonViewModelBase model, PersonType type, string ownerId, string discriminator)
    {
        ValidateModel(model);

        var entity = ConvertToEntity(model, type);

        discriminator = (string.IsNullOrEmpty(discriminator)) ? Discriminator : discriminator;

        if (model.Addresses.Any())
        {
            model.Addresses.ForEach(addresse =>
            {
                addresse.Owner = String.IsNullOrEmpty(addresse.Owner) ? discriminator : addresse.Owner;
                addresse.OwnerId = String.IsNullOrEmpty(ownerId) ? entity.Id.ToString() : ownerId;
            });

            entity.Addresses = CreateAddress(model.Addresses, entity.Id);
        }

        if (model.SocialMedias.Any())
            entity.SocialMedias = _socialMediaServices.Create(model.SocialMedias, entity.Id);

        if (model.Emails.Any())
            entity.EmailPersons = EmailServices.Create(model.Emails, entity.Id);

        if (model.Phones.Any())
            entity.Phones = _phoneServices.Create(model.Phones, entity.Id);

        return entity;
    }

    public void Accreditation(PersonViewModelBase model)
    {
        var type = model.Document.Contains('/') ? PersonType.Juridical : PersonType.Physical;
        var entity = Create(model, type, "", "");

        var tenantId = _tenantServices.GetId();

        var currentUser = _sessionServices.GetUserId();
        var isAnonymous = !(currentUser.HasValue && currentUser != Guid.Empty);

        if (!isAnonymous)
            CreateUser(null, entity, tenantId, "UsuarioDTE", false);

        _repository.Insert(entity);
    }

    public void AuthorizeAccreditation(Guid id)
    {
        CreateUser(id, null, null, "UsuarioDTE", true);
    }

    public (PersonBase, List<AddressPerson>) Update(PersonBase entity, PersonViewModelBase model)
    {
        ValidateModel(model, entity.Document, entity.CibNumber, entity.GeneralRecord);

        UpdateEntity(model, entity);

        var addressToDelete = entity.Addresses.ToList();

        model.Addresses.ForEach(addresse =>
        {
            addresse.Owner = Discriminator;
            addresse.OwnerId = entity.Id.ToString();
        });
        entity.Addresses = CreateAddress(model.Addresses, entity.Id);

        return (entity, addressToDelete);
    }

    public void Update(PersonBase entity, PersonViewModelBase model, string ownerId, string discriminator)
    {
        ValidateModel(model, entity.Document, entity.CibNumber, entity.GeneralRecord);

        UpdateEntity(model, entity);

        discriminator = (string.IsNullOrEmpty(discriminator)) ? Discriminator : discriminator;

        DeletePersonAddresses(ownerId, discriminator);
        model.Addresses.ForEach(addresse =>
        {
            addresse.Owner = String.IsNullOrEmpty(addresse.Owner) ? discriminator : addresse.Owner;
            addresse.OwnerId = ownerId;
        });
        InsertAddress(model.Addresses, entity.Id);

        if (model.SocialMedias.Any())
            _socialMediaServices.Update(model.SocialMedias, entity.Id);
        else
            _socialMediaServices.DeleteManyByPersonId(entity.Id);

        if (model.Emails.Any())
            _emailServices.Update(model.Emails, entity.Id);
        else
            _emailServices.DeleteManyByPersonId(entity.Id);

        if (model.Phones.Any())
            _phoneServices.Update(model.Phones, entity.Id);
        else
            _phoneServices.DeleteManyByPersonId(entity.Id);

        _proprietySecondaryServices.SetOwnerProprieties(entity.Id, model.Proprieties);

        _repository.Update(entity);
    }

    private void DeletePersonAddresses(string ownerId, string discriminator)
    {
        var addressIds = _addressServices.List(new AddressParams() { Owner = discriminator, OwnerId = ownerId }).Select(e => e.Id).ToList();
        _addressServices.DeleteMany(addressIds);
    }

    public void Delete(Guid id)
    {
        var entity = _repository.Query().Where(e => e.Id == id).FirstOrDefault();
        ThrowIfNull(entity, Discriminator);

        entity.Status = false;

        _repository.Update(entity);
    }

    public PersonBase GetById(Guid id)
    {
        return _repository
            .Query()
            .Include(e => e.Addresses)
            .ThenInclude(e => e.Address)
            .ThenInclude(e => e.City)
            .ThenInclude(e => e.State)
            .ThenInclude(e => e.Country)
            .Include(e => e.Phones)
            .Include(e => e.EmailPersons)
            .ThenInclude(e => e.Email)
            .Where(e => e.Id == id)
            .FirstOrDefault();
    }

    public PersonBase GetByUserId(Guid? id)
    {
        return _repository
            .Query()
            .Include(e => e.Addresses)
            .ThenInclude(e => e.Address)
            .ThenInclude(e => e.City)
            .ThenInclude(e => e.State)
            .ThenInclude(e => e.Country)
            .Include(e => e.Phones)
            .Include(e => e.EmailPersons)
            .ThenInclude(e => e.Email)
            .Where(e => e.UserId == id)
            .FirstOrDefault();
    }

    public Guid? GetPhysicalPersonIdByUserId(Guid? id)
    {
        return _repository
                .Query()
                .Where(e => e.UserId == id)
                .Select(e => e.PhysicalPerson.Id as Guid?)
                .FirstOrDefault();
    }

    public void CreateAllUsers()
    {
        var persons = _repository
                        .Query()
                        .Include(e => e.EmailPersons)
                        .ThenInclude(e => e.Email)
                        .Include(e => e.Phones)
                        .Where(e => e.Status == true && !e.UserId.HasValue)
                        .Where(e => e.EmailPersons.Any())
                        .ToList();

        var toUpdate = new List<PersonBase>();
        var tenantId = _tenantServices.GetId();

        persons.ForEach(p =>
        {
            var response = CreateUser(p.Id, p, tenantId, "ContribuinteITR", false);
            if (response != null)
                toUpdate.Add(response);
        });

        if (toUpdate.Any())
            _repository.UpdateMany(toUpdate);

        var errors = persons.Count - toUpdate.Count;
        string message = (errors > 0) ? $"{errors} contribuintes houveram seu acesso recusado pela plataforma. É necessário checar a consistência dos dados(Email e Nome) dessa pessoa" : "Todos os contribuintes receberam acesso a plataforma.";

        var userId = _sessionServices.GetUserId();
        _notificationServices.InsertMany(new()
        {
            UserIds = new List<Guid>() { userId.Value },
            Title = "Liberação de acesso dos contribuintes concluída com sucesso.",
            Message = message,
            Link = "",
            Priority = NotificationPriority.Normal,
        });
    }

    public PersonBase CreateUser(Guid? id, PersonBase person = null, Guid? tenantId = null, string permissionName = "ContribuinteITR", bool runUpdate = true, List<DefaultPermissionPostViewModel> defaultPermissions = null)
    {
        if (person == null)
            person = _repository.Query().Include(e => e.EmailPersons).ThenInclude(e => e.Email).Include(e => e.Phones).Where(e => e.Id == id).FirstOrDefault();

        ThrowIfNull(person, "Person");

        var messages = new List<string>();

        if (person.UserId.HasValue)
            messages.Add("Essa pessoa já possui um usuário para acessar o sistema.");

        var email = person.EmailPersons.FirstOrDefault()?.Email?.Value;
        if (string.IsNullOrEmpty(email))
            messages.Add("Essa pessoa não possui um email válido para acessar o sistema.");

        if (messages.Any())
        {
            if (!runUpdate)
                return null;
            else
                throw new BadRequestException(messages);
        }

        tenantId ??= _tenantServices.GetId();
        ThrowIfNull(tenantId, "TenantId");

        var permission = new MiddlewarePermissionViewTemplate(permissionName, tenantId, null, false);
        var phone = person?.Phones?.FirstOrDefault()?.Number;

        var body = new MiddlewareUserInsertViewModel()
        {
            UserId = person.UserId,
            Username = email,
            Email = email,
            PhoneNumber = phone,
            Fullname = person.Name,
            Document = person.Document,
            Permissions = new List<MiddlewarePermissionViewTemplate>() { permission },
            Entities = new List<Guid>() { tenantId.Value }
        };

        var json = JsonConvert.SerializeObject(body);
        var response = _middlewareClient.PutUser(json);

        if (!response.Id.HasValue)
        {
            if (runUpdate)
                return null;
            else
                throw new BadRequestException(response.Messages);
        }
        if (defaultPermissions != null && defaultPermissions.Count > 0)
        {
            foreach (var item in defaultPermissions)
                item.UserId = (Guid)response.Id;
            var jsonDefaultPermissions = JsonConvert.SerializeObject(defaultPermissions);
            _middlewareClient.InsertDefaultPermission(jsonDefaultPermissions);
        }

        person.UserId = response.Id;

        if (runUpdate)
            _repository.Update(person);

        return person;
    }

    public bool Exists(Guid? id)
    {
        return _repository.Query().Where(e => e.Id == id).Any();
    }

    public void ValidateDocument(string document)
    {
        if (DocumentAlreadyRegistered(document))
            throw new BadRequestException("Documento já registrado!");
    }

    public bool DocumentAlreadyRegistered(string document)
    {
        return _repository.Query().Where(e => e.Document == document).Any();
    }

    public void ValidateCib(string cib)
    {
        if (CibAlreadyRegistered(cib))
            throw new BadRequestException("Cib já registrado.");
    }

    public bool CibAlreadyRegistered(string cib)
    {
        return _repository.Query().Where(e => e.CibNumber == cib).Any();
    }

    public void ValidateInterval(DateTime? start, DateTime? end)
    {
        if (!IsValidInterval(start, end))
            throw new BadRequestException("Data de início deve ser menor que data de fim.");
    }

    public bool IsValidInterval(DateTime? start, DateTime? end)
    {
        if ((start.HasValue && end.HasValue) && (start != DateTime.MinValue && end != DateTime.MinValue))
            return start.Value < end.Value;

        return true;
    }

    public bool IsValidAddress(Guid? cityId)
    {
        return _addressServices.CityExist(cityId);
    }

    public void ValidateAddress(Guid? cityId)
    {
        if (IsValidAddress(cityId))
            throw new BadRequestException("Cidade não encontrada.");
    }

    public bool GeneralRecordAlreadyRegistered(string generalRecord)
    {
        return _repository.Query().Where(e => e.GeneralRecord == generalRecord).Any();
    }

    public void ValidateGeneralRecord(string generalRecord)
    {
        if (GeneralRecordAlreadyRegistered(generalRecord))
            throw new BadRequestException("Registro geral já registrado.");
    }

    public IEnumerable<Guid> GetIdsByDocuments(List<string> documents)
    {
        if (documents == null || !documents.Any())
            return new List<Guid>();

        return _repository
                .Query()
                .Where(e => documents.Contains(e.Document))
                .Select(e => e.Id)
                .ToList();
    }

    public Dictionary<string, Guid> GetPersonIdByDocument(List<string> documents)
    {
        if (documents == null || !documents.Any())
            return new Dictionary<string, Guid>();

        return _repository
                .Query()
                .Where(e => documents.Contains(e.Document.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
                .Select(e => new { e.Document, e.Id })
                .ToDictionary(e => e.Document.SanitazeDocument(), e => e.Id);
    }

    public void DeleteManyAddresses(List<AddressPerson> relations)
    {
        if (relations == null)
            return;

        var addresses = relations.Select(e => e.Address).ToList();

        if (relations.Any())
            _addressPersonRepository.DeleteMany(relations);

        if (addresses.Any())
            _addressServices.DeleteMany(addresses);
    }

    private void InsertAddress(List<AddressInsertUpdateViewModel> address, Guid personId)
    {
        var relations = CreateAddress(address, personId);

        if (relations.Any())
            _addressPersonRepository.InsertMany(relations);
    }

    private List<AddressPerson> CreateAddress(List<AddressInsertUpdateViewModel> address, Guid personId)
    {
        var relations = new List<AddressPerson>();

        var models = _addressServices.Create(address);
        models.ForEach(e =>
        {
            relations.Add(new AddressPerson(personId, e.Id)
            {
                Address = e,
            });
        });

        return relations;
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }

    private PersonListViewModel ConvertToViewModel(PersonBase model, bool includeDependencies = false)
    {
        if (model == null)
            return null;

        var generalRecord = (model.Type == PersonType.Physical) ? model.GeneralRecord : _personFinderServices.GetJuridicalPersonMunicipalRegistration(model.Id);
        var gender = _personFinderServices.GetPersonGender(model.Id, model.Type);

        var viewModel = new PersonListViewModel(model.Id,
                                        model.DisplayName,
                                        model.Name,
                                        PhoneServices.ConvertToViewModel(model.Phones),
                                        ViewEmails(model.Id),
                                        model.Document,
                                        model.ProfilePicUrl,
                                        model.Type,
                                        generalRecord,
                                        model.CibNumber,
                                        model.CreatedAt,
                                        gender,
                                        model.Date,
                                        model.SocialName,
                                        model.AgiPrevPersonType,
                                        model.AgiPrevCode)
        {
            HasUser = model.UserId.HasValue,
        };

        if (includeDependencies)
        {
            viewModel.Addresses = AddressServices.ConvertToViewModel(model.Addresses.Select(e => e.Address).ToList());
            viewModel.JuridicalOrPhysicalPersonId = _personFinderServices.GetJuridicalOrPhysicalId(model.Id, model.Type);

            viewModel.HasLegalRepresentative = model.LegalRepresentativeId.HasValue;
            viewModel.LegalRepresentative = model?.LegalRepresentative?.Name;
            viewModel.LegalRepresentativeId = model?.LegalRepresentativeId;
            viewModel.LegalRepresentativeDocument = model?.LegalRepresentative?.Document;
            viewModel.LegalRepresentativeObs = model?.LegalRepresentativeObs;

            viewModel.HasInventoryPerson = model.InventoryPersonId.HasValue;
            viewModel.InventoryPerson = model?.InventoryPerson?.Name;
            viewModel.InventoryPersonId = model?.InventoryPersonId;
            viewModel.InventoryPersonDocument = model?.InventoryPerson?.Document;
            viewModel.InventoryObs = model?.InventoryObs;

            viewModel.Proprieties = _proprietySecondaryServices.ProprietiesByOwnerId(model.Id)?.ToList();
        }

        return viewModel;
    }

    private static void UpdateEntity(PersonViewModelBase model, PersonBase entity)
    {
        entity.Name = model.Name;
        entity.DisplayName = model.DisplayName;
        entity.Document = model.Document;
        entity.Date = model.Date;
        entity.ProfilePicUrl = model.ProfilePicUrl;

        entity.GeneralRecord = model.GeneralRecord;
        entity.CibNumber = model.CibNumber;
        entity.ImmunityYears = model.ImmunityYears;
        entity.ReasonForImmunity = model.ReasonForImmunity;
        entity.SocialName = model.SocialName;

        entity.StartDate = model.StartDate;
        entity.EndDate = model.EndDate;

        entity.InventoryPersonId = model.InventoryPersonId;
        entity.LegalRepresentativeId = model.LegalRepresentativeId;

        entity.InventoryObs = model.InventoryObs;
        entity.LegalRepresentativeObs = model.LegalRepresentativeObs;
    }

    private PersonBase ConvertToEntity(PersonViewModelBase model, PersonType type)
    {
        var entity = new PersonBase()
        {
            Status = true,
            Type = type,
        };

        UpdateEntity(model, entity);

        return entity;
    }
    private static PersonBase ConvertToEntity(PersonInsertUpdateViewModelAgiPrev model, AgiPrevPersonType agiPrevPersonType, PersonBase entity = null)
    {
        if (entity == null)
            entity = new PersonBase(model.Name, model.AgiPrevCode, agiPrevPersonType, model.Document);
        else
            entity.Update(model.Name, model.AgiPrevCode, model.Document);
        return entity;
    }
    public void ValidateModel(PersonViewModelBase model, string document = "", string cib = "", string generalRecord = "")
    {
        var messages = new List<string>();

        if (string.IsNullOrEmpty(model.Document))
            messages.Add("Documento é um campo obrigatório.");

        if (DocumentAlreadyRegistered(model.Document) && model.Document != document && !string.IsNullOrEmpty(model.Document))
            messages.Add("Documento já cadastrado.");

        if (CibAlreadyRegistered(model.CibNumber) && model.CibNumber != cib && !string.IsNullOrEmpty(model.CibNumber))
            messages.Add("CIB já cadastrado.");

        if (model.InventoryPersonId.HasValue && !Exists(model.InventoryPersonId.Value))
            messages.Add("Invetariante não encontrado.");

        if (model.LegalRepresentativeId.HasValue && !Exists(model.LegalRepresentativeId.Value))
            messages.Add("Representante legal não encontrado.");

        if (model.Addresses != null)
            foreach (var address in model.Addresses)
            {
                if (!IsValidAddress(address?.CityId))
                {
                    messages.Add("Cidade não encontrada.");
                    break;
                }
            }

        if (model.Proprieties != null)
            model.Proprieties.ForEach(e =>
            {
                if (!_proprietySecondaryServices.ProprietyExist(e))
                    messages.Add($"Propriedade(Id: {e}) não encontrada.");
            });

        if (messages.Any())
            throw new BadRequestException(messages);
    }
}