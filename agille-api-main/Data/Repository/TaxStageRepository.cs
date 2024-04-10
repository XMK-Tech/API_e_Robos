using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class TaxStageRepository : GenericRepository<TaxStage>, ITaxStageRepository
{
    public TaxStageRepository(Context _context) : base(_context)
    {
    }
}

public class TaxStageAttachmentRepository : GenericRepository<TaxStageAttachment>, ITaxStageAttachmentRepository
{ 
    public TaxStageAttachmentRepository(Context _context) : base(_context)
    {
    }
}