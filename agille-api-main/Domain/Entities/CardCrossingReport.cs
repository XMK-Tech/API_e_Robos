using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class CardCrossingReport : Entity
{
    public CardCrossingReport() { }
    public CardCrossingReport(DateTime startingReference, DateTime endingReference, Guid? requestedById = null)
    {
        StartingReference = startingReference;
        EndingReference = endingReference;
        RequestedById = requestedById;
    }

    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
    public Guid? RequestedById { get; set; }
    public ICollection<CardDivergencyEntry> Divergencies { get; set; }
}

public class CardCrossingReportMap : IEntityTypeConfiguration<CardCrossingReport>
{
    public void Configure(EntityTypeBuilder<CardCrossingReport> builder)
    {
        builder.ToTable("CardCrossingReport");
        builder.HasKey(h => h.Id);
    }
}