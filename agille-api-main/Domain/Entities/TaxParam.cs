using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class TaxParam : Entity, ILoggable
{
    public TaxParam() { }
    
    public TaxParam(ProcedureParamType paramType, Guid taxProcedureId)
    {
        ParamType = paramType;
        TaxProcedureId = taxProcedureId;
    }

    public ProcedureParamType ParamType { get; set; }
    public Guid TaxProcedureId { get; set; }
    public TaxProcedure TaxProcedure { get; set; }
}

public class TaxParamMap : IEntityTypeConfiguration<TaxParam>
{
    public void Configure(EntityTypeBuilder<TaxParam> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.TaxProcedure)
                .WithMany(t => t.TaxParams)
                .HasForeignKey(e => e.TaxProcedureId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
    }
}