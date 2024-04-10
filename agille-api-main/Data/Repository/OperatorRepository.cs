using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class OperatorRepository : GenericRepository<Operator>, IOperatorRepository
    {
        public OperatorRepository(Context con) : base(con)
        {
        }
    }
}
