using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class AddressPerson
{
    public AddressPerson() { }
    public AddressPerson(Guid personId, Guid addressId)
    {
        PersonId = personId;
        AddressId = addressId;
    }

    public Guid PersonId { get; set; }
    public PersonBase Person { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
}

public class PersonAddressMap : IEntityTypeConfiguration<AddressPerson>
{
    public void Configure(EntityTypeBuilder<AddressPerson> builder)
    {
        builder.ToTable("PersonAddress");
        builder.HasKey(h => new { h.AddressId, h.PersonId });

        builder.HasOne(s => s.Address)
            .WithMany(ad => ad.AddressPersons)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(ad => ad.AddressId);

        builder.HasOne(s => s.Person)
            .WithMany(ad => ad.Addresses)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(ad => ad.PersonId);
    }
}