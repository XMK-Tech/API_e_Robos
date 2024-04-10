using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class Email : Entity
    {
        public Email()
        {

        }
        public Email(string email)
        {
            Value = email;
        }

        public string Value { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<EmailPerson> EmailPersons { get; set; }
    }

    public class EmailMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email");
            builder.HasKey(h => h.Id);

            builder.Property(e => e.Value).HasMaxLength(200).IsRequired();
        }
    }
}