using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
    public class ProprietyAddress : Entity, ILoggable
    {
        public ProprietyAddress() { }

        public ProprietyAddress(Guid addressId, string postalCode)
        {
            AddressId = addressId;
            PostalCode = postalCode;
        }

        public string PostalCode { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }

    public class ProprietyAddressMap : IEntityTypeConfiguration<ProprietyAddress>
    {
        public void Configure(EntityTypeBuilder<ProprietyAddress> builder)
        {
            builder.ToTable("ProprietyAddress");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.Address)
                .WithMany()
                .HasForeignKey(ad => ad.AddressId)
                .IsRequired();

            builder.Property(e => e.PostalCode).IsRequired(false);
        }
    }
}
