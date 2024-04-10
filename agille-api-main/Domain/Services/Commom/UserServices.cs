using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom
{
    public class UserServices : Notifications
    {
        private readonly IUserRepository _repository;
        private readonly ITemplateProfilePermissionsRepository _templateProfilePermissionsRepository;
        private readonly PermissionServices _userPermissionServices;
        private readonly EmailServices _emailServices;

        public UserServices(IUserRepository repository, PermissionServices userPermissionServices, EmailServices emailServices, ITemplateProfilePermissionsRepository templateProfilePermissionsRepository)
        {
            _repository = repository;
            _templateProfilePermissionsRepository = templateProfilePermissionsRepository;

            _emailServices = emailServices;
            _userPermissionServices = userPermissionServices;
            ValidationMessages = _emailServices.ValidationMessages;
            ValidationMessages = _userPermissionServices.ValidationMessages;
        }

        /// <summary>
        /// Esse metodo só deve ser Utilizado para Testes
        /// </summary>
        /// <returns>Guid: Id do Usuário Administrador</returns>
        public Guid AdminId()
        {
            return _repository.Get(x => x.Username.Contains("Admin")).FirstOrDefault().Id;
        }

        public List<UserListViewModel> List(Metadata metadata)
        {
            try
            {
                IQueryable<User> query = _repository.Query().AsQueryable();

                Expression<Func<User, Object>> sort = x => x.Username;
                if (String.IsNullOrEmpty(metadata.SortColumn))
                {
                    sort = e => e.Username;
                    metadata.SortColumn = "Username";
                }

                if (metadata.SortDirection.ToLower() == "asc")
                    query = query.OrderBy(sort);
                if (metadata.SortDirection.ToLower() == "desc")
                    query = query.OrderByDescending(sort);

                List<UserListViewModel> users = ConvertToViewModel(_repository.ExecuteQuery(query, metadata));

                if (users == null || users.Count == 0)
                {
                    ValidationMessages.Add("None user was found");
                    return null;
                }

                return users;
            }
            catch (Exception ex)
            {
                StatusCode = 500;
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }
        public Guid? Insert(UserViewModel model, Guid personId, string password = null)
        {
            try
            {

                Email modelEmail = _emailServices.Insert(model.Email);

                User entity = ConvertToEntity(personId, modelEmail.Id, model, password: password);
                if (entity == null)
                {
                    ValidationMessages.Add("Fail to find the entity");
                    return null;
                }

                entity = _repository.Insert(entity);
                List<Guid> Permissions = new List<Guid>();

                if (model.CustomPermissions)
                {
                    Permissions = model.Permissions;
                }

                else if (model.ProfileId != Guid.Empty && model.ProfileId != null)
                {
                    Permissions.Clear();
                    Permissions.AddRange(_templateProfilePermissionsRepository
                      .Get(x => x.ProfileId == model.ProfileId)
                      .Select(x => x.PermissionId)
                      .ToList());
                }
                if (Permissions?.Count > 0)
                    _userPermissionServices.Insert(Permissions, entity.Id);

                return entity.Id;
            }
            catch (Exception ex)
            {
                StatusCode = 500;
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }

        public void SetTokenPushNotifications(SetTokenPushNotificationsViewModel viewModel)
        {
            User entity = _repository.GetById(viewModel.Id);

            if (entity == null)
            {
                ValidationMessages.Add("User not found!");
                StatusCode = 400;
                return;
            }

            entity.TokenPushNotifications = viewModel.Token;

            _repository.Update(entity);
        }

        public void Update(UserViewModel model, Guid personId)
        {
            try
            {
                User entity = _repository.Get(e => e.PersonId == personId).FirstOrDefault();
                if (entity == null)
                {
                    ValidationMessages.Add("User not found!");
                    StatusCode = 400;
                    return;
                }

                _emailServices.Update(entity.EmailId, model.Email);
                entity = ConvertToEntity(personId, entity.EmailId, model, entity);
                if (entity == null)
                {
                    ValidationMessages.Add("Fail to find the entity");
                    return;
                }

                _repository.Update(entity);

                List<Guid> Permissions = new List<Guid>();

                _userPermissionServices.Insert(Permissions, entity.Id);

                if (model.CustomPermissions)
                {
                    Permissions = model.Permissions.ToList();
                }
                else if (model.ProfileId != Guid.Empty && model.ProfileId != null)
                {
                    _userPermissionServices.Delete(entity.Id);
                    Permissions.Clear();
                    Permissions.AddRange(_templateProfilePermissionsRepository
                      .Get(x => x.ProfileId == model.ProfileId)
                      .Select(x => x.PermissionId)
                      .ToList());
                }
                if (Permissions?.Count > 0)
                    _userPermissionServices.Update(Permissions, entity.Id);
            }
            catch (Exception ex)
            {
                StatusCode = 500;
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void UpdateStatusByPersonId(bool status, Guid person_id)
        {
            try
            {
                User user = _repository.Get(e => e.PersonId == person_id).FirstOrDefault();
                if (user == null)
                    return;

                user.Status = status;
                _repository.Update(user);

            }
            catch (Exception ex)
            {
                StatusCode = 500;
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public UserViewModel View(Guid UserId)
        {
            try
            {
                User User = _repository.Query().Include(x => x.Email).Include(x => x.UserPermissions).FirstOrDefault(x => x.Id == UserId);
                if (User == null)
                {
                    ValidationMessages.Clear();
                    ValidationMessages.Add("User not found!");
                    StatusCode = 400;
                }

                return ConvertToViewModel(User);
            }
            catch (Exception ex)
            {
                StatusCode = 500;
                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
                return null;
            }
        }
        public void Delete(Guid UserId)
        {
            try
            {
                User User = _repository.GetById(UserId);
                if (User == null)
                {
                    ValidationMessages.Clear();
                    ValidationMessages.Add("User not found!");
                    StatusCode = 400;
                    return;
                }

                User.Status = false;
                _repository.Update(User);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public void DeleteManyByPersonId(Guid personId)
        {
            try
            {
                List<User> users = _repository.Get(e => e.PersonId == personId).ToList();
                if (users.Any())
                    _repository.DeleteMany(users);
            }
            catch (Exception ex)
            {
                StatusCode = 500;

                ValidationMessages.Add(ex.Message);
                if (ex.InnerException != null)
                    ValidationMessages.Add(ex.InnerException.Message);
            }
        }
        public bool Exists(string userName)
        {
            return _repository.Get(e => e.Username.Equals(userName)).Any();
        }
        public List<UserListViewModel> ConvertToViewModel(List<User> model)
        {
            List<UserListViewModel> result = new List<UserListViewModel>();
            if (model == null) return result;

            foreach (User item in model)
            {
                result.Add(new UserListViewModel(item.ProfileId, item.Username, item.Email != null ? item.Email.Value : null, item.PersonId, item.CustomPermissions, item.Status));
            }
            return result;
        }
        public UserViewModel ConvertToViewModel(User model)
        {
            if (model == null) return null;
            UserViewModel viewModel = new UserViewModel(model.Username, model.Email?.Value, model.ProfileId, model.UserPermissions?.Select(e => e.PermissionId).ToList(), model.CustomPermissions);
            return viewModel;
        }
        private User ConvertToEntity(Guid personId, Guid email_Id, object viewModel, User entity = null, string password = null)
        {
            if (entity == null)
            {
                UserViewModel model = ((UserViewModel)viewModel);
                User entityUser = new User(personId, model.ProfileId, model.Username, email_Id, model.CustomPermissions, password);
                return entityUser;
            }
            else
            {
                UserViewModel model = ((UserViewModel)viewModel);
                entity.ProfileId = model.ProfileId;
                entity.Username = model.Username;
                entity.EmailId = email_Id;
                entity.CustomPermissions = model.CustomPermissions;
                return entity;
            }
        }
    }
}
