using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
  public class MessageTemplate : Entity
    {
        public MessageTemplate(string code, string templateName, string subject, string message, bool sendCopyToMyself, MessageType type)
        {
            Code = code;
            TemplateName = templateName;
            Subject = subject;
            Message = message;
            SendCopyToMyself = sendCopyToMyself;
            Type = type;
        }

        public string Code { get; set; }
        public string TemplateName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool SendCopyToMyself { get; set; }
        public MessageType Type { get; set; }
        public ICollection<MessageQueue> MessageQueues { get; set; }
    }
    public class MessageTemplateMap : IEntityTypeConfiguration<MessageTemplate>
    {
        public void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder.ToTable("MessagesTemplates");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Code).HasMaxLength(100);
            builder.Property(e => e.TemplateName).HasMaxLength(100);
            builder.Property(e => e.Subject).HasMaxLength(200);
        }
    }
}
