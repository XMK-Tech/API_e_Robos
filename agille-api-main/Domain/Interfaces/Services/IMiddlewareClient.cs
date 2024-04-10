using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IMiddlewareClient
{
    List<UserInfoViewModel> GetUserInfos(List<Guid> list);
    T GetParsedResponse<T>(string url);
}