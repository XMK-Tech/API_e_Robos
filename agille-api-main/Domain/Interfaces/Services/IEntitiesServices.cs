using AgilleApi.Domain.ViewModel;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IEntitiesServices
{
    void Patch(EntitiesViewModel model);
    EntitiesViewModel View();
    decimal GetAliquot();
    string GetBase64Image();
    string GetCityName();
    List<string> GetAgiprevDocuments();
}