using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class CrawlerFile : Entity
{
    public CrawlerFile(Guid attachmentId, string dataDescription, DateTime competence)
    {
        AttachmentId = attachmentId;
        WasImported = false;
        DataDescription = dataDescription;
        Competence = competence;
    }

    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
    
    public bool WasImported { get; set; }
    public bool WasReverted { get; set; }

    public string DataDescription { get; set; }
    public string Command { get; set; }

    public DateTime Competence { get; set; }

    public ICollection<Revenue> Revenues { get; set; }
    public ICollection<FPMLaunch> FPMLaunches { get; set; }
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<Collection> Collections { get; set; }
}

public class CrawlerFileMap : IEntityTypeConfiguration<CrawlerFile>
{
    public void Configure(EntityTypeBuilder<CrawlerFile> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.Attachment)
            .WithMany()
            .HasForeignKey(e => e.AttachmentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}