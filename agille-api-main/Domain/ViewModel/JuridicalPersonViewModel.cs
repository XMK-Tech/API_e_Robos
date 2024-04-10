using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel;

public class JuridicalPersonParams
{
    public string QuickSearch { get; set; }
    public string EstablishmentFormat { get; set; }
    public Guid PersonId { get; set; }
    public Guid Id { get; set; }
    public string Document { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public bool? IsCardOperator { get; set; }
}
public class JuridicalPersonListViewModel
{
    public JuridicalPersonListViewModel(Guid id, Guid personId, string displayName, string name, List<PhoneViewModel> phones, List<string> emails, string document, string profilePicUrl, EmailViewModel email, string municipalRegistration, bool isCardOperator = false, double cardRate = 0)
    {
        Id = id;
        PersonId = personId;
        DisplayName = displayName;
        Name = name;
        Phones = phones;
        Emails = emails;
        Document = document;
        ProfilePicUrl = profilePicUrl;
        PersonalEmail = email == null ? "" : email.Value;
        MunicipalRegistration = municipalRegistration;

        IsCardOperator = isCardOperator;
        CardRate = cardRate;    
    }

    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string DisplayName { get; set; }
    public string Document { get; set; }
    public string Name { get; set; }
    public List<PhoneViewModel> Phones { get; set; }
    public List<string> Emails { get; set; }
    public string ProfilePicUrl { get; set; }
    public string PersonalEmail { get; set; }
    public string MunicipalRegistration { get; set; }

    public bool IsCardOperator { get; set; }
    public double CardRate { get; set; }
}
public class JuridicalPersonInsertUpdateViewModel : PersonViewModelBase
{
    public string MunicipalRegistration { get; set; }
    public bool IsCardOperator { get; set; } = false;
    public double CardRate { get; set; }
    public List<Guid> ServiceTypesDescriptionIds { get; set; } = new List<Guid>();
}

public class JuridicalPersonViewModel
{
    public JuridicalPersonViewModel(Guid id, string document, string name, string displayName, DateTime? date, Guid personId, string profilePicUrl, string municipalRegistration, List<AddressViewModel> addresses, List<string> emails, List<PhoneViewModel> phones, List<SocialMediaViewModel> socialMedias, bool isCardOperator = false, double cardRate = 0)
    {
        Id = id;
        Document = document;
        Name = name;
        DisplayName = displayName;
        Date = date;
        PersonId = personId;
        ProfilePicUrl = profilePicUrl;
        Addresses = addresses;
        Emails = emails;
        Phones = phones;
        SocialMedias = socialMedias;
        MunicipalRegistration = municipalRegistration;

        IsCardOperator = isCardOperator;
        CardRate = cardRate;
    }

    public Guid Id { get; set; }
    public string Document { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public DateTime? Date { get; set; }
    public Guid PersonId { get; set; }
    public string ProfilePicUrl { get; set; }
    public string MunicipalRegistration { get; set; }
    public string Note { get; set; }
    public DateTime CreatedAt { get; set; }

    public bool IsCardOperator { get; set; }
    public double CardRate { get; set; }

    public string CibNumber { get; set; }
    public string ImmunityYears { get; set; }
    public string ReasonForImmunity { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string LegalRepresentative { get; set; }
    public Guid? LegalRepresentativeId { get; set; }
    public string LegalRepresentativeDocument { get; set; }
    public string LegalRepresentativeObs { get; set; }

    public string InventoryPerson { get; set; }
    public Guid? InventoryPersonId { get; set; }
    public string InventoryPersonDocument { get; set; }
    public string InventoryObs { get; set; }

    public string SocialName { get; set; }

    public List<AddressViewModel> Addresses { get; set; }
    public List<string> Emails { get; set; }
    public List<PhoneViewModel> Phones { get; set; }
    public List<SocialMediaViewModel> SocialMedias { get; set; }
    public List<ServiceTypeViewModel> ServiceTypes { get; set; }
}

public class JuridicalPersonWithOperatorRateViewModel
{
    public JuridicalPersonWithOperatorRateViewModel() { }
    public JuridicalPersonWithOperatorRateViewModel(Guid id, string document, string name, string displayName, string operatorDocument, decimal? rate)
    {
        Id = id;
        Document = document;
        Name = name;
        DisplayName = displayName;
        OperatorDocument = operatorDocument;

        Rate = rate;
        if (Rate.HasValue)
            Rate = Math.Round(Rate.Value, 2);
    }

    public Guid Id { get; set; }
    public string Document { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }

    public string OperatorDocument { get; set; }
    public decimal? Rate { get; set; }
}