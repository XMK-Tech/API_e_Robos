using AgilleApi.Domain.Services.Commom;
using System;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ISessionServices
{
    SessionData GetCurrentSession();
    Guid? GetUserId();
    string RemoteIpAddress();
    Guid GetTenantId();
}