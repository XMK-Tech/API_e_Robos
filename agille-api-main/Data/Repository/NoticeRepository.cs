using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository {
    public class NoticeRepository : GenericRepository<Notice>, INoticeRepository {
        public NoticeRepository(Context _context) : base(_context) { }
    }
}