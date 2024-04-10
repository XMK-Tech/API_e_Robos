using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ChecklistRepository : GenericRepository<Checklist>, IChecklistRepository
{
    public ChecklistRepository(Context _context) : base(_context)
    {
    }
}