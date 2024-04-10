using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace TelLink.API.Implemantation.Services
{
    public class EnforcePermissionAttribute : TypeFilterAttribute
    {
        public EnforcePermissionAttribute(params string[] permissions) : base(typeof(RequirementPermissionsFilter))
        {
            Arguments = new object[] { permissions };
        }
    }
    public class RequirementPermissionsFilter : IAuthorizationFilter
    {
        private readonly string[] _permissions;
        private readonly IPermissionManagerServices _permissionManagerServices;

        public RequirementPermissionsFilter(IPermissionManagerServices permissionManagerServices, string[] permissions)
        {
            _permissionManagerServices = permissionManagerServices;
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_permissionManagerServices.HasPermission(_permissions))
            {
                var result = new Result<WithOutContent>(401, UnauthorizedException.BuildExceptionPermission(_permissions));
                context.Result = new UnauthorizedObjectResult(result);
                return;
            }
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequirementClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
    public class RequirementClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequirementClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.UserClaimValidation(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
    public class CustomAuthorization
    {
        public static bool UserClaimValidation(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                         context.User.Claims.Any(c => c.Type == claimName && c.Value.Split(',').Contains(claimValue));
        }

    }
}
