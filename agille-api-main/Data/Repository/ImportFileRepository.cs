using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
  public class ImportFileRepository : GenericRepository<ImportFile>, IImportFileRepository
  {
    public ImportFileRepository(Context _context) : base(_context)
    {
    }
  }
}
