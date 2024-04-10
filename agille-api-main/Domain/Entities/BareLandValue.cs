using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class BareLandValue : Entity, ILoggable
{
    public BareLandValue() { }
    public BareLandValue(
        string year,
        decimal goodAptitude,
        decimal regularAptitude,
        decimal restrictedFitness,
        decimal plantedPastures,
        decimal forestryOrNaturalPasture,
        decimal preservationOfFaunaOrFlora,
        decimal goodSuitabilityFarming,
        decimal regularFitnessFarming,
        decimal restrictedAptitudeFarming,
        decimal plantedPasture,
        string report
        )
    {
        Year = year;
        GoodAptitude = goodAptitude;
        RegularAptitude = regularAptitude;
        RestrictedFitness = restrictedFitness;
        PlantedPastures = plantedPastures;
        ForestryOrNaturalPasture = forestryOrNaturalPasture;
        PreservationOfFaunaOrFlora = preservationOfFaunaOrFlora;
        GoodSuitabilityFarming = goodSuitabilityFarming;
        RegularFitnessFarming = regularFitnessFarming;
        RestrictedAptitudeFarming = restrictedAptitudeFarming;
        PlantedPasture = plantedPasture;
        Report = report;
    }

    public string Report { get; set; }

    public string Year { get; set; }
    public decimal GoodAptitude { get; set; }
    public decimal RegularAptitude { get; set; }
    public decimal RestrictedFitness { get; set; }
    public decimal PlantedPastures { get; set; }
    public decimal ForestryOrNaturalPasture { get; set; }
    public decimal PreservationOfFaunaOrFlora { get; set; }
    public decimal GoodSuitabilityFarming { get; set; }
    public decimal RegularFitnessFarming { get; set; }
    public decimal RestrictedAptitudeFarming { get; set; }
    public decimal PlantedPasture { get; set; }
}

public class BareLandValueMap : IEntityTypeConfiguration<BareLandValue>
{
    public void Configure(EntityTypeBuilder<BareLandValue> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(e => e.Year).HasMaxLength(20).IsRequired();
    }
}