using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(Context _context) : base(_context)
    {
    }
}