using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class FPMLaunch : Entity
{
    public FPMLaunch() { }
    public FPMLaunch(string description, string incomeAccount, decimal collected, decimal accumulated)
    {
        Description = description;
        IncomeAccount = incomeAccount;
        Collected = collected;
        Accumulated = accumulated;
    }

    public string Description { get; set; }
    public string IncomeAccount { get; set; }
    public decimal Collected { get; set; }
    public decimal Accumulated { get; set; }

    public DateTime Reference { get; set; }
    public DateTime Competence { get; set; }

    public Guid? CrawlerFileId { get; set; }
    public CrawlerFile CrawlerFile { get; set; }
}

public class FPMLaunchMap : IEntityTypeConfiguration<FPMLaunch>
{
    public void Configure(EntityTypeBuilder<FPMLaunch> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.CrawlerFile)
            .WithMany(file => file.FPMLaunches)
            .HasForeignKey(e => e.CrawlerFileId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}