using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public ICollection<State> States { get; set; }
    }

    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(h => h.Id);

            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        }
    }
}