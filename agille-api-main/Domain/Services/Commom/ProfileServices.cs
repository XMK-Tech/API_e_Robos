using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.ViewModel;
using Domain.Services.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom
{
  public class ProfileServices : Notifications
  {
    private readonly IProfileRepository _profileRepository;
    private readonly ITemplateProfilePermissionsRepository _templateProfilePermissionsRepository;
    private readonly PermissionServices _permissionServices;
    public ProfileServices(IProfileRepository profileRepository, PermissionServices permissionServices, ITemplateProfilePermissionsRepository templateProfilePermissions)
    {
      _profileRepository = profileRepository;
      _permissionServices = permissionServices;
      _templateProfilePermissionsRepository = templateProfilePermissions;
    }


    private List<Profile> ViewProfileRestriction(List<Profile> profiles)
    {
      List<Profile> filteredProfiles = new List<Profile>();
      foreach (Profile profile in profiles)
      {
        filteredProfiles.Add(profile);
        if (_profileRepository.Query().Any(x => x.OwnerProfileId == profile.Id))
          ListSubProfiles(filteredProfiles, profile.Id);

      }

      //Possivel refatoração simples para se fazer abaixo
      List<Profile> profilesNoRepeatedRegistration = new List<Profile>();
      foreach (Profile _profile in profiles)
        if (!profilesNoRepeatedRegistration.Any(x => x.Id == _profile.Id))
          profilesNoRepeatedRegistration.Add(_profile);

      profiles = profilesNoRepeatedRegistration;

      return filteredProfiles;
    }
    private List<Profile> ListSubProfiles(List<Profile> profiles, Guid Owner_profile_id)
    {
      List<Profile> childs = _profileRepository.Query().Include(x => x.OwnerProfile).Where(x => x.OwnerProfileId.Equals(Owner_profile_id) && x.Id != Owner_profile_id).ToList();

      foreach (Profile item in childs)
      {
        profiles.Add(item);

        if (_profileRepository.Query().Any(x => x.OwnerProfileId == item.Id))
        {
          ListSubProfiles(profiles, item.Id);
        }
      }
      return profiles;
    }

    public List<ProfileGetListViewModelResult> List(ProfileViewListParams profile, Metadata metadata)
    {
      try
      {
        IQueryable<Profile> query = _profileRepository.Query().Include(e => e.OwnerProfile).AsQueryable();

        query = Filter(profile, query, metadata);

        Expression<Func<Profile, object>> filter = e => e.Name;

        if (metadata.SortColumn.ToLower() == "code")
          filter = e => e.Code;

        List<Profile> profiles = _profileRepository.ExecuteQuery(query, metadata, filter);

        if (query.Count() == 0)
        {
          ValidationMessages.Add("None profile was found");
          return null;
        }

        if (profile.ViewProfileRestriction)
          profiles = ViewProfileRestriction(profiles);

        return ConvertToViewModel(profiles);
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }
    private IQueryable<Profile> Filter(ProfileViewListParams profile, IQueryable<Profile> query, Metadata metadata)
    {
      if (profile.Id != Guid.Empty)
        query = query.Where(x => x.Id.Equals(profile.Id));

      if (profile.Name != null)
        query = query.Where(x => x.Name.Contains(TextFilter.RemoveAccents(profile.Name)));

      if (profile.Code != null)
        query = query.Where(x => x.Code == TextFilter.RemoveAccents(profile.Code));

      if (metadata.QuickSearch != null)
        query = query.Where(e => e.Code.Contains(TextFilter.RemoveAccents(metadata.QuickSearch)) || e.Name.Contains(TextFilter.RemoveAccents(metadata.QuickSearch)));

      return query;
    }


    //Metodo do Symp para buscar o id do profile Subscription
    public Profile InsertAdminSubscription(List<Guid> permissions)
    {
      try
      {
        //symp-admin-subscription
        //Tabele subsystem permission group
        Guid ownerProfileId = Guid.NewGuid();
        Profile profile = new Profile("symp-admin-subscription", "symp-admin-subscription", "symp-admin-subscription", ownerProfileId);
        profile.Id = ownerProfileId;

        _profileRepository.Insert(profile);

        List<TemplateProfilePermissions> TemplateProfilePermissions = new List<TemplateProfilePermissions>();
        foreach(var permissionId in permissions)
        {
          TemplateProfilePermissions templateProfilePermission = new TemplateProfilePermissions(profile.Id, permissionId);
          TemplateProfilePermissions.Add(templateProfilePermission);
        }
        _templateProfilePermissionsRepository.InsertMany(TemplateProfilePermissions);
        return profile;
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }
    public ProfileViewProfileModel View(Guid profile_id)
    {
      try
      {
        Profile profile = _profileRepository.Query().Where(e => e.Id == profile_id).Include(e => e.OwnerProfile).FirstOrDefault();
        if (profile == null)
        {
          ValidationMessages.Add("None profile was found");
          return null;
        }

        return ConvertToViewModel(profile);
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }
    public List<ProfileSearchViewModel> Search(ProfileSearchParam model)
    {
      try
      {
        List<Profile> profiles = _profileRepository.Query()
            .Where(e => e.Name.Contains(model.Name))
            .ToList();

        if (profiles.Count == 0)
        {
          ValidationMessages.Add("None profiles was found");
          return null;
        }

        if (model.ViewProfileRestriction)
          profiles = ViewProfileRestriction(profiles);

        return profiles.Select(e => new ProfileSearchViewModel(e.Id, e.Name)).ToList();
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }
    public List<ProfileSearchViewModel> Select()
    {
      try
      {
        List<Profile> profiles = _profileRepository.Query().AsNoTracking().ToList();
        return profiles.Select(e => new ProfileSearchViewModel(e.Id, e.Name)).ToList();
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }


    public void Include(ProfileIncludeViewModel profile)
    {
      try
      {
        if (!_permissionServices.PermissionListIsValid(profile.PermissionsId))
        {
          ValidationMessages.Add("Someone permission id is not valid");
          return;
        }

        Profile newProfile = ConvertToEntity(profile);
        _profileRepository.Insert(newProfile);

        List<TemplateProfilePermissions> templatePermissions = new List<TemplateProfilePermissions>();

        foreach (Guid permissionId in profile.PermissionsId)
        {
          templatePermissions.Add(new TemplateProfilePermissions(newProfile.Id, permissionId));
        }
        _templateProfilePermissionsRepository.InsertMany(templatePermissions);

      }
      catch (Exception ex)
      {
        ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }
    public void Update(ProfileIncludeViewModel model, Guid id)
    {
      try
      {
        if (!_profileRepository.Exists(id))
          ValidationMessages.Add("Profile id not valid");
        if (!_permissionServices.PermissionListIsValid(model.PermissionsId))
          ValidationMessages.Add("Someone permission id is not valid");
        if (!Valid)
          return;


        Profile profileToUpdate = ConvertToEntity(model);
        profileToUpdate.Id = id;

        _profileRepository.Update(profileToUpdate);

        Profile profile = _profileRepository.Query().Where(e => e.Id == id).AsNoTracking().FirstOrDefault();

        _templateProfilePermissionsRepository.DeleteMany(
            _templateProfilePermissionsRepository.Get(e => e.ProfileId == profile.Id)
            );

        List<TemplateProfilePermissions> templatePermissions = new List<TemplateProfilePermissions>();
        foreach (Guid permissionId in model.PermissionsId)
        {
          templatePermissions.Add(new TemplateProfilePermissions(profile.Id, permissionId));
        }
        _templateProfilePermissionsRepository.InsertMany(templatePermissions);

      }
      catch (Exception ex)
      {
        ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }
    public void Delete(ProfileExcludeViewModel profile)
    {
      try
      {
        if (profile.ExcludeOption == ProfileExcludeType.FullExclude)
          _profileRepository.Delete((Guid)profile.Id);

        if (profile.ExcludeOption == ProfileExcludeType.ExcludeAndMoveDataToNewProfile)
        {
          Profile newProfile = _profileRepository.GetById((Guid)profile.NewProfile);
          Profile oldProfile = _profileRepository.GetById((Guid)profile.Id);

          List<TemplateProfilePermissions> oldTemplatePermissions = _templateProfilePermissionsRepository
              .Query()
              .Where(e => e.ProfileId == oldProfile.Id)
              .AsNoTracking()
              .ToList();

          foreach (TemplateProfilePermissions templatePermission in oldTemplatePermissions)
          {
            _templateProfilePermissionsRepository.Update(new TemplateProfilePermissions(
                newProfile.Id,
                templatePermission.PermissionId)
            { Id = templatePermission.Id });
          }


        }
      }
      catch (Exception ex)
      {
        ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }

    private List<ProfileGetListViewModelResult> ConvertToViewModel(List<Profile> profiles)
    {
      List<ProfileGetListViewModelResult> viewModels = new List<ProfileGetListViewModelResult>();

      foreach (Profile profile in profiles)
      {
        ProfileGetListViewModelResult viewModel = new ProfileGetListViewModelResult();
        viewModel.Id = profile.Id;
        viewModel.Code = profile.Code;
        viewModel.Name = profile.Name;
        viewModel.Description = profile.Description;
        viewModel.OwnerProfileName = profile.OwnerProfile.Name;
        viewModel.TotalUsers = profiles.Count;

        viewModels.Add(viewModel);
      }
      return viewModels;
    }
    private ProfileViewProfileModel ConvertToViewModel(Profile profile)
    {
      ProfileViewProfileModel profileViewModel = new ProfileViewProfileModel();
      profileViewModel.Id = profile.Id;
      profileViewModel.Code = profile.Code;
      profileViewModel.Description = profile.Description;
      profileViewModel.Name = profile.Name;
      profileViewModel.OwnerProfile.OwnerProfileId = (Guid)profile.OwnerProfileId;
      profileViewModel.OwnerProfile.OwnerProfileName = profile.OwnerProfile.Name;
      profileViewModel.Permissions = _permissionServices.ListWithProfileId(profile.Id);

      return profileViewModel;
    }
    private Profile ConvertToEntity(ProfileIncludeViewModel profile)
    {
      return new Profile(profile.Code, profile.Name, profile.Description, profile.OwnerProfileId);
    }
  }
}
