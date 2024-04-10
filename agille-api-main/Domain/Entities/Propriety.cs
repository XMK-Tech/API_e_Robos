using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class Propriety : Entity, ILoggable
{
    public Propriety() { }

public Propriety(string cibNumber, string name, ProprietyType type, double declaredArea)
{
    CibNumber = cibNumber;
    Name = name;
    Type = type;
    DeclaredArea = declaredArea;
}

    public string LinkedCib { get; set; }
    public string CibNumber { get; set; }
    public string Situation { get; set; }
    public string Name { get; set; }
    public ProprietyType Type { get; set; }
    public double DeclaredArea { get; set; }

    public string IncraCode { get; set; }
    public string MunicipalRegistration { get; set; }
    public string CARNumber { get; set; }
    public string Registration { get; set; }

    public Guid? ContactId { get; set; }
    public ProprietyContact Contact { get; set; }

    public Guid? CharacteristicsId { get; set; }
    public ProprietyCharacteristics Characteristics { get; set; }

    public Guid? AddressId { get; set; }
    public ProprietyAddress Address { get; set; }

    public bool HasSettlement { get; set; }
    public string SettlementName { get; set; }
    public SettlementType? SettlementType { get; set; }

    public bool HasPropertyCertificate { get; set; }
    public string CertificateNumber { get; set; }

    public bool HasRegularizedLegalReserve { get; set; }
    public double LegalReserveArea { get; set; }

    public bool HasSquattersInTheArea { get; set; }
    public double OccupancyPercentage { get; set; }
    public double OccupancyTime { get; set; }

    public decimal PermanentPreservation { get; set; }
    public decimal LegalReserve { get; set; }
    public decimal BusyWithImprovements { get; set; }
    public decimal Reforestation { get; set; }

    public decimal GoodSuitabilityFarming { get; set; }
    public decimal RegularFitnessFarming { get; set; }
    public decimal RestrictedAptitudeFarming { get; set; }
    public decimal PlantedPasture { get; set; }

    public Guid? FromAttachmentId { get; set; }
    public Attachment FromAttachment { get; set; }

    public ICollection<ProprietyOwners> Owners { get; set; }
    public ICollection<Coordenate> Coordenates { get; set; }
    public ICollection<ProprietyAttachment> Attachments { get; set; }
    public ICollection<TaxPayerDeclaration> Declarations { get; set; }
    public ICollection<CultureDeclaration> CultureDeclarations { get; set; }
}

public class ProprietyMap : IEntityTypeConfiguration<Propriety>
{
    public void Configure(EntityTypeBuilder<Propriety> builder)
    {
        builder.ToTable("Propriety");
        builder.HasKey(h => h.Id);

        builder.Property(e => e.LinkedCib).IsRequired(false);
        builder.Property(e => e.CibNumber).IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Type).IsRequired();
        builder.Property(e => e.DeclaredArea).IsRequired();
        
        builder.Property(e => e.IncraCode).IsRequired(false);
        builder.Property(e => e.MunicipalRegistration).IsRequired(false);
        builder.Property(e => e.Registration).IsRequired(false);
        builder.Property(e => e.CARNumber).IsRequired(false);

        builder.Property(e => e.SettlementName).IsRequired(false);
        builder.Property(e => e.SettlementType).IsRequired(false);

        builder.Property(e => e.CertificateNumber).IsRequired(false);

        builder.HasOne(s => s.Contact)
            .WithMany()
            .HasForeignKey(ad => ad.ContactId)
            .IsRequired(false);

        builder.HasOne(s => s.Characteristics)
            .WithMany()
            .HasForeignKey(ad => ad.CharacteristicsId)
            .IsRequired(false);

        builder.HasOne(s => s.Address)
            .WithMany()
            .HasForeignKey(ad => ad.AddressId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.HasOne(s => s.FromAttachment)
            .WithMany()
            .HasForeignKey(ad => ad.FromAttachmentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);
    }
}
