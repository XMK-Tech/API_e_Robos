using System;
using System.Collections.Generic;
using AgilleApi.Domain.ViewModel;

namespace AgilleApi.Domain.Interfaces.Services
{
    public interface IPermissionManagerServices
    {
        bool HasPermission(params string[] permissionsName);
        List<UserPermissionViewModel> ListByUserId(Guid? userId);
    }
}