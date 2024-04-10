using BaseSystem.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BaseSystem.Domain.Entities
{
  public class MessageTemplateDynamicFields:Entity
    {
        public Guid MessageTemplateId { get; set; }
        public MessageTemplate MessageTemplate { get; set; }
        public Guid DynamicFieldId { get; set; }
        public DynamicFieldOptions DynamicField { get; set; }
    }
    public class MessageTemaplteDynamicFieldsMap : IEntityTypeConfiguration<MessageTemplateDynamicFields>
    {
        public void Configure(EntityTypeBuilder<MessageTemplateDynamicFields> builder)
        {
            builder.ToTable("MessageTemplateDynamicField");
            builder.HasOne(e => e.MessageTemplate).WithMany(e => e.MessageTemplateDynamicFields).HasForeignKey(E => E.MessageTemplateId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.DynamicField).WithMany(e => e.MessageTemplateDynamicFields).HasForeignKey(E => E.DynamicFieldId).OnDelete(DeleteBehavior.NoAction);
    }
    }
}
