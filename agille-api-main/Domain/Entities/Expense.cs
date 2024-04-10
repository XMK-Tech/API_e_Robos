using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class Expense : RelatedEntityIdentifier, ILoggable
{
    public Expense() { }
    public Expense(
        string year, 
        string pASEP, 
        int index, 
        decimal value, 
        DateTime reference, 
        string description, 
        ExpenseType type,
        bool isFromMainEntity,
        Guid? relatedEntityId)
        : base(isFromMainEntity, relatedEntityId)
    {
        Year = year;
        PASEP = pASEP;
        Index = index;
        Value = value;
        Reference = reference;
        Description = description;
        Type = type;
    }

    public ExpenseType Type { get; set; }

    public string Description { get; set; } // Creditor
    public string Year { get; set; }
    public string PASEP { get; set; } // Effort

    public int Index { get; set; }
    public decimal Value { get; set; }
    
    public DateTime Reference { get; set; }
    public DateTime PaymentDate { get; set; }

    public Guid? CrawlerFileId { get; set; }
    public CrawlerFile CrawlerFile { get; set; }

    public ICollection<ExpenseAttachment> Attachments { get; set; }
}

public class ExpenseMap : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.RelatedEntity)
            .WithMany(p => p.Expenses)
            .HasForeignKey(e => e.RelatedEntityId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.CrawlerFile)
            .WithMany(file => file.Expenses)
            .HasForeignKey(e => e.CrawlerFileId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}