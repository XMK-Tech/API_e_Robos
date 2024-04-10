using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
  public class ParamRepository : GenericRepository<Param>, IParamRepository
    {
        public ParamRepository(Context _context) : base(_context)
        {
        }
    }
}
