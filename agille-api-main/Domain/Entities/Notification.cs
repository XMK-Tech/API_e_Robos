using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class Notification : Entity
{
    public Notification() { }
    public Notification(string link, string message, string title, Guid userId, DateTime date, string userEmail, NotificationPriority priority, string body)
    {
        Link = link;
        Message = message;
        Title = title;
        UserId = userId;
        Date = date;
        UserEmail = userEmail;
        Status = MessageStatus.NAFILA;
        Priority = priority;
        Body = body;
    }

    public string Link { get; set; }
    public string Body { get; set; }
    public string Message { get; set; }
    public string Title { get; set; }
    public Guid UserId { get; set; }
    public string UserEmail { get; set; }
    public DateTime Date { get; set; }
    public MessageStatus Status { get; set; }
    public NotificationPriority Priority { get; set; }
}

public class NotificationMap : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Link).HasMaxLength(100).IsRequired(false);
        builder.Property(e => e.Body).IsRequired(false);
        builder.Property(e => e.Message).HasMaxLength(250).IsRequired();
        builder.Property(e => e.Title).HasMaxLength(100).IsRequired();
    }
}