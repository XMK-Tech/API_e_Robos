using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class RelatedEntityRepository : GenericRepository<RelatedEntity>, IRelatedEntityRepository
{
    public RelatedEntityRepository(Context _context) 
        : base(_context)
    {
    }
}