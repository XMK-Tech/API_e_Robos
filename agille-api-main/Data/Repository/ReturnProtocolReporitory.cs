using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ReturnProtocolReporitory : GenericRepository<ReturnProtocol>, IReturnProtocolReporitory
{
    public ReturnProtocolReporitory(Context _context) : base(_context)
    {
    }
}