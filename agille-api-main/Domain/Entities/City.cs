using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }

        public ICollection<Address> Adresses { get; set; }
    }

    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.State)
                .WithMany(ad => ad.Cities)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ad => ad.StateId);

            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        }
    }
}