using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom
{
    public class PermissionServices : Notifications
    {
        private readonly IUserPermissionRepository _repository;
        private readonly IPermissionRepository _permissionRepository;
        public PermissionServices(IUserPermissionRepository repository, IPermissionRepository permissionRepository)
        {
            _repository = repository;
            _permissionRepository = permissionRepository;
        }
        public bool PermissionListIsValid(List<Guid> permission_ids)
        {
            bool valid = true;

            foreach (Guid id in permission_ids)
                if (!_permissionRepository.Exists(id))
                    valid = false;

            return valid;
        }
        public List<PermissionViewModel> ListWithProfileId(Guid profile_id)
        {
            List<Permission> permissions = _permissionRepository.Query()
                .Where(e => e.TemplateProfilePermissions.Any(e => e.ProfileId == profile_id))
                .Include(e => e.PermissionGroup)
                .Include(e => e.OwnerPermission)
                .ToList();
            return ConvertToViewModel(permissions);
        }

        public List<PermissionViewModel> List(Guid user_id)
        {
            try
            {
                List<Guid> userPermissions = _repository.Get(e => e.UserId == user_id).Select(e => e.PermissionId).ToList();
                List<Permission> permissions = _permissionRepository.Query()
                                                                    .Include(e => e.PermissionGroup)
                                                                    .Include(e => e.OwnerPermission)
                                                                    .Where(e => userPermissions.Contains(e.Id)).ToList();
                if (permissions.Count == 0)
                {
                    ValidationMessages.Add("None Permission was found");
                    return null;
                }
                return ConvertToViewModel(permissions);
            }
            catch (Exception ex)
            {
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }
        public List<PermissionModel> ListToModel(Guid user_id)
        {
            try
            {
                List<Guid> userPermissions = _repository.Get(e => e.UserId == user_id).Select(e => e.PermissionId).ToList();
                List<Permission> permissions = _permissionRepository.Query()
                                                                    .Include(e => e.PermissionGroup)
                                                                    .Include(e => e.OwnerPermission)
                                                                    .Where(e => userPermissions.Contains(e.Id)).ToList();
                if (permissions == null)
                {
                    ValidationMessages.Add("None Permission was found");
                    StatusCode = 500;
                    return null;
                }
                if (permissions.Count == 0)
                    return new List<PermissionModel>();

                return ConvertToModel(permissions);
            }
            catch (Exception ex)
            {
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }
        public void Insert(List<Guid> Ids, Guid user_id)
        {
            try
            {
                List<UserPermission> userPermissions = new List<UserPermission>();
                foreach (Guid id in Ids)
                {
                    userPermissions.Add(new UserPermission(user_id, id));
                }
                _repository.InsertMany(userPermissions);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void Update(List<Guid> Ids, Guid user_id)
        {
            try
            {
                Delete(user_id);
                Insert(Ids, user_id);
            }
            catch (Exception ex)
            {
                StatusCode = 500;
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }

        public void Delete(Guid user_id)
        {
            try
            {
                var models = _repository.Get(e => e.UserId == user_id).ToList();
                if (models == null)
                    return;
                _repository.DeleteMany(models);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public List<PermissionViewListModel> List(Metadata metadata)
        {
            try
            {
                List<Permission> permissions = _permissionRepository.ExecuteQuery(_permissionRepository.Query(), metadata);
                if (permissions == null)
                {
                    ValidationMessages.Add("None Permission was found");
                    return null;
                }
                List<PermissionViewListModel> results = new List<PermissionViewListModel>();
                foreach (var permission in permissions)
                {
                    var result = new PermissionViewListModel(permission.Code, permission.Name, permission.Description, permission.Id);
                    results.Add(result);
                }

                return results;
            }
            catch (Exception ex)
            {
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }

        private List<PermissionViewModel> ConvertToViewModel(List<Permission> model)
        {
            List<PermissionViewModel> result = new List<PermissionViewModel>();
            foreach (Permission item in model)
            {
                result.Add(ConvertToViewModel(item));
            }
            return result;
        }
        public List<PermissionModel> ConvertToModel(List<Permission> model)
        {
            List<PermissionModel> list = new List<PermissionModel>();
            foreach (Permission item in model)
            {
                list.Add(ConvertToModel(item));
            }
            return list;
        }
        public PermissionModel ConvertToModel(Permission model)
        {
            return new PermissionModel(model.Id, model.Code);
        }
        public PermissionViewModel ConvertToViewModel(Permission model)
        {
            return new PermissionViewModel(model.Id, model.Code, model.Name, model.Description, model.OwnerPermissionId, model.OwnerPermission.Name, model.PermissionGroupId, model.PermissionGroup.Name);
        }

    }
}
