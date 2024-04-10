using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class CourierItem : Entity
{
    public CourierItem(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public string Code { get; set; }
    public string Description { get; set; }

    public ICollection<CourierItemRequests> ItemRequests { get; set; }
}

public class CourierItemMap : IEntityTypeConfiguration<CourierItem>
{
    public void Configure(EntityTypeBuilder<CourierItem> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Code).HasMaxLength(5).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(50).IsRequired();
    }
}