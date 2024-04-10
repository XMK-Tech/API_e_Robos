using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class UnionTransfersRepository : GenericRepository<UnionTransfers>, IUnionTransfersRepository
{
    public UnionTransfersRepository(Context _context) : base(_context)
    {
    }
}