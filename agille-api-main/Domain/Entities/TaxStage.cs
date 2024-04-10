using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class TaxStage : Entity, ILoggable
{
    public TaxStage() { }
    public TaxStage(DateTime? certificationDate, DateTime? cutOffDate, string aRCode, string number, TaxStageType type, ProcessStatus status, Guid taxProcedureId, Guid? subjectId, decimal? fineAmount = 0, string trackingCode = "")
    {
        CertificationDate = certificationDate;
        CutOffDate = cutOffDate;
        ARCode = aRCode;
        Number = number;
        Type = type;
        Status = status;
        TaxProcedureId = taxProcedureId;
        FineAmount = fineAmount;
        TrackingCode = trackingCode;
        SubjectId = subjectId;
    }

    public DateTime? CertificationDate { get; set; }
    public DateTime? CutOffDate { get; set; }

    public decimal? FineAmount { get; set; }
    public string TrackingCode { get; set; }

    public string ARCode { get; set; }
    public string Number { get; set; }
    public TaxStageType Type { get; set; }
    public ProcessStatus Status { get; set; }

    public string ForwardTermUrl { get; set; }
    public string JoiningTermUrl { get; set; }
    public string ARTermUrl { get; set; }

    public Guid? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public Guid TaxProcedureId { get; set; }
    public TaxProcedure TaxProcedure { get; set; }

    public Guid? SubjectId { get; set; }
    public PersonBase Subject { get; set; }

    public TaxStage AnsweredByStage { get; set; }

    public Guid? ReplyToId { get; set; }
    public TaxStage ReplyTo { get; set; }

    // user
    public Guid? AnsweredById { get; set; }

    public ICollection<TaxStageAttachment> Attachments { get; set; }
}

public class TaxStageMap : IEntityTypeConfiguration<TaxStage>
{
    public void Configure(EntityTypeBuilder<TaxStage> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(p => p.ARCode).HasMaxLength(150).IsRequired(false);
        builder.Property(p => p.Number).HasMaxLength(150).IsRequired(false);
        builder.Property(p => p.TrackingCode).HasMaxLength(200).IsRequired(false);

        builder.HasOne(e => e.Attachment)
                .WithMany()
                .HasForeignKey(e => e.AttachmentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        builder.HasOne(e => e.ReplyTo)
                .WithOne(e => e.AnsweredByStage)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        builder.HasOne(e => e.Subject)
                .WithMany()
                .HasForeignKey(e => e.SubjectId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        builder.HasOne(e => e.TaxProcedure)
                .WithMany(t => t.TaxStages)
                .HasForeignKey(e => e.TaxProcedureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
    }
}