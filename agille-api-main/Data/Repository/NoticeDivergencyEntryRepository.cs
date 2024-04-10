using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository {
    public class NoticeDivergencyEntryRepository : GenericRepository<NoticeDivergencyEntry>, INoticeDivergencyEntryRepository {
        public NoticeDivergencyEntryRepository(Context _context) : base(_context) { }
    }
}