using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Interfaces.Repository;

public interface ITaxStageRepository : IGenericRepository<TaxStage>
{ }

public interface ITaxStageAttachmentRepository : IGenericRepository<TaxStageAttachment>
{ }