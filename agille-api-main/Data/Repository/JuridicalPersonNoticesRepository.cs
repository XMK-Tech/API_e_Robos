using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class JuridicalPersonNoticesRepository : GenericRepository<JuridicalPersonNotices>, IJuridicalPersonNoticesRepository
    {
        public JuridicalPersonNoticesRepository(Context _context) : base(_context)
        {
        }
    }
}
