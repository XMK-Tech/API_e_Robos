using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel
{
  public class PhysicalPersonSearch
  {
    public string DisplayName { get; set; }
    public string ProfileCode { get; set; }
    public bool OnlyUsers { get; set; }
  }
  public class PhysicalPersonSearchEmployee
  {
    public string DisplayName { get; set; }
    public string ProfileCode { get; set; }
    public bool OnlyUsers { get; set; }
  }
  public class PhysicalPersonParams
  {
    public bool OnlyUsers { get; set; }
  }

  public class PhysicalPersonListViewModel
  {
    public PhysicalPersonListViewModel(Guid id, Guid personId, string displayName, string firstName, string profilePicUrl, string personEmail, User user, Guid companyId = default)
    {
      Id = id;
      PersonId = personId;
      FirstName = firstName;
      DisplayName = displayName;
      ProfilePicUrl = profilePicUrl;
      PersonEmail = personEmail;
      UserName = user != null ? user.Username : null;
      UserEmail = user != null ? user.Email != null ? user.Email.Value : null : null;
      CompanyId = companyId;
    }

    public PhysicalPersonListViewModel(Guid id, Guid personId, string firstName, string displayName, string personEmail, string userName, string userEmail, Guid? companyId, string companyDisplayName, string profilePicUrl, string discriminator, string profileName)
    {
      Id = id;
      PersonId = personId;
      FirstName = firstName;
      DisplayName = displayName;
      PersonEmail = personEmail;
      UserName = userName;
      UserEmail = userEmail;
      CompanyId = companyId;
      CompanyDisplayName = companyDisplayName;
      ProfilePicUrl = profilePicUrl;
      Discriminator = discriminator;
      ProfileName = profileName;
    }

    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string FirstName { get; set; }
    public string DisplayName { get; set; }
    public string PersonEmail { get; set; } // O primeiro e-mail pessoal relacionado à pessoa física.
    public string UserName { get; set; }
    public string UserEmail { get; set; } // E-mail de Login.
    public Guid? CompanyId { get; set; }
    public string CompanyDisplayName { get; set; }
    public string ProfilePicUrl { get; set; }
    public string Discriminator { get; set; }
    public string ProfileName { get; set; }
  }
  public class PhysicalPersonViewModel
  {
    public PhysicalPersonViewModel(Guid personId, string document, string name, string displayName, DateTime? date, string profilePicUrl, AgiPrevPersonType agiPrevPersonType, List<AddressViewModel> addresses, List<string> emails, List<PhoneViewModel> phones, List<SocialMediaViewModel> socialMedias, Guid id, string firstName, string lastName, Gender gender, string detail, List<JuridicalPersonListViewModel> companies, PhysicalPersonEmployeeViewModel employee, PhysicalPersonUserViewModel user, Guid? companyId)
    {
      PersonId = personId;
      Document = document;
      Name = name;
      DisplayName = displayName;
      Date = date;
      ProfilePicUrl = profilePicUrl;
      AgiPrevPersonType = agiPrevPersonType;
      Addresses = addresses;
      Emails = emails;
      Phones = phones;
      SocialMedias = socialMedias;
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Gender = gender;
      Detail = detail;
      Companies = companies;
      Employee = employee;
      User = user;
      CompanyId = companyId;
    }

    public Guid? CompanyId { get; set; }
    public Guid PersonId { get; set; }
    public string Document { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public DateTime? Date { get; set; }
    public string ProfilePicUrl { get; set; }
    public AgiPrevPersonType AgiPrevPersonType { get; set; }
    public List<AddressViewModel> Addresses { get; set; }
    public List<string> Emails { get; set; }
    public List<PhoneViewModel> Phones { get; set; }
    public List<SocialMediaViewModel> SocialMedias { get; set; }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string Detail { get; set; }
    public List<JuridicalPersonListViewModel> Companies { get; set; }
    public PhysicalPersonEmployeeViewModel Employee { get; set; }
    public PhysicalPersonUserViewModel User { get; set; }

    public string SocialName { get; set; }

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
  }

  public class PhysicalPersonEmployeeViewModel : EmployeeViewModel
  {
    public PhysicalPersonEmployeeViewModel(Guid id, EmployeeViewModel employeeViewModel) : base(employeeViewModel.Position, employeeViewModel.Code, employeeViewModel.Salary, employeeViewModel.TechnicalHourValue, employeeViewModel.ContractionDate, employeeViewModel.ResignationDate, null, null, employeeViewModel.Id)
    {
      Id = id;
    }

  }
  public class PhysicalPersonUserViewModel : UserViewModel
  {
    public PhysicalPersonUserViewModel(Guid id, UserViewModel userViewModel) 
            : base(userViewModel.Username, userViewModel.Email, userViewModel.ProfileId, userViewModel.Permissions, userViewModel.CustomPermissions)
    {
      Id = id;
    }
    
    public PhysicalPersonUserViewModel(Guid id, string username, string email, Guid profileId, List<Guid> permissions, bool customPermissions)
            : base(username, email, profileId, permissions, customPermissions)
    {
        Id = id;     
    }

    public Guid Id { get; set; }
  }

  public class PhysicalPersonInsertUpdateViewModel : PersonViewModelBase
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string Detail { get; set; }
        
    public Guid? CompanyId { get; set; }
    public UserViewModel User { get; set; }
  }
}