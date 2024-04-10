using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
    public class Operator : Entity, ILoggable
    {
        public Operator(){}

        public Operator(Guid personId)
        {
            PersonId = personId;
        }

        public Guid PersonId { get; set; }
        public PersonBase Person { get; set; }
    }
    public class OperatorMap : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable("Operator");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.Person)
                .WithOne(ad => ad.Operator)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey<Operator>(ad => ad.PersonId);
        }
    }
}
