using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class Revenue : RelatedEntityIdentifier
{
    public Revenue() { }
    public Revenue(
        int index,
        decimal predictedDeductions,
        decimal deductions,
        string description,
        decimal predictedUpdated,
        decimal effectedValue,
        decimal predictedValue,
        decimal collection,
        DateTime reference,
        string account,
        bool isFromMainEntity,
        Guid? relatedEntityId)
        : base(isFromMainEntity, relatedEntityId)
    {
        Index = index;
        Description = description;

        PredictedDeductions = predictedDeductions;
        Deductions = deductions;
        PredictedUpdated = predictedUpdated;
        EffectedValue = effectedValue;
        PredictedValue = predictedValue;
        Collection = collection;

        Reference = reference;
        Account = account;
    }

    public int Index { get; set; }
    
    public string Account { get; set; }
    public string Description { get; set; }
    
    public decimal PredictedDeductions { get; set; }
    public decimal Deductions { get; set; }
    public decimal PredictedUpdated { get; set; }
    public decimal EffectedValue { get; set; }
    public decimal PredictedValue { get; set; }
    public decimal Collection { get; set; }

    public DateTime Reference { get; set; }

    public Guid? CrawlerFileId { get; set; }
    public CrawlerFile CrawlerFile { get; set; }
}

public class RevenueMap : IEntityTypeConfiguration<Revenue>
{
    public void Configure(EntityTypeBuilder<Revenue> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.RelatedEntity)
            .WithMany(p => p.Revenues)
            .HasForeignKey(e => e.RelatedEntityId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.CrawlerFile)
            .WithMany(file => file.Revenues)
            .HasForeignKey(e => e.CrawlerFileId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}