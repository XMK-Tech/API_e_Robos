using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Data.Repository
{
  public class MessageRepository : GenericRepository<MessageQueue>, IMessageRepository
  {
    public MessageRepository(Context context) : base(context)
    {
    }
  }
}
