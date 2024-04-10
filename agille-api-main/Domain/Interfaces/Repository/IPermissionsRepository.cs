using AgilleApi.Domain.Entities;
using System.Linq;

namespace AgilleApi.Domain.Interfaces.Repository
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
    }
    public interface IPermissionGroupRepository : IGenericRepository<PermissionGroup>
    {

    }
    public interface IUserPermissionRepository : IGenericRepository<UserPermission>
    {

    }
}
