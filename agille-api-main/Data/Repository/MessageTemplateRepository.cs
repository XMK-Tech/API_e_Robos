using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
  public class MessageTemplateRepository : GenericRepository<MessageTemplate>, IMessageTemplateRepository
  {
    public MessageTemplateRepository(Context _context) : base(_context)
    {
    }
  }
}
