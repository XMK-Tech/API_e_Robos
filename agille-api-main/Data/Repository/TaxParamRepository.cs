using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class TaxParamRepository : GenericRepository<TaxParam>, ITaxParamRepository
{
    public TaxParamRepository(Context _context) : base(_context)
    {
    }
}