using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class TaxpayerRepository : GenericRepository<Taxpayer>, ITaxpayerRepository
    {
        public TaxpayerRepository(Context _context) : base(_context)
        {

        }
    }
}
