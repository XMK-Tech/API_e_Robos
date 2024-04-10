using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class CollectionAttachment : Entity
{
    public CollectionAttachment(CollectionAttachmentType type, string description, Guid attachmentId, Guid collectionId)
    {
        Type = type;
        Description = description;
        AttachmentId = attachmentId;
        CollectionId = collectionId;
    }

    public CollectionAttachmentType Type { get; set; }
    public string Description { get; set; }

    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public Guid CollectionId { get; set; }
    public Collection Collection { get; set; }
}

public class CollectionAttachmentMap : IEntityTypeConfiguration<CollectionAttachment>
{
    public void Configure(EntityTypeBuilder<CollectionAttachment> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.Collection)
            .WithMany(e => e.Attachments)
            .HasForeignKey(e => e.CollectionId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Attachment)
            .WithMany()
            .HasForeignKey(e => e.AttachmentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}