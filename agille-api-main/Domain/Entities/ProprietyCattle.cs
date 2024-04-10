using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class ProprietyCattle : Entity, ILoggable
{
    public ProprietyCattle(Guid procedureId, int month)
    {
        ProcedureId = procedureId;
        Month = month;
    }

    public int Month { get; set; }

    public Guid ProcedureId { get; set; }
    public TaxProcedure Procedure { get; set; }

    public int Cattle { get; set; }
    public int Buffalos { get; set; }
    public int Equine { get; set; }
    public int Sheep { get; set; }
    public int Goats { get; set; }
}

public class ProprietyCattleMap : IEntityTypeConfiguration<ProprietyCattle>
{
    public void Configure(EntityTypeBuilder<ProprietyCattle> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.Procedure)
            .WithMany(p => p.Cattles)
            .HasForeignKey(s => s.ProcedureId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}