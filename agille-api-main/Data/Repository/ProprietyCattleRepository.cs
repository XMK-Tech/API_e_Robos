using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ProprietyCattleRepository : GenericRepository<ProprietyCattle>, IProprietyCattleRepository
{
    public ProprietyCattleRepository(Context _context) : base(_context)
    {
    }
}