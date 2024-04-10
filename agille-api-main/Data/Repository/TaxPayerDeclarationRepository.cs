using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class TaxPayerDeclarationRepository : GenericRepository<TaxPayerDeclaration>, ITaxPayerDeclarationRepository
{
    public TaxPayerDeclarationRepository(Context _context) : base(_context)
    {
    }
}