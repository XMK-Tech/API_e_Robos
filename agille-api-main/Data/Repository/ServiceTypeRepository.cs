using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ServiceTypeRepository : GenericRepository<ServiceType>, IServiceTypeRepository
{
    public ServiceTypeRepository(Context _context) : base(_context)
    {
    }
}