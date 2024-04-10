using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class CoordenateRepository : GenericRepository<Coordenate>, ICoordenateRepository
{
    public CoordenateRepository(Context _context) : base(_context)
    {
    }
}