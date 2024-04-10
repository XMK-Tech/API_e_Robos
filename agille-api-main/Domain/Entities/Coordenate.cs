using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class Coordenate : Entity
{
    public Coordenate() { }
    public Coordenate(int index, decimal lat, decimal lng, Guid proprietyId)
    {
        Index = index;
        Lat = lat;
        Lng = lng;
        ProprietyId = proprietyId;
    }

    public int Index { get; set; }
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }

    public Guid ProprietyId { get; set; }
    public Propriety Propriety { get; set; }
}

public class CoordenateMap : IEntityTypeConfiguration<Coordenate>
{
    public void Configure(EntityTypeBuilder<Coordenate> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(p => p.Propriety)
            .WithMany(prop => prop.Coordenates)
            .HasForeignKey(p => p.ProprietyId)
            .IsRequired();
    }
}