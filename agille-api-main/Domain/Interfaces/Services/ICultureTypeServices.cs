using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ICultureTypeServices
{
    IEnumerable<CultureTypeViewModel> List(CultureTypeParams @params);
    CultureTypeViewModel View(Guid id);
    void Insert(CultureTypeInsertUpdateViewModel model);
    void Update(Guid id, CultureTypeInsertUpdateViewModel model);
    void Delete(Guid id);
    bool Exists(Guid? id);
    void UpdateCheckState(List<CultureTypeUpdateCheckStateViewModel> models);
}