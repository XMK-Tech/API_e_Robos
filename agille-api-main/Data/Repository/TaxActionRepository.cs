using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class TaxActionRepository : GenericRepository<TaxAction>, ITaxActionRepository
{
    public TaxActionRepository(Context _context) : base(_context)
    {
    }
}