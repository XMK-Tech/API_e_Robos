using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class CultureTypeRepository : GenericRepository<CultureType>, ICultureTypeRepository
{ 
    public CultureTypeRepository(Context _context) : base(_context)
    {
    }
}