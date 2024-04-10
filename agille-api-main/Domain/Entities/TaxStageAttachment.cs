using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class TaxStageAttachment : Entity
{
    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public Guid TaxStageId { get; set; }
    public TaxStage TaxStage { get; set; }
}

public class TaxStageAttachmentMap : IEntityTypeConfiguration<TaxStageAttachment>
{
    public void Configure(EntityTypeBuilder<TaxStageAttachment> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.Attachment)
                .WithMany()
                .HasForeignKey(e => e.AttachmentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

        builder.HasOne(e => e.TaxStage)
                .WithMany(e => e.Attachments)
                .HasForeignKey(e => e.TaxStageId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
    }
}