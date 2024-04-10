using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IPersonServices : INotifications
{
    List<AddressViewModel> ViewAddresses(Guid personId, string discriminator);
    List<string> ViewEmails(Guid personId);
    EmailViewModel ViewFirstEmail(Guid personId);
    void Delete(Guid id);
    PersonBase Insert(PersonViewModelBase model, PersonType type, string ownerId, string discriminator);
    void Update(PersonBase entity, PersonViewModelBase model, string ownerId, string discriminator);
    IEnumerable<Guid> GetIdsByDocuments(List<string> documents);
    void ValidateDocument(string document);
    bool DocumentAlreadyRegistered(string document);
    void ValidateCib(string cib);
    bool CibAlreadyRegistered(string cib);
    public IEnumerable<PersonListViewModel> List(PersonParams model, Metadata metadata);
    void ValidateInterval(DateTime? start, DateTime? end);
    bool IsValidInterval(DateTime? start, DateTime? end);
    bool IsValidAddress(Guid? cityId);
    void ValidateAddress(Guid? cityId);
    IEnumerable<SelectPersonViewModel> Select();
    PersonListViewModel View(Guid id);
    bool GeneralRecordAlreadyRegistered(string generalRecord);
    void ValidateGeneralRecord(string generalRecord);
    bool Exists(Guid? id);
    void ValidateModel(PersonViewModelBase model, string document = "", string cib = "", string generalRecord = "");
    PersonBase Create(PersonViewModelBase model, PersonType type, string ownerId, string discriminator);
    (PersonBase, List<AddressPerson>) Update(PersonBase entity, PersonViewModelBase model);
    void DeleteManyAddresses(List<AddressPerson> relations);
    void CreateAllUsers();
    SelectPersonViewModel ViewByUserId(Guid? userId);
    void Accreditation(PersonViewModelBase model);
    PersonBase CreateUser(Guid? id, PersonBase person = null, Guid? tenantId = null, string permissionName = "ContribuinteITR", bool runUpdate = true, List<DefaultPermissionPostViewModel> defaultPermissions = null);
    void AuthorizeAccreditation(Guid id);
    PersonBase GetById(Guid id);
    PersonBase GetByUserId(Guid? id);
    Dictionary<string, Guid> GetPersonIdByDocument(List<string> documents);
    Guid? GetPhysicalPersonIdByUserId(Guid? id);
    PersonBase InsertUpdate(PersonInsertUpdateViewModelAgiPrev model, AgiPrevPersonType agiPrevPersonType, Guid? id = null);
    SelectPersonViewModel CreateUser(PersonInsertUpdateViewModelAgiPrev model, Guid id);
}