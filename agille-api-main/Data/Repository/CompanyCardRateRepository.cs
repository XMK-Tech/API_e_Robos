using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class CompanyCardRateRepository : GenericRepository<CompanyCardRate>, ICompanyCardRateRepository
{
    public CompanyCardRateRepository(Context _context) : base(_context)
    {
    }
}
