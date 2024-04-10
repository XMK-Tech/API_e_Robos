using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class Phone : Entity
    {
        public Phone()
        {

        }
        public Phone(string number, PhoneType type, Guid personId)
        {
            Number = number;
            Type = type;
            PersonId = personId;
        }

        public string Number { get; set; }
        public PhoneType Type { get; set; }
        public PersonBase Person { get; set; }
        public Guid PersonId { get; set; }

        //public ICollection<PhonePerson> PhonePersons { get; set; }
    }
    public class PhoneMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Phone");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.Person)
              .WithMany(ad => ad.Phones)
              .OnDelete(DeleteBehavior.Cascade)
              .HasForeignKey(ad => ad.PersonId);

            builder.Property(e => e.Number).HasMaxLength(50).IsRequired();
        }
    }
}