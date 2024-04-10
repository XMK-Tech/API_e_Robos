using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
namespace AgilleApi.Domain.Interfaces.Services;

public interface ICultureDeclarationServices
{
    IEnumerable<CultureDeclarationViewModel> List(CultureDeclarationParams @params);
    CultureDeclarationViewModel View(Guid id);
    void Insert(CultureDeclarationInsertUpdateViewModel model);
    void Update(Guid id, CultureDeclarationInsertUpdateViewModel model);
    void Delete(Guid id);
    void UpdateProprietyDeclarations(Guid taxprocedureId, string year, List<CultureDeclarationInsertUpdateManyViewModel> models);
    ReportResponseViewModel GenerateAgricultureReport(ReportIntervalViewModel interval);
    ReportResponseViewModel GenerateAnimalsReport(ReportIntervalViewModel interval);
    ReportResponseViewModel GenerateFishFarmsReport(ReportIntervalViewModel interval);
}