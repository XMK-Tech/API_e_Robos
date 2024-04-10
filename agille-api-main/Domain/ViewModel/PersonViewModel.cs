using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.ViewModel;

public class PersonParams
{
    public string EstablishmentFormat { get; set; }
    public Guid Id { get; set; }
    public string Document { get; set; }
    public string Cib { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? AgiPrevPerson { get; set; } = null;
}

public class PersonViewModelBase
{
    public string Name { get; set; }
    public string Document { get; set; }
    public string GeneralRecord { get; set; }
    public string DisplayName { get; set; }
    public DateTime Date { get; set; }
    public string ProfilePicUrl { get; set; }

    public string CibNumber { get; set; }
    public string ImmunityYears { get; set; }
    public string ReasonForImmunity { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Guid? LegalRepresentativeId { get; set; }
    public string LegalRepresentativeObs { get; set; }
    
    public Guid? InventoryPersonId { get; set; }
    public string InventoryObs { get; set; }

    public string ProprietyCib { get; set; } = null;
    public string SocialName { get; set; }

    public List<Guid> Proprieties { get; set; } = new();
    
    public List<string> Emails { get; set; } = new List<string>();
    public List<PhoneViewModel> Phones { get; set; } = new List<PhoneViewModel>();
    public List<SocialMediaViewModel> SocialMedias { get; set; } = new List<SocialMediaViewModel>();
    public List<AddressInsertUpdateViewModel> Addresses { get; set; } = new List<AddressInsertUpdateViewModel>();

    [JsonIgnore]
    public string LegalRepresentativeName { get; set; } = null;
    [JsonIgnore]
    public string LegalRepresentativeDocument { get; set; } = null;

    [JsonIgnore]
    public string InventoryPersonName { get; set; } = null;
    [JsonIgnore]
    public string InventoryPersonDocument { get; set; } = null;
}

public class PersonListViewModel
{
    public PersonListViewModel() { }

    public PersonListViewModel(Guid id, string displayName, string name, List<PhoneViewModel> phones, List<string> emails, string document, string profilePicUrl, PersonType personType, string generalRecord, string cib, DateTime createdAt, Gender gender, DateTime? date, string socialName, AgiPrevPersonType agiPrevPersonType, string agiPrevCode)

    {
        Id = id;
        DisplayName = displayName;
        Name = name;
        Phones = phones;
        Emails = emails;
        Document = document;
        ProfilePicUrl = profilePicUrl;
        MunicipalRegistration = generalRecord;
        PersonType = personType;
        Cib = cib;
        GeneralRecord = generalRecord;
        CreatedAt = createdAt;
        Gender = gender;
        Date = date;
        SocialName = socialName;
        AgiPrevPersonType = agiPrevPersonType;
        AgiPrevCode = agiPrevCode;
    }

    public Guid Id { get; set; }
    public Guid? JuridicalOrPhysicalPersonId { get; set; }
    public string DisplayName { get; set; }
    public string Document { get; set; }
    public string GeneralRecord { get; set; }
    public string Name { get; set; }
    
    public List<PhoneViewModel> Phones { get; set; }
    public List<AddressViewModel> Addresses { get; set; }
    public List<string> Emails { get; set; }
    public List<ShortProprietyViewModel> Proprieties { get; set; }

    public string ProfilePicUrl { get; set; }
    public string MunicipalRegistration { get; set; }
    public PersonType PersonType { get; set; }
    public Gender Gender { get; set; }
    public string Cib { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? Date { get; set; }
    public string SocialName { get; set; }
    public AgiPrevPersonType AgiPrevPersonType { get; set; }
    public string AgiPrevCode { get; set; }

    public bool HasUser { get; set; }

    public bool HasLegalRepresentative { get; set; }
    public string LegalRepresentative { get; set; }
    public Guid? LegalRepresentativeId { get; set; }
    public string LegalRepresentativeDocument { get; set; }
    public string LegalRepresentativeObs { get; set; }

    public bool HasInventoryPerson { get; set; }
    public string InventoryPerson { get; set; }
    public Guid? InventoryPersonId { get; set; }    
    public string InventoryPersonDocument { get; set; }
    public string InventoryObs { get; set; }
}

public class SelectPersonViewModel {
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Cib { get; set; }
    public Guid? UserId { get; set; }
}

public class PersonInsertUpdateViewModelAgiPrev
{
    public PersonInsertUpdateViewModelAgiPrev(){}

    public PersonInsertUpdateViewModelAgiPrev(string name, string email, string agiPrevCode, string document)
    {
        Name = name;
        Email = email;
        AgiPrevCode = agiPrevCode;
        Document = document;
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string AgiPrevCode { get; set; } = "";
    public string Document { get; set; }
}