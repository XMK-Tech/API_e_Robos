using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class CrawlerFileRepository : GenericRepository<CrawlerFile>, ICrawlerFileRepository
{
    public CrawlerFileRepository(Context _context) : base(_context)
    {
    }
}