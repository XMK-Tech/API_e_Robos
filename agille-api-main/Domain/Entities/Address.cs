using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class Address : Entity
{
    public Address() { }
    public Address(string street, string number, string complement, string zip_code, AddressType type, Guid cityId, string owner, string ownerId, string district = "", AddressFunction function = AddressFunction.Common)
    {
        Street = street;
        Number = number;
        Complement = complement;
        ZipCode = zip_code;
        Type = type;
        CityId = cityId;
        Owner = owner;
        OwnerId = ownerId;
        District = district;
        Function = function;
    }

    public Address(string street, string number, string complement, string zip_code, AddressType type, string owner, string district = "", AddressFunction function = AddressFunction.Common)
    {
        Street = street;
        Number = number;
        Complement = complement;
        ZipCode = zip_code;
        Type = type;
        Owner = owner;
        District = district;
        Function = function;
    }

    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string ZipCode { get; set; }
    public AddressType Type { get; set; }
    public AddressFunction Function { get; set; }
    public string Owner { get; set; }
    public string OwnerId { get; set; }
    public Guid CityId { get; set; }
    public City City { get; set; }

    public ICollection<AddressPerson> AddressPersons { get; set; }
}

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.City)
            .WithMany(ad => ad.Adresses)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(ad => ad.CityId);

        builder.Property(e => e.Street).HasMaxLength(200).IsRequired();
        builder.Property(e => e.Owner).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.OwnerId).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.Complement).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.ZipCode).HasMaxLength(9).IsRequired(false);
    }
}