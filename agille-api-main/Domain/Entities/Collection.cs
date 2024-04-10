using AgilleApi.Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class Collection : RelatedEntityIdentifier, ILoggable
{
    public Collection() { }
    public Collection(decimal pasepValue, decimal selicValue, DateTime reference, DateTime payday, bool isFromMainEntity, Guid? relatedEntityId)
        : base(isFromMainEntity, relatedEntityId)
    {
        PasepValue = pasepValue;
        SelicValue = selicValue;
        Reference = reference;
        Payday = payday;
    }
    
    public void Update(decimal pasepValue, decimal selicValue, DateTime reference, DateTime payday, bool isFromMainEntity, Guid? relatedEntityId)
    {
        PasepValue = pasepValue;
        SelicValue = selicValue;
        Reference = reference;
        Payday = payday;
        IsFromMainEntity = isFromMainEntity;
        RelatedEntityId = relatedEntityId;
    }

    public decimal PasepValue { get; set; }
    public decimal SelicValue { get; set; }

    public DateTime Reference { get; set; }
    public DateTime Payday { get; set; }

    public Guid? CrawlerFileId { get; set; }
    public CrawlerFile CrawlerFile { get; set; }

    public ICollection<CollectionAttachment> Attachments { get; set; }
}

public class CollectionMap : IEntityTypeConfiguration<Collection>
{
    public void Configure(EntityTypeBuilder<Collection> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.RelatedEntity)
            .WithMany(p => p.Collections)
            .HasForeignKey(e => e.RelatedEntityId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.CrawlerFile)
            .WithMany(file => file.Collections)
            .HasForeignKey(e => e.CrawlerFileId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}