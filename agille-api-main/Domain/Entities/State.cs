using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class State : Entity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }
    }

    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.Country)
                .WithMany(ad => ad.States)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ad => ad.CountryId);

            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        }
    }
}