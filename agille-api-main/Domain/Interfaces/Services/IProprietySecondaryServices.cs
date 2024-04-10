using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IProprietySecondaryServices
{
    ReportResponseViewModel AreaReport(ProprietyAreaReportFilterViewModel model);
    List<ProprietyOwners> CreateOwnerProprieties(Guid ownerId, List<Guid> proprieties);
    Dictionary<string, Guid> GetProprietyIds(List<string> cibs);
    IEnumerable<ShortProprietyViewModel> ProprietiesByOwnerId(Guid ownerId);
    bool ProprietyExist(Guid? id);
    void SetOwnerProprieties(Guid ownerId, List<Guid> proprieties);
}