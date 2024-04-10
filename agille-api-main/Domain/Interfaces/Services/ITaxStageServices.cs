using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ITaxStageServices
{
    TaxStageViewModel View(Guid id);
    void Insert(Guid procedureId, TaxStageInsertUpdateViewModel model);
    void Update(Guid id, TaxStageInsertUpdateViewModel model);
    void Delete(Guid id);
    void DeleteMany(List<TaxStage> stages);
    TaxStageViewModel ConvertToViewModel(TaxStage entity);
    List<TaxStageViewModel> ConvertToViewModel(IEnumerable<TaxStage> entities);
    Task<byte[]> ARTerm(TaxStageARViewModel model);
    Task<TaxStageARViewModel> CourierBaseAddress(Guid taxStageId);
    Task<byte[]> ForwardTerm(TaxStageForwardingTermViewModel model);
    Task<byte[]> JoinTerm(TaxStageJoinTermViewModel model);
    void InsertReply(Guid taxStageId, TaxStageReplyInsertViewModel model);
}