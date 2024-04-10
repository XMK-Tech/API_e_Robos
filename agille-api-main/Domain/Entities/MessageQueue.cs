using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
  public class MessageQueue : Entity
  {
    public MessageQueue(
        string sendFrom,
        string sendTo,
        string sendCopyMyself,
        string sendCopyTo,
        string subject,
        string message,
        MessageStatus status,
        MessageType type,
        string observation, 
        string Data)
    {
      SendFrom = sendFrom;
      SendTo = sendTo;
      SendCopyMyself = sendCopyMyself;
      SendCopyTo = sendCopyTo;
      Subject = subject;
      Message = message;
      Status = status;
      Type = type;
      Observation = observation;
      this.Data = Data;
      Date = DateTime.UtcNow;
    }

    protected MessageQueue()
    {

    }
    public string SendFrom { get; set; }
    public string SendTo { get; set; }
    public string SendCopyMyself { get; set; }
    public string SendCopyTo { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public string Data { get; set; }
    public DateTime Date { get; set; }
    public MessageStatus Status { get; set; }
    public MessageType Type { get; set; }
    public string Observation { get; set; }
    public MessageTemplate MessageTemplate { get; set; }
    public Guid? MessageTemplateId { get; set; }
    public Guid? UserId { get; set; }
    public User User { get; set; }
  }
  public class MessageMap : IEntityTypeConfiguration<MessageQueue>
  {
    public void Configure(EntityTypeBuilder<MessageQueue> builder)
    {
      builder.ToTable("Messages");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.SendFrom).HasMaxLength(200);
      builder.Property(e => e.SendTo).HasMaxLength(200);
      builder.Property(e => e.Subject).HasMaxLength(300);
      builder.Property(e => e.Observation).HasMaxLength(250);
      builder.Property(e => e.SendCopyMyself).HasMaxLength(50).IsRequired(false);
      builder.Property(e => e.SendCopyTo).HasMaxLength(50).IsRequired(false);
      builder.Property(e => e.Data).HasMaxLength(50).IsRequired(false);
      builder.HasOne(e => e.MessageTemplate).WithMany(e => e.MessageQueues).HasForeignKey(e => e.MessageTemplateId).IsRequired(false);
      builder.HasOne(e => e.User).WithMany(e => e.MessageQueues).HasForeignKey(e => e.UserId).IsRequired(false);
    }
  }
}
