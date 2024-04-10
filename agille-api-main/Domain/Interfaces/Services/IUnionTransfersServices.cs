using AgilleApi.Domain.Enums;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IUnionTransfersServices
{
    void ChangeStatus(UnionTransfersStatus status, Guid id);
    UnionTransfersDashboard Dashboard();
    void Delete(Guid id);
    UnionTransfersViewModel Insert(UnionTransfersInsertUpdateViewModel model);
    Task<byte[]> Print(UnionTransferReportModel model);
    UnionTransfersViewModel Update(UnionTransfersInsertUpdateViewModel model, Guid id);
    IEnumerable<UnionTransfersViewModel> View(UnionTransfersParams @params, Metadata meta);
    UnionTransfersViewModel View(Guid id);
}