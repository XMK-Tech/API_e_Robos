using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Services.Commom
{
    public class PermissionManagerMiddlewareServices : Notifications, IPermissionManagerServices
    {
        private readonly ISessionServices _sessionServices;
        private readonly IMiddlewareClient _middlewareServices;

        public PermissionManagerMiddlewareServices(ISessionServices sessionServices, IMiddlewareClient middlewareServices)
        {
            _sessionServices = sessionServices;
            _middlewareServices = middlewareServices;
        }

        public bool HasPermission(params string[] permissionsName)
        {
            var userId = _sessionServices.GetUserId();
            string urlEntity = BuildUrlEntity(_sessionServices.GetTenantId());
            string urlPermission = BuildUrlPermission(permissionsName);

            var resultDynamic = _middlewareServices.GetParsedResponse<dynamic>
                ($"Permission/HasPermission?UserId={userId}&{urlEntity}{urlPermission}");
            var result = JsonConvert.DeserializeObject<ExistsViewModel>(resultDynamic.content.data.ToString());
            return result.Exist;
        }
        private static string BuildUrlEntity(Guid entityId)
        {
            return $"EntityId={entityId}&";
        }
        private static string BuildUrlPermission(string[] permissionsName)
        {
            string urlPermission = "";
            for (var i = 0; i < permissionsName.Length; i++)
                urlPermission += $"PermissionName={permissionsName[i]}&";
            return urlPermission;
        }

        public List<UserPermissionViewModel> ListByUserId(Guid? userId)
        {
            if (userId.GuidIsInvalid())
                return new();

            List<UserPermissionViewModel> results = _middlewareServices.GetParsedResponse<List<UserPermissionViewModel>>
                ($"api/v1/Permission/ListByUserId?userId={userId}");

            return results;
        }
    }
}
