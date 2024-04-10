using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.ViewModel;
using Domain.Services.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class PhysicalPersonServices : Notifications
{
    private readonly IPhysicalPersonRepository _repository;
    private readonly IPersonServices _personServices;
    private readonly IMiddlewareClient _middlewareClient;

    private readonly UserServices _userServices;
    private readonly JuridicalPersonServices _juridicalPersonServices;
    private readonly MessageTemplateServices _messageTemplateServices;

    public static readonly string Discriminator = "PhysicalPerson";

    public PhysicalPersonServices(
        IPhysicalPersonRepository repository, 
        UserServices userServices, 
        JuridicalPersonServices juridicalPersonServices, 
        MessageTemplateServices messageTemplateServices, 
        IPersonServices personServices, 
        IMiddlewareClient middlewareClient)
    {
        _repository = repository;

        _userServices = userServices;
        _userServices.ValidationMessages = ValidationMessages;

        _messageTemplateServices = messageTemplateServices;
        _juridicalPersonServices = juridicalPersonServices;
        _personServices = personServices;
        _middlewareClient = middlewareClient;
    }

    public object Search(PhysicalPersonSearch search)
    {
        try
        {
            var query = _repository
                            .Query()
                            .Include(e => e.Person)
                            .ThenInclude(x => x.User)
                            .ThenInclude(x => x.Profile)
                            .Where(e => e.Person.Status)
                            .AsQueryable();
            
            if (search.OnlyUsers)
                query = query.Where(e => e.Person.User != null);
            if (search.ProfileCode != null)
                query = query.Where(e => e.Person.User.Profile.Code.Contains(search.ProfileCode));
            if (search.DisplayName != null)
                query = query.Where(e => e.Person.DisplayName.Contains(search.DisplayName));

            return query.Select(e => new { e.Id, e.Person.DisplayName });
        }
        catch (Exception ex)
        {
            return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
        }
    }
    
    public List<PhysicalPersonListViewModel> List(PhysicalPersonParams model, Metadata metadata)
    {
        try
        {
            var query = _repository.Query()
                            .Where(e => e.Person.Status == true)
                            .Include(x => x.Person).ThenInclude(e => e.EmailPersons).ThenInclude(e => e.Email)
                            .Include(x => x.Person).ThenInclude(x => x.SocialMedias)
                            .Include(x => x.Person).ThenInclude(x => x.Phones)
                            .Include(x => x.Person).ThenInclude(x => x.User).ThenInclude(x => x.Email)
                            .Include(x => x.Person).ThenInclude(x => x.User).ThenInclude(x => x.Profile)
                            .Include(x => x.Person).ThenInclude(x => x.User).ThenInclude(e => e.UserPermissions).ThenInclude(e => e.Permission).AsQueryable();

            Expression<Func<PhysicalPersonBase, Object>> filter = x => x.Person.Name;
            if (String.IsNullOrEmpty(metadata.SortColumn))
            {
                filter = e => e.Person.Name;
                metadata.SortColumn = "Name";
            }
            else if (metadata.SortColumn.ToLower() == "status")
                filter = e => e.Person.Status;
            else if (metadata.SortColumn.ToLower() == "document")
                filter = e => e.Person.Document;
            else if (metadata.SortColumn.ToLower() == "displayname")
                filter = e => e.Person.DisplayName;
            else if (metadata.SortColumn.ToLower() == "profilepicurl")
                filter = e => e.Person.ProfilePicUrl;
            else if (metadata.SortColumn.ToLower() == "date")
                filter = e => e.Person.Date;
            else if (metadata.SortColumn.ToLower() == "type")
                filter = e => e.Person.Type;
            else if (metadata.SortColumn.ToLower() == "firstname")
                filter = e => e.FirstName;
            else if (metadata.SortColumn.ToLower() == "lastname")
                filter = e => e.LastName;
            else if (metadata.SortColumn.ToLower() == "detail")
                filter = e => e.Detail;
            else if (metadata.SortColumn.ToLower() == "gender")
                filter = e => e.Gender;

            if (model.OnlyUsers)
                query = query.Where(e => e.Person.User != null);

            if (!String.IsNullOrEmpty(metadata.QuickSearch))
            {
                string quick = TextFilter.RemoveAccents(metadata.QuickSearch);
                query = query.Where(e =>
                    e.Person.Name.Contains(quick)
                    || e.Person.Document == quick
                    || e.FirstName.Contains(quick)
                    || e.LastName.Contains(quick)
                );
            }

            List<PhysicalPersonListViewModel> physicalPerson = ConvertToViewModel(_repository.ExecuteQuery(query, metadata, filter));

            if (physicalPerson == null)
            {
                StatusCode = 500;
                ValidationMessages.Add("None physical persons was found");
                return null;
            }

            return physicalPerson;
        }
        catch (Exception ex)
        {
            return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
        }
    }
    
    public (Guid? id, Guid? personId)? Insert(PhysicalPersonInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var physicalPerson = ConvertToEntity(model);
        ThrowIfNull(physicalPerson);

        _repository.Insert(physicalPerson);        

        return (physicalPerson.Id, physicalPerson.PersonId);
    }
    
    public void CreateAgiPrev(Guid personId, string name)
    {
        var entity = new PhysicalPersonBase(firstName: name, lastName: null, detail: null, gender: Gender.NotSet, companyId: null);
        entity.PersonId = personId;
        _repository.Insert(entity);
    }

    public PhysicalPersonBase Create(PhysicalPersonInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var physicalPerson = ConvertToEntity(model, isFromImport: true);
        ThrowIfNull(physicalPerson);
        
        return physicalPerson;
    }

    public void Update(PhysicalPersonInsertUpdateViewModel model, Guid physicalPersonId)
    {
        var physicalPerson = _repository
                                .Query()
                                .Include(x => x.Person)
                                .ThenInclude(x => x.User)
                                .Where(e => e.Id == physicalPersonId)
                                .FirstOrDefault();
        ThrowIfNull(physicalPerson, Discriminator);

        var person = physicalPerson?.Person;
        ValidateModel(model, person?.Document, person?.CibNumber, person?.GeneralRecord);

        var entity = ConvertToEntity(model, physicalPerson);
        ThrowIfNull(entity);
        
        _repository.Update(entity);

        if (model.User != null)
            if (physicalPerson.Person.User == null)
                _userServices.Insert(model.User, physicalPerson.PersonId);
            else
                _userServices.Update(model.User, physicalPerson.PersonId);
        else
            _userServices.DeleteManyByPersonId(physicalPerson.PersonId);
    }
    
    public PhysicalPersonViewModel View(Guid physicalPersonId)
    {
        var physicalPerson = _repository.Query()
                    .Where(e => e.Id == physicalPersonId && e.Person.Status == true)
                    .Include(x => x.Person).ThenInclude(x => x.Addresses).ThenInclude(x => x.Address).ThenInclude(e => e.City).ThenInclude(e => e.State)
                    .Include(x => x.Person).ThenInclude(e => e.EmailPersons).ThenInclude(e => e.Email)
                    .Include(x => x.Person).ThenInclude(x => x.SocialMedias)
                    .Include(x => x.Person).ThenInclude(x => x.Phones)
                    .Include(x => x.Person).ThenInclude(x => x.User).ThenInclude(x => x.Email)
                    .Include(x => x.Person).ThenInclude(x => x.User).ThenInclude(e => e.UserPermissions).ThenInclude(e => e.Permission)
                    .Include(e => e.Person).ThenInclude(e => e.InventoryPerson)
                    .Include(e => e.Person).ThenInclude(e => e.LegalRepresentative).FirstOrDefault();
        ThrowIfNull(physicalPerson, Discriminator);

        return ConvertToViewModel(physicalPerson); 
    }
    
    private List<PhysicalPersonBase> GetManyByCompanyId(Guid companyId)
    {
        return _repository.Query().Where(p => p.CompanyId == companyId).Include(u => u.Person).ThenInclude(e => e.User).ToList();
    }
    
    private PhysicalPersonBase GetByUserId(Guid userId)
    {
        return _repository.Query().Include(p => p.Person).ThenInclude(e => e.User).Where(p => p.Person.User.Id == userId).FirstOrDefault();
    }
    
    public void Delete(Guid physicalPersonId)
    {
        var physicalPerson = _repository.Query().Include(e => e.Person).Where(e => e.Id == physicalPersonId && e.Person.Status == true).FirstOrDefault();
        ThrowIfNull(physicalPerson, Discriminator);

        _personServices.Delete(physicalPerson.PersonId);
        _userServices.UpdateStatusByPersonId(false, physicalPerson.PersonId);
    }

    private static List<PhysicalPersonListViewModel> ConvertToViewModel(List<PhysicalPersonBase> models)
    {
        var result = new List<PhysicalPersonListViewModel>();
        if (models == null)
            return result;

        models.ForEach(item =>
        {
            result.Add(
                new PhysicalPersonListViewModel(
                    id: item.Id,
                    personId: item.PersonId,
                    firstName: item.FirstName,
                    displayName: item.Person.DisplayName,
                    companyDisplayName: item.Person.DisplayName,
                    personEmail: item.Person.EmailPersons.Select(e => e.Email.Value).FirstOrDefault(),
                    userName: item.Person.User?.Username,
                    userEmail: item.Person.User?.Email?.Value,
                    companyId: item.CompanyId,
                    profilePicUrl: item.Person.ProfilePicUrl,
                    discriminator: item.Discriminator,
                    profileName: item.Person?.User?.Profile?.Name) 
            );
        });

        return result;
    }
    
    private PhysicalPersonViewModel ConvertToViewModel(PhysicalPersonBase model)
    {
        var person = model.Person;

        UserInfoViewModel user = null;
        var userId = person.UserId;
        if (userId.HasValue)
            user = _middlewareClient.GetUserInfos(new() { userId.Value }).FirstOrDefault();
        
        var viewModel = new PhysicalPersonViewModel(model.PersonId,
                                    person.Document,
                                    person.Name,
                                    person.DisplayName,
                                    person.Date,
                                    person.ProfilePicUrl,
                                    person.AgiPrevPersonType,
                                    AddressServices.ConvertToViewModel(person.Addresses.Select(e => e.Address).ToList()),
                                    _personServices.ViewEmails(model.PersonId),
                                    PhoneServices.ConvertToViewModel(person.Phones),
                                    SocialMediaServices.ConvertToViewModel(person.SocialMedias),
                                    model.Id,
                                    model.FirstName,
                                    model.LastName,
                                    model.Gender,
                                    model.Detail,
                                    _juridicalPersonServices.ConvertToViewModel(model.Companies),
                                    null,
                                    (user != null) ? new PhysicalPersonUserViewModel(userId ?? Guid.Empty, user.Email, user.Email, Guid.Empty, null, false) : null, 
                                    model.CompanyId)
        {
            LegalRepresentative = model.Person?.LegalRepresentative?.Name,
            LegalRepresentativeId = model.Person?.LegalRepresentativeId,
            LegalRepresentativeDocument = model.Person?.LegalRepresentative?.Document,
            LegalRepresentativeObs = model.Person?.LegalRepresentativeObs,

            InventoryPerson = model.Person?.InventoryPerson?.Name,
            InventoryPersonId = model.Person?.InventoryPersonId,
            InventoryPersonDocument = model.Person?.InventoryPerson?.Document,
            InventoryObs = model.Person?.InventoryObs,

            SocialName = person.SocialName,
            CibNumber = person.CibNumber,
            ImmunityYears = person.ImmunityYears,
            ReasonForImmunity = person.ReasonForImmunity,
            StartDate = person.StartDate,
            EndDate = person.EndDate,
        };
        

        return viewModel;
    }
    
    private PhysicalPersonBase ConvertToEntity(PhysicalPersonInsertUpdateViewModel viewModel, PhysicalPersonBase model = null, bool isFromImport = false)
    {
        if (viewModel == null) 
            return null;

        viewModel.Name = (string.IsNullOrEmpty(viewModel.Name) ? viewModel.FirstName + " " + viewModel.LastName : viewModel.Name);

        if (model == null)
        {
            var entityPerson = new PhysicalPersonBase(viewModel.FirstName, viewModel.LastName, viewModel.Detail, viewModel.Gender, viewModel.CompanyId, Discriminator);

            if (!isFromImport)
            {
                var personId = _personServices.Insert(viewModel, PersonType.Physical, entityPerson.Id.ToString(), Discriminator).Id;
                entityPerson.PersonId = personId;
            }
            else
            {
                entityPerson.Person = _personServices.Create(viewModel, PersonType.Physical, entityPerson.Id.ToString(), Discriminator);
            }
            
            return entityPerson;
        }
        else
        {
            _personServices.Update(model.Person, viewModel, model.Id.ToString(), Discriminator);
            model.Update(viewModel.FirstName, viewModel.LastName, viewModel.Detail, viewModel.Gender, viewModel.CompanyId, Discriminator);

            return model;
        }
    }

    private void ValidateModel(PhysicalPersonInsertUpdateViewModel model, string document = "", string cib = "", string generalRecord = "")
    {
        var messages = new List<string>();

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

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if(entity == null)
            throw new NotFoundException($"{message} not found!");
    }
}