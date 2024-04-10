using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly Context _con;

        public PermissionRepository(Context con) : base(con)
        {
            _con = con;
        }
    }
    public class PermissionGroupRepository : GenericRepository<PermissionGroup>, IPermissionGroupRepository
    {
        private readonly Context _con;

        public PermissionGroupRepository(Context con) : base(con)
        {
            _con = con;
        }
    }

    public class UserPermissionRepository : GenericRepository<UserPermission>, IUserPermissionRepository
    {
        private readonly Context _con;

        public UserPermissionRepository(Context con) : base(con)
        {
            _con = con;
        }
    }
}
