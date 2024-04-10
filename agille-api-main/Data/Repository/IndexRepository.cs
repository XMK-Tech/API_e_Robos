using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class IndexRepository : GenericRepository<Index>, IIndexRepository
{
    public IndexRepository(Context _context) : base(_context)
    {
    }
}