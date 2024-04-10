using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IAgiprevCrawlerServices
{
    List<T> Import<T>(DateTime competence);
}