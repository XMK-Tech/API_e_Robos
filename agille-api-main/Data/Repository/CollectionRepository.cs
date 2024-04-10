using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class CollectionRepository : GenericRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(Context _context) : base(_context)
    {
    }
}

public class CollectionAttachmentRepository : GenericRepository<CollectionAttachment>, ICollectionAttachmentRepository
{
    public CollectionAttachmentRepository(Context _context) : base(_context)
    {
    }
}