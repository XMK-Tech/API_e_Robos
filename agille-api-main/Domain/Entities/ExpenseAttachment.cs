using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class ExpenseAttachment : Entity
{
    public ExpenseAttachment() { }
    public ExpenseAttachment(
        string favored, 
        string document, 
        string contract, 
        string validity, 
        string description, 
        EffortType type, 
        Guid attachmentId, 
        Guid expenseId)
    {
        Favored = favored;
        Document = document;
        Contract = contract;
        Validity = validity;
        Description = description;
        Type = type;
        AttachmentId = attachmentId;
        ExpenseId = expenseId;
    }

    public string Favored { get; set; }
    public string Document { get; set; }
    public string Contract { get; set; }
    public string Validity { get; set; }
    public string Description { get; set; }

    public EffortType Type { get; set; }

    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public Guid ExpenseId { get; set; }
    public Expense Expense { get; set; }
}

public class ExpenseAttachmentMap : IEntityTypeConfiguration<ExpenseAttachment>
{
    public void Configure(EntityTypeBuilder<ExpenseAttachment> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.Expense)
            .WithMany(e => e.Attachments)
            .HasForeignKey(e => e.ExpenseId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Attachment)
            .WithMany()
            .HasForeignKey(e => e.AttachmentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}