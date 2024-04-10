using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class RelatedEntity : Entity
{
    public RelatedEntity() { }
    public RelatedEntity(string name, string document, RelatedEntityType type, Guid addressId, string imageUrl)
    {
        Name = name;
        Document = document;
        Type = type;
        AddressId = addressId;
        ImageUrl = imageUrl;
    }

    public string Name { get; set; }
    public string Document { get; set; }
    public string ImageUrl { get; set; }

    public RelatedEntityType Type { get; set; }
    
    public Guid AddressId { get; set; }
    public Address Address { get; set; }

    public ICollection<Revenue> Revenues { get; set; }
    public ICollection<Collection> Collections { get; set; }
    public ICollection<Expense> Expenses { get; set; }
}

public class RelatedEntityMap : IEntityTypeConfiguration<RelatedEntity>
{
    public void Configure(EntityTypeBuilder<RelatedEntity> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(h => h.Address)
              .WithMany()
              .HasForeignKey(h => h.AddressId)
              .OnDelete(DeleteBehavior.NoAction)
              .IsRequired();
    }
}