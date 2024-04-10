using BaseSystem.Data.ContextDb;
using BaseSystem.Domain.Entities;
using BaseSystem.Domain.Interfaces.Repository;

namespace BaseSystem.Data.Repository
{
  public class MessageTemplateDynamicFieldsRepository : GenericRepository<MessageTemplateDynamicFields>, IMessageTemplateDynamicFieldsRepository
  {
    public MessageTemplateDynamicFieldsRepository(Context _context) : base(_context)
    {
    }
  }
}
