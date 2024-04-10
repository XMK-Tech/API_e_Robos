using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ChecklistAttachmentRepository : GenericRepository<ChecklistAttachment>, IChecklistAttachmentRepository
{
    public ChecklistAttachmentRepository(Context _context) : base(_context)
    {
    }
}