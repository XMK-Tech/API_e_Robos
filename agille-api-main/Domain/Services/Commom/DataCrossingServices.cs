using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Domain.Services.Commom;

public class DataCrossingServices : SessionServices
{
    private readonly IDataCrossingRepository _repository;
    private readonly DivergencyEntryServices _divergencyEntryServices;
    private readonly MiddlewareClient _middlewareServices;
    private readonly INotificationServices _notificationServices;

    public DataCrossingServices(IDataCrossingRepository repository, IHttpContextAccessor accessor,
         DivergencyEntryServices divergencyEntryServices, MiddlewareClient middlewareServices, 
         INotificationServices notificationServices)
        : base(accessor)
    {
        _repository = repository;
        _divergencyEntryServices = divergencyEntryServices;
        _middlewareServices = middlewareServices;
        _notificationServices = notificationServices;
    }

    public void Insert(DataCrossingInsertUpdateViewModel model)
    {
        var userId = GetCurrentSession().UserId;
        var entity = new DataCrossing(DataCrossingStatus.Pending, model.StartingReference, model.EndingReference, userId);

        _repository.Insert(entity);

        //TODO: Remove this line. It is being called for testing purposes
        _repository.ExecuteAllPeding();

        _notificationServices.InsertMany(new NotificationInsertViewModel()
        {
            UserIds = new List<Guid>() { GetCurrentSession().UserId },
            Title = "Cruzamento de dados realizado com sucesso",
            Message = "Clique para verificar",
            Link = "",
            Priority = NotificationPriority.Normal,
        });

        return;
    }

    public BaseInterval GetDataCrossInterval(Guid id)
    {
        var data = _repository.GetById(id);
        if (data == null)
            return null;

        return new BaseInterval() { StartingReference = data.StartingReference, EndingReference = data.EndingReference };
    }

    public IEnumerable<DataCrossingViewModel> GetAll(Metadata meta)
    {
        var query = _repository
                     .Query()
                     .Include(i => i.DivergencyEntries)
                     .OrderByDescending(x => x.CreatedAt);

        var result = _repository.ExecuteQuery(query, meta);
        var userIds = result
                    .Where(e => e.ResponsibleId != null)
                    .Select(e => (Guid)e.ResponsibleId)
                    .ToList();

        List<UserInfoViewModel> userInfos = _middlewareServices.GetUserInfos(userIds);

        return result.Select(c => ConvertToViewModel(c, userInfos));
    }

    private static DataCrossingViewModel ConvertToViewModel(DataCrossing i, List<UserInfoViewModel> infoViewModels)
    {
        return new DataCrossingViewModel()
        {
            EndingReference = i.EndingReference,
            Id = i.Id,
            StartingReference = i.StartingReference,
            Status = i.Status,
            ResponsibleId = i.ResponsibleId,
            ResponsibleName = infoViewModels.FirstOrDefault(e => e.UserId == i.ResponsibleId)?.Fullname,
            DivergencyCount = i.DivergencyEntries.Count(i => i.Difference > 0),
            HasInvalidDivergences = i.DivergencyEntries.Any(i => i.IsInvalid),
        };
    }

    public DivergencysDataViewModel GetDivergencyCount(GetEntriesViewModel model, Metadata meta)
    {
        return _divergencyEntryServices.GetDivergencysCount(model, meta);
    }

    public IEnumerable<DataCrossingEntryViewModel> GetEntries(Guid id)
    {
        return _divergencyEntryServices.GetByCrossing(id);
    }
}