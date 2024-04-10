using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Data.Repository
{
  public class DataCrossingRepository : GenericRepository<DataCrossing>, IDataCrossingRepository
  {
    public DataCrossingRepository(Context _context) : base(_context)
    {
    }

    public void ExecuteAllPeding() {
      this.context.Database.ExecuteSqlRaw("UpdateDataCrossing");
    }
  }
}
