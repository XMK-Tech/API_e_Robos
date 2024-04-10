using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
  public class DynamicFieldsRepository : GenericRepository<DynamicFieldOptions>, IDynamicFieldsRepository
  {
    public DynamicFieldsRepository(Context _context) : base(_context)
    {
    }
  }
}
