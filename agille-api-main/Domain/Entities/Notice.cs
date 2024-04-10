using System;
using System.Collections.Generic;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities;

public class Notice : Entity
{
    public Notice(string content, Guid attachmentId, Guid templateId, NoticeType type, DateTime dueDate)
    {
        Content = content;
        AttachmentId = attachmentId;
        TemplateId = templateId;
        Type = type;
        DueDate = dueDate;
    }

    public Notice(string content, Guid attachmentId, Guid templateId, NoticeType type, decimal aliquot, string observation, DateTime dueDate, NoticeBaseRate rateType)
    {
        Content = content;
        AttachmentId = attachmentId;
        TemplateId = templateId;
        Type = type;
        Aliquot = aliquot;
        Observation = observation;
        DueDate = dueDate;
        RateType = rateType;
    }

    public Module Module { get; set; }
    public NoticeStatus Status { get; set; }
    public NoticeType Type { get; set; }
    public NoticeBaseRate RateType { get; set; }

    public string Content { get; set; }
    public string Number {get;set;}
    public decimal Aliquot {get;set;}
    public string Observation {get;set;}
    public DateTime DueDate { get; set; }

    public Guid? ReturnProtocolId { get; set; }
    public ReturnProtocol ReturnProtocol { get; set; }

    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
    
    public Guid TemplateId { get; set; }
    public NoticeTemplate Template { get; set; }

    public Guid? TaxPayerId { get; set; }
    public JuridicalPersonBase TaxPayer { get; set; }

    public Guid? PersonId { get; set; }
    public PersonBase Person { get; set; }

    public ICollection<NoticeDivergencyEntry> NoticeDivergencyEntries { get; set; }
    public ICollection<TaxAction> TaxActions { get; set; }
}

public class NoticeMap : IEntityTypeConfiguration<Notice>
{
    public void Configure(EntityTypeBuilder<Notice> builder)
    {
        builder.ToTable("Notices");

        builder.HasKey(h => h.Id);

        builder.Property(e => e.Number).HasMaxLength(50);
        builder.Property(e => e.Content).IsRequired();
        builder.Property(e => e.Type).IsRequired();

        builder.HasOne(e => e.Template)
            .WithMany()
            .HasForeignKey(e => e.TemplateId);

        builder.HasOne(e => e.ReturnProtocol)
            .WithMany()
            .HasForeignKey(e => e.ReturnProtocolId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.TaxPayer)
            .WithMany()
            .HasForeignKey(e => e.TaxPayerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(e => e.Person)
            .WithMany()
            .HasForeignKey(e => e.PersonId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}