using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class TaxProcedureRepository : GenericRepository<TaxProcedure>, ITaxProcedureRepository
{
    public TaxProcedureRepository(Context _context) : base(_context)
    {
    }
}
