using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class CourierRequest : Entity
{
    public CourierRequest(string invoice)
    {
        Invoice = invoice;
    }

    public string Invoice { get; set; }

    public ICollection<CourierItemRequests> ItemRequests { get; set; }
}

public class CourierRequestMap : IEntityTypeConfiguration<CourierRequest>
{
    public void Configure(EntityTypeBuilder<CourierRequest> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Invoice).HasMaxLength(9).IsRequired();
    }
}