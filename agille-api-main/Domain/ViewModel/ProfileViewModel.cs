using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel
{
  public class ProfileViewListParams
  {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool ViewProfileRestriction { get; set; }

  }
  public class ProfileSearchParam
  {
    public string Name { get; set; }
    public bool ViewProfileRestriction { get; set; } = false;
  }
  public class ProfileSearchViewModel
  {
    public ProfileSearchViewModel(Guid id, string name)
    {
      Id = id;
      Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
  }
  public class ProfileViewProfileModel
  {
    public ProfileViewProfileModel()
    {

    }
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public OwnerProfile OwnerProfile { get; set; } = new OwnerProfile();
    public List<PermissionViewModel> Permissions { get; set; }
  }

  public class OwnerProfile
  {
    public Guid OwnerProfileId { get; set; }
    public string OwnerProfileName { get; set; }
  }

  public class ProfileGetListViewModelResult
  {
    public ProfileGetListViewModelResult()
    {

    }

    public ProfileGetListViewModelResult(Guid id, string code, string name, string description, string ownerProfileName, int totalUsers)
    {
      Id = id;
      Code = code;
      Name = name;
      Description = description;
      OwnerProfileName = ownerProfileName;
      TotalUsers = totalUsers;
    }

    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string OwnerProfileName { get; set; }
    public int TotalUsers { get; set; }

  }
  public class ProfileIncludeViewModel
  {
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerProfileId { get; set; }
    public List<Guid> PermissionsId { get; set; }

    public bool FilledFields()
    {
      return (Code == null || Name == null || Description == null || OwnerProfileId == null || (PermissionsId == null || PermissionsId.Count == 0));
    }
  }

  public class ProfileUpdateViewModel
  {
    public Nullable<Guid> Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid OwnerProfileId { get; set; }
    public List<Guid> PermissionsId { get; set; }
    public bool FilledFields()
    {
      return ((Id == null || Id == Guid.Empty) || Code == null || Name == null || Description == null || OwnerProfileId == null || (PermissionsId == null || PermissionsId.Count == 0));
    }
  }
  public class ProfileExcludeViewModel
  {
    public Nullable<ProfileExcludeType> ExcludeOption { get; set; }
    public Nullable<Guid> Id { get; set; }
    public Nullable<Guid> NewProfile { get; set; }

    public bool FilledFields()
    {
      bool validNewProfile = false;
      if (ExcludeOption == ProfileExcludeType.ExcludeAndMoveDataToNewProfile &&
          (NewProfile == null || NewProfile == Guid.Empty))
        validNewProfile = true;

      return (ExcludeOption == null || (Id == null || Id == Guid.Empty) || validNewProfile);
    }
  }

  public class ProfilePermissions
  {
    public Profile Profile { get; set; }
    public List<Permission> Permissions { get; set; }
  }
}
