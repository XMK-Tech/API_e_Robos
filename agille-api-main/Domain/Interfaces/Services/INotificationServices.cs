using AgilleApi.Domain.ViewModel;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface INotificationServices
{
    IEnumerable<NotificationViewModel> InsertMany(NotificationInsertViewModel model);
}