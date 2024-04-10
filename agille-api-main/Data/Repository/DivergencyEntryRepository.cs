using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
  public class DivergencyEntryRepository : GenericRepository<DivergencyEntry>, IDivergencyEntryRepository
  {
    public DivergencyEntryRepository(Context _context) : base(_context)
    {
    }
  }
}
