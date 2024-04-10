using AgilleApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AgilleApi.Domain.Services.Commom;

public class SessionServices : Notifications, ISessionServices
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionServices(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public SessionData GetCurrentSession()
    {
        var user = GetUser();
        var userId = user?.FindFirst("user_id")?.Value;

        if (user == null || userId == null)
            return null;

        var franchises = user
            .FindAll("franchise_id")
            .Select(claim => Guid.Parse(claim.Value));

        var contracts = user
            .FindAll("entity_id")
            .Select(claim => Guid.Parse(claim.Value));

        return new()
        {
            UserId = Guid.Parse(userId),
            FranchiseIds = franchises?.ToList(),
            EntityIds = contracts?.ToList()
        };
    }

    public Guid? GetUserId()
    {
        var user = GetUser();
        var userId = user?.FindFirst("user_id")?.Value;

        _ = Guid.TryParse(userId, out Guid response);

        return response;
    }

    public string RemoteIpAddress()
    {
        return _httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
    }

    private ClaimsPrincipal GetUser()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        return httpContext?.User;
    }

    public Guid GetTenantId()
    {
        var idAsString = _httpContextAccessor?.HttpContext?.Request?.Headers["TenantId"];
        return ParseGuid(idAsString);
    }
    private static Guid ParseGuid(string idAsString)
    {
        return !string.IsNullOrEmpty(idAsString) ? Guid.Parse(idAsString) : Guid.Empty;
    }
}

public class SessionData
{
    public Guid UserId { get; set; }
    public List<Guid> FranchiseIds { get; set; }
    public List<Guid> EntityIds { get; set; }
}