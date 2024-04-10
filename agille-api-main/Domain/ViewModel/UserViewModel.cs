using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel
{
    public class UserSignInParam
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UserSignInViewModel
    {
        public UserSignInViewModel(string token, List<string> permissions)
        {
            Token = token;
            Permissions = permissions;
        }

        public string Token { get; set; }
        public List<string> Permissions { get; set; }
    }
    public class SetTokenPushNotificationsViewModel
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
    }
    public class SetPasswordViewModel
    {
        public string TokenPushNotifications { get; set; }
        public string SetPasswordToken { get; set; }
        public string Password { get; set; }
    }
    public class RecoverPasswordViewModel
    {
        public string Email { get; set; }
    }

    public class UserParams
    {
        public Guid ProfileId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Guid PersonId { get; set; }
        public bool CustomPermissions { get; set; }
        public bool Status { get; set; }
        public string Permissions { get; set; }
    }

    public class UserListViewModel
    {
        public UserListViewModel(Guid profileId, string username, string email, Guid personId, bool customPermissions, bool status)
        {
            ProfileId = profileId;
            Username = username;
            Email = email;
            PersonId = personId;
            CustomPermissions = customPermissions;
            Status = status;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public Guid ProfileId { get; set; }
        public Guid PersonId { get; set; }
        public bool CustomPermissions { get; set; }
        public bool Status { get; set; }
    }

    public class UserViewModel
    {
        public UserViewModel()
        {

        }
        public UserViewModel(string username, string email, Guid profileId, List<Guid> permissions, bool customPermissions)
        {
            Username = username;
            Email = email;
            ProfileId = profileId;
            Permissions = permissions;
            CustomPermissions = customPermissions;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public Guid ProfileId { get; set; }
        public List<Guid> Permissions { get; set; }
        public bool CustomPermissions { get; set; }
    }

    public class MiddlewareUserInsertViewModel
    {
        public Guid? UserId { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public List<MiddlewarePermissionViewTemplate> Permissions { get; set; }
        public List<Guid> Entities { get; set; }
    }
    public class DefaultPermissionPostViewModel
    {
        public DefaultPermissionPostViewModel(DefaultPermissionType permissionType, bool isGlobal)
        {
            PermissionType = permissionType;
            IsGlobal = isGlobal;
        }

        public DefaultPermissionType PermissionType { get; set; }
        public bool IsGlobal { get; set; }
        public Guid UserId { get; set; }
    }
    public class MiddlewarePermissionViewTemplate
    {
        public MiddlewarePermissionViewTemplate(string name, Guid? entity, Guid? franchise, bool isGlobal = false)
        {
            PermissionName = name;
            PermissionEntity = entity;
            PermissionFranchise = franchise;
            IsGlobal = isGlobal;
        }

        public string PermissionName { get; set; }
        public Guid? PermissionEntity { get; set; }
        public Guid? PermissionFranchise { get; set; }
        public bool IsGlobal { get; set; }
    }

    public class MiddlewareUserIdViewModel
    {
        public Guid? Id { get; set; }
        public List<string> Messages { get; set; }
    }
}