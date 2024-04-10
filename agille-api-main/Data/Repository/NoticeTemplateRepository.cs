using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
  public class NoticeTemplateRepository : GenericRepository<NoticeTemplate>, INoticeTemplateRepository
  {
        public NoticeTemplateRepository(Context _context) : base(_context)
        {
        }
    }
}
