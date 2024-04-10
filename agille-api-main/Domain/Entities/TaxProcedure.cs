using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class TaxProcedure : Entity, ILoggable
{
    public TaxProcedure() { }
    public TaxProcedure(string intimationYear, string processNumber, string cibNumber,
        ProcedureStatus status, Guid proprietyId)
    {
        IntimationYear = intimationYear;
        ProcessNumber = processNumber;
        CibNumber = cibNumber;
        Status = status;
        ProprietyId = proprietyId;
    }

    public string IntimationYear { get; set; }
    public string ProcessNumber { get; set; }
    public string CibNumber { get; set; }
    public ProcedureStatus Status { get; set; }

    public Guid ProprietyId { get; set; }
    public Propriety Propriety { get; set; }

    public ICollection<TaxStage> TaxStages { get; set; }
    public ICollection<TaxParam> TaxParams { get; set; }
    public ICollection<ProprietyCattle> Cattles { get; set; }
}

public class TaxProcedureMap : IEntityTypeConfiguration<TaxProcedure>
{
    public void Configure(EntityTypeBuilder<TaxProcedure> builder)
    {
        builder.ToTable("TaxProcedure");
        builder.HasKey(h => h.Id);

        builder.Property(e => e.IntimationYear).IsRequired();
        builder.Property(e => e.ProcessNumber).IsRequired();
        builder.Property(e => e.Status).IsRequired();

        builder.HasOne(s => s.Propriety)
            .WithMany()
            .HasForeignKey(ad => ad.ProprietyId);
    }
}
