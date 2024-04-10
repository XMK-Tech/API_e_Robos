using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class TaxPayerDeclaration : Entity, ILoggable
{
    public TaxPayerDeclaration() { }
    public TaxPayerDeclaration(string year, string cib, Guid? proprietyId, decimal total, decimal permanentPreservationArea, decimal legalReserveArea, decimal taxableArea, decimal areaOccupiedWithWorks, decimal usableArea, decimal areaWithReforestation, decimal areaUsedInRuralActivity, Guid? userId, string number, Guid? personId, bool isFromImport = false)
    {
        Year = year;
        Cib = cib;
        ProprietyId = proprietyId;
        Total = total;
        PermanentPreservationArea = permanentPreservationArea;
        LegalReserveArea = legalReserveArea;
        TaxableArea = taxableArea;
        AreaOccupiedWithWorks = areaOccupiedWithWorks;
        UsableArea = usableArea;
        AreaWithReforestation = areaWithReforestation;
        AreaUsedInRuralActivity = areaUsedInRuralActivity;
        UserId = userId;
        Number = number;
        PersonId = personId;
        IsFromImport = isFromImport;
    }

    public string Number { get; set; }
    public string Year { get; set; }
    public string Cib { get; set; }

    public Guid? ProprietyId { get; set; }
    public Propriety Propriety { get; set; }

    public decimal Total { get; set; }
    public decimal PermanentPreservationArea { get; set; }
    public decimal LegalReserveArea { get; set; }
    public decimal TaxableArea { get; set; }
    public decimal AreaOccupiedWithWorks { get; set; }
    public decimal UsableArea { get; set; }
    public decimal AreaWithReforestation { get; set; }
    public decimal AreaUsedInRuralActivity { get; set; }

    public bool IsFromImport { get; set; }
    public Guid? UserId { get; set; }

    public Guid? PersonId { get; set; }
    public PersonBase Person { get; set; }
}

public class TaxPayerDeclarationMap : IEntityTypeConfiguration<TaxPayerDeclaration>
{
    public void Configure(EntityTypeBuilder<TaxPayerDeclaration> builder)
    {
        builder.HasKey(h => h.Id);
        
        builder.Property(h => h.Year).HasMaxLength(20).IsRequired();
        builder.Property(h => h.Cib).HasMaxLength(50).IsRequired();
        builder.Property(h => h.Number).HasMaxLength(100).IsRequired(false);

        builder.HasOne(s => s.Propriety)
                .WithMany(s => s.Declarations)
                .HasForeignKey(ad => ad.ProprietyId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        builder.HasOne(s => s.Person)
                .WithMany()
                .HasForeignKey(ad => ad.PersonId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
    }
}