using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class FPMLaunchRepository : GenericRepository<FPMLaunch>, IFPMLaunchRepository
{
    public FPMLaunchRepository(Context _context) : base(_context)
    {
    }
}