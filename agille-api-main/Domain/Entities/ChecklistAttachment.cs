using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class ChecklistAttachment : Entity
{
    public ChecklistAttachment(Guid checklistId, Guid attachmentId)
    {
        ChecklistId = checklistId;
        AttachmentId = attachmentId;
    }

    public Guid ChecklistId { get; set; }
    public Checklist Checklist { get; set; }

    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}

public class ChecklistAttachmentMap : IEntityTypeConfiguration<ChecklistAttachment>
{
    public void Configure(EntityTypeBuilder<ChecklistAttachment> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.Attachment)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(ad => ad.AttachmentId)
            .IsRequired();

        builder.HasOne(s => s.Checklist)
            .WithMany(c => c.Attachments)
            .HasForeignKey(ad => ad.ChecklistId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}