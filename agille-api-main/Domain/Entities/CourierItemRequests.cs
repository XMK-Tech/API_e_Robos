using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace AgilleApi.Domain.Entities;

public class CourierItemRequests : Entity
{
    public CourierItemRequests(string objectCode, Guid requestId, Guid itemId)
    {
        ObjectCode = objectCode;
        RequestId = requestId;
        ItemId = itemId;
    }

    public string ObjectCode { get; set; }

    public Guid RequestId { get; set; }
    public CourierRequest Request { get; set; }

    public Guid ItemId { get; set; }
    public CourierItem Item { get; set; }
}

public class CourierItemRequestsMap : IEntityTypeConfiguration<CourierItemRequests>
{
    public void Configure(EntityTypeBuilder<CourierItemRequests> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.ObjectCode).HasMaxLength(13).IsRequired();

        builder.HasOne(s => s.Request)
                .WithMany(s => s.ItemRequests)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ad => ad.RequestId)
                .IsRequired();

        builder.HasOne(s => s.Item)
                .WithMany(s => s.ItemRequests)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ad => ad.ItemId)
                .IsRequired();
    }
}