using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AgilleApi.Domain.Services.Commom;

public class NotificationServices : SessionServices, INotificationServices
{
    private readonly INotificationRepository _repository;
    private readonly MiddlewareClient _middlewareClient;

    public NotificationServices(INotificationRepository repository, MiddlewareClient middlewareClient, IHttpContextAccessor httpContentAcessor)
        : base(httpContentAcessor)
    {
        _repository = repository;
        _middlewareClient = middlewareClient;
    }

    public IEnumerable<NotificationViewModel> View(Metadata meta)
    {
        var notifications = _repository.ExecuteQuery(GetAll(), meta);
        return notifications.Select(ConvertToViewModel);
    }

    public IEnumerable<NotificationViewModel> SessionView(Metadata meta)
    {
        var userId = GetCurrentSession()?.UserId;
        ThrowIfNull(userId, "Session");

        var query = GetAll()
                     .Where(e => e.UserId == userId);

        var notifications = _repository.ExecuteQuery(query, meta).OrderByDescending(e => e.CreatedAt);
        return notifications.Select(ConvertToViewModel);
    }

    public NotificationViewModel View(Guid id)
    {
        var notification = Get(id);
        ThrowIfNull(notification, "Notification");

        return ConvertToViewModel(notification);
    }

    public IEnumerable<NotificationViewModel> InsertMany(NotificationInsertViewModel model)
    {
        var ids = model.UserIds.ToList();
        return ids.Select(item => InsertOne(model, item)).ToList();
    }

    private NotificationViewModel InsertOne(NotificationInsertViewModel model, Guid userId)
    {
        var user = GetUser(userId);
        ThrowIfNull(user, "User");

        if (string.IsNullOrEmpty(user.Email))
            throw new BadRequestException("User email not found.");

        var entity = ConvertToEntity(model, userId, user.Email);
        SendNotificationToMiddlware(entity);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    public void Delete(Guid id)
    {
        var notification = Get(id);
        ThrowIfNull(notification, "Notification");

        _repository.Delete(notification);
    }

    private void SendNotificationToMiddlware(Notification entity)
    {
        var body = CreatePostModel(entity);
        var response = _middlewareClient.PostSendEmailNotification(body);

        if (response == HttpStatusCode.OK || response == HttpStatusCode.Created)
            entity.Status = MessageStatus.ENVIADA;
        else
            entity.Status = MessageStatus.FALHAAOENVIAR;
    }

    private UserInfoViewModel GetUser(Guid id)
    {
        var target = new List<Guid>() { id };
        var users = _middlewareClient.GetUserInfos(target);

        return users.FirstOrDefault();
    }

    private Notification Get(Guid id)
    {
        return GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefault();
    } 

    private IQueryable<Notification> GetAll()
    {
        return _repository
                .Query()
                .OrderByDescending(e => e.Date);
    }

    private static PostMiddlwareNotificationViewModel CreatePostModel(Notification entity)
    {
        return new PostMiddlwareNotificationViewModel(entity.UserEmail, entity.Title, entity.Message, true);
    }

    private static NotificationViewModel ConvertToViewModel(Notification entity)
    {
        return new NotificationViewModel(entity.Id, entity.Title, entity.Message, entity.Link, entity.Date, entity.UserId, entity.Priority, entity.Status, entity.Body);
    }

    private static Notification ConvertToEntity(NotificationInsertViewModel model, Guid userId, string email = null)
    {
        var now = DateTime.Now;
        return new Notification(model.Link, model.Message, model.Title, userId, now, email, model.Priority, model.Body);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }
}