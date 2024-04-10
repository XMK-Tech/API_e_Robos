using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Services;
public interface ITaxProcedureServices
{
    TaxProcedureViewModel View(Guid id);
    IEnumerable<TaxProcedureViewModel> GetAll(Metadata meta, TaxProcedureParams @params);
    TaxProcedureViewModel Insert(TaxProcedureInsertUpdateViewModelViewModel model);
    TaxProcedureViewModel Update(TaxProcedureInsertUpdateViewModelViewModel model, Guid id);
    void Delete(Guid id);
    bool Exist(Guid? id);
    TaxProcedureDashboard Dashboard();
    Task<byte[]> Print(TaxProcedureReportModel model);
    Task<byte[]> PrintLog(TaxProcedureReportLogModel model);
}