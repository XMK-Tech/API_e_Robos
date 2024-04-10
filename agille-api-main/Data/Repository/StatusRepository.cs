using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
  public class StatusRepository : GenericRepository<Status>, IStatusRepository
  {
        public StatusRepository(Context _context) : base(_context)
        {
        }
    }
}
