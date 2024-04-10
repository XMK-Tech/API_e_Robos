using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class RubricRepository : GenericRepository<Rubric>, IRubricRepository
{ 
    public RubricRepository(Context _context) : base(_context)
    {
    }
}

public class RubricAccountRepository : GenericRepository<RubricAccount>, IRubricAccountRepository
{
    public RubricAccountRepository(Context _context) : base(_context)
    {
    }
}