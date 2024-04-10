using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public abstract class NotificationViewModelBase
{
    public NotificationViewModelBase() { }
    public NotificationViewModelBase(string title, string message, string link, NotificationPriority priority, string body)
    {
        Title = title;
        Message = message;
        Link = link;
        Priority = priority;
        Body = body;
    }

    public string Title { get; set; }
    public string Message { get; set; }
    public string Link { get; set; }
    public string Body { get; set; } = "";
    public NotificationPriority Priority { get; set; }
}

public class NotificationViewModel : NotificationViewModelBase
{
    public NotificationViewModel() { }
    public NotificationViewModel(Guid id, string title, string message, string link, DateTime date, Guid userId, NotificationPriority priority, MessageStatus status, string body)
        : base(title, message, link, priority, body)
    {
        Id = id;
        Date = date;
        Status = status;
        UserId = userId;
    }

    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public MessageStatus Status { get; set; }
}

public class NotificationInsertViewModel : NotificationViewModelBase 
{ 
    public IEnumerable<Guid> UserIds { get; set; }
}

public class PostMiddlwareNotificationViewModel
{
    public PostMiddlwareNotificationViewModel() { }
    public PostMiddlwareNotificationViewModel(string send_to, string subject, string message, bool autoSend)
    {
        Send_to = send_to;
        Subject = subject;
        Message = message;
        AutoSend = autoSend;
    }

    public MessageType Type = MessageType.Email;
    public string Send_to { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool AutoSend { get; set; } = false;
}