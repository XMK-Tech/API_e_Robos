using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ServiceTypeDescriptionRepository : GenericRepository<ServiceTypeDescription>, IServiceTypeDescriptionRepository
{
    public ServiceTypeDescriptionRepository(Context _context) : base(_context)
    {
    }
}