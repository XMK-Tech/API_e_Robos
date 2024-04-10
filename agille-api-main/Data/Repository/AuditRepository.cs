using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class AuditRepository : GenericRepository<Audit>, IAuditRepository
{
    public AuditRepository(Context _context) : base(_context)
    {
    }
}