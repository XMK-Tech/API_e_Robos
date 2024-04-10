using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities;

public class ProprietyCharacteristics : Entity, ILoggable
{
    public ProprietyCharacteristics() { }
    public ProprietyCharacteristics(bool hasElectricity, bool hasPhone, bool hasInternet, bool hasNaturalWaterSpring, bool hasFishingPotential, bool hasPotentialForEcotourism) 
    { 
        HasElectricity = hasElectricity;
        HasPhone = hasPhone;
        HasInternet = hasInternet;
        HasNaturalWaterSpring = hasNaturalWaterSpring;
        HasFishingPotential = hasFishingPotential;
        HasPotentialForEcotourism = hasPotentialForEcotourism;
    }

    public bool HasElectricity { get; set; }
    public bool HasPhone { get; set; }
    public bool HasInternet { get; set; }
    public bool HasNaturalWaterSpring { get; set; }
    public bool HasFishingPotential { get; set; }
    public bool HasPotentialForEcotourism { get; set; }
}

public class ProprietyCharacteristicsMap : IEntityTypeConfiguration<ProprietyCharacteristics>
{
    public void Configure(EntityTypeBuilder<ProprietyCharacteristics> builder)
    {
        builder.ToTable("ProprietyCharacteristics");
        builder.HasKey(h => h.Id);
    }
}
