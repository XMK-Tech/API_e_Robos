using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class ServerRepository : GenericRepository<Server>, IServerRepository
    {
        public ServerRepository(Context con) : base(con)
        {
        }
    }
}
