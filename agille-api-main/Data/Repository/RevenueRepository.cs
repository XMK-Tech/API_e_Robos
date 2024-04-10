using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class RevenueRepository : GenericRepository<Revenue>, IRevenueRepository
{
    public RevenueRepository(Context _context) : base(_context)
    {
    }
}