using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class UnionTransfers : Entity
{
    public UnionTransfers(decimal value, DateTime date, UnionTransfersStatus status)
    {
        Value = value;
        Date = date;
        Status = status;
    }

    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public UnionTransfersStatus Status { get; set; }
}

public class UnionTransfersMap : IEntityTypeConfiguration<UnionTransfers>
{
    public void Configure(EntityTypeBuilder<UnionTransfers> builder)
    {
        builder.HasKey(h => h.Id);
    }
}