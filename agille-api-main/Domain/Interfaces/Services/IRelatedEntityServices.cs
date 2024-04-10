using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IRelatedEntityServices
{
    IEnumerable<RelatedEntityViewModel> List(Metadata meta, RelatedEntityParams @params);
    RelatedEntityViewModel View(Guid id);
    void Insert(RelatedEntityInsertUpdateViewModel model);
    void Update(Guid id, RelatedEntityInsertUpdateViewModel model);
    void Delete(Guid id);
    Guid? FindIdByName(string name);
}