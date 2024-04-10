using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IRubricServices
{
    IEnumerable<RubricViewModel> List(Metadata meta, RubricParams @params);
    IEnumerable<RubricAccountViewModel> ListAccounts(Guid rubricId, Metadata meta);
    RubricViewModel View(Guid id);
    void Insert(RubricInsertUpdateViewModel model);
    void Update(Guid id, RubricInsertUpdateViewModel model);
    IQueryable<RubricAccount> GetQueryForYear(string year);
    void Delete(Guid id);
    void DeleteAccount(Guid rubricAccountId);
}