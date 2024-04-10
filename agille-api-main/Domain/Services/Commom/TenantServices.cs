using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;

namespace AgilleApi.Domain.Services.Commom
{
    public class TenantServices : ITenantServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetId()
        {
            var tenant = _httpContextAccessor.HttpContext.Request.Headers["tenantId"];

            if (string.IsNullOrEmpty(tenant))
                throw new NotFoundException("A identificação da entidade não foi encontrada.");

            return new Guid(tenant);
        }
    }
}
