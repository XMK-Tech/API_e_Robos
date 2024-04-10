using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel
{
    public class PermissionViewModel
    {
        public PermissionViewModel(Guid id, string code, string name, string description, Guid owner_permission_id, string owner_permission_Name, Guid? permission_group_id, string permission_group_Name)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Owner_permission_id = owner_permission_id;
            Owner_permission_Name = owner_permission_Name;
            Permission_group_id = permission_group_id;
            Permission_group_Name = permission_group_Name;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Owner_permission_id { get; set; }
        public string Owner_permission_Name { get; set; }
        public Guid? Permission_group_id { get; set; }
        public string Permission_group_Name { get; set; }
    }
    public class PermissionViewListModel
    {
        public PermissionViewListModel(string code, string name, string description, Guid id)
        {
            Code = code;
            Name = name;
            Description = description;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class PermissionModel
    {
        public PermissionModel(Guid id, string code)
        {
            Id = id;
            Code = code;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
    }

    public class UserPermissionViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool IsProfile { get; set; }
    }
    public class ExistsViewModel
    {
        public bool Exist { get; set; }
    }
}
