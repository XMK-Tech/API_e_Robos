using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel(Guid id, Guid juridicalPersonId, string juridicalPersonName, string description, string name)
        {
            Id = id;
            JuridicalPersonId = juridicalPersonId;
            JuridicalPersonName = juridicalPersonName;
            Description = description;
            Name = name;
        }

        public Guid Id { get; set; }
        public Guid JuridicalPersonId { get; set; }
        public string JuridicalPersonName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public List<EmployeeViewModel> Employeers { get; set; } = new List<EmployeeViewModel>();
        public List<EmployeeViewModel> DepartmentManagers { get; set; } = new List<EmployeeViewModel>();
    }

    public class DepartmentListParams
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JuridicalPersonName { get; set; }
        public string DepartmentManagerName { get; set; }
        public string EmployeerName { get; set; }

    }

    public class DepartmentIncludeViewModel
    {

        [Required]
        public Guid? JuridicalPersonId { get; set; }
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Guid> DepartmentManagers { get; set; } = new List<Guid>();
        public List<Guid> Employeers { get; set; } = new List<Guid>();
    }

    public class DepartmentExcludeViewModel
    {
        public Guid? Id { get; set; }
        public DeparmentExcludeType? ExcludeOption { get; set; }
        public Guid? NewDepartment { get; set; }

        public bool FilledFields()
        {
            return (
                (Id == null || Id == Guid.Empty) ||
                ExcludeOption == null ||
                (ExcludeOption == DeparmentExcludeType.ExcludeAndMoveDataToNewDepartment && (NewDepartment == null || NewDepartment == Guid.Empty)));
        }
    }

    public class DepartmentUpdateViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid? JuridicalPersonId { get; set; }
        public List<Guid> Employeers { get; set; }
        public List<Guid> DepartmentManagers { get; set; }
    }

    public class DepartmentListViewModel
    {
        public DepartmentListViewModel(Guid id, string name, string companyName, int departmentManagersTotal, int emplooyesTotal)
        {
            Id = id;
            Name = name;
            DepartmentManagersTotal = departmentManagersTotal;
            EmplooyesTotal = emplooyesTotal;
            JuridicalPersonName = companyName;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string JuridicalPersonName { get; set; }
        public List<ManagerEmployeeViewModelResult> DepartmentManagers { get; set; } = new List<ManagerEmployeeViewModelResult>();
        public int DepartmentManagersTotal { get; set; }
        public int EmplooyesTotal { get; set; }

    }

    public class ManagerEmployeeViewModelResult
    {
        public ManagerEmployeeViewModelResult(string displayName, string profilePicUrl, string profileName)
        {
            DisplayName = displayName;
            ProfilePicUrl = profilePicUrl;
            ProfileName = profileName;
        }

        public string DisplayName { get; set; }
        public string ProfilePicUrl { get; set; }
        public string ProfileName { get; set; }
    }
}
