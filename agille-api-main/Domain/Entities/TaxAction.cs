using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class TaxAction : Entity
{
    public TaxAction() { }

    public TaxAction(string description, bool statusHasChanged, Guid userId, Guid noticeId, DateTime date, NoticeStatus? fromStatus = null, NoticeStatus? toStatus = null)
    {
        Description = description;
        StatusHasChanged = statusHasChanged;
        UserId = userId;
        NoticeId = noticeId;
        Date = date;

        FromStatus = fromStatus;
        ToStatus = toStatus;
    }

    public string Description { get; set; }

    public bool StatusHasChanged { get; set; }
    public NoticeStatus? FromStatus { get; set; }
    public NoticeStatus? ToStatus { get; set; }

    public Guid UserId { get; set; }
    public Guid NoticeId { get; set; }
    public Notice Notice { get; set; }

    public DateTime Date { get; set; }

    public Guid? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}

public class TaxActionMap : IEntityTypeConfiguration<TaxAction>
{
    public void Configure(EntityTypeBuilder<TaxAction> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Description).HasMaxLength(180);

        builder.HasOne(e => e.Notice)
            .WithMany(e => e.TaxActions)
            .HasForeignKey(e => e.NoticeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Attachment)
            .WithMany()
            .HasForeignKey(e => e.AttachmentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}