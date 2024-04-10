using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class ProprietyAttachment : Entity, ILoggable
{
    public ProprietyAttachment() { }
    public ProprietyAttachment(Guid proprietyId, Guid attachmentId)
    {
        ProprietyId = proprietyId;
        AttachmentId = attachmentId;
    }

    public Guid ProprietyId { get; set; }
    public Propriety Propriety { get; set; }

    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}

public class ProprietyAttachmentMap : IEntityTypeConfiguration<ProprietyAttachment>
{
    public void Configure(EntityTypeBuilder<ProprietyAttachment> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.Propriety)
            .WithMany(p => p.Attachments)
            .HasForeignKey(ad => ad.ProprietyId)
            .IsRequired();

        builder.HasOne(s => s.Attachment)
            .WithMany()
            .HasForeignKey(ad => ad.AttachmentId)
            .IsRequired();
    }
}