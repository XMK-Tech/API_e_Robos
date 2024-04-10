using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class Index : Entity
{
    public Index() { }
    public Index(IndexType type, decimal percentage, DateTime reference)
    {
        Type = type;
        Percentage = percentage;
        Reference = reference;
    }

    public IndexType Type { get; set; }
    public decimal Percentage { get; set; }
    public DateTime Reference { get; set; }
}

public class IndexMap : IEntityTypeConfiguration<Index>
{
    public void Configure(EntityTypeBuilder<Index> builder)
    {
        builder.HasKey(h => h.Id);
    }
}