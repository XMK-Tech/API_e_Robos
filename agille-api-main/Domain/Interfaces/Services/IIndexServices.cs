using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IIndexServices
{
    IEnumerable<IndexViewModel> List(Metadata meta, IndexParams @params);
    IEnumerable<IndexViewModel> ListLastDeclarations(Metadata meta);
    IndexViewModel View(Guid id);
    void Insert(IndexViewModel model);
    void Update(Guid id, IndexViewModel model);
    void Delete(Guid id);
    decimal GetSelicRate(string year, string month);
}