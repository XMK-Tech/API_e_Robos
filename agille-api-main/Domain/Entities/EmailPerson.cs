using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgilleApi.Domain.Entities
{
  public class EmailPerson
  {
    public EmailPerson() { }
    public EmailPerson(Guid emailId, Guid personId)
    {
      EmailId = emailId;
      PersonId = personId;
    }

    public Email Email { get; set; }
    public Guid EmailId { get; set; }
    public PersonBase Person { get; set; }
    public Guid PersonId { get; set; }

  }

  public class EmailPersonMap : IEntityTypeConfiguration<EmailPerson>
  {
    public void Configure(EntityTypeBuilder<EmailPerson> builder)
    {
      builder.ToTable("EmailPerson");
      builder.HasKey(h => new { h.EmailId, h.PersonId });

      builder.HasOne(h => h.Email)
        .WithMany(w => w.EmailPersons)
        .HasForeignKey(h => h.EmailId)
        .OnDelete(DeleteBehavior.Cascade)
        .IsRequired();

      builder.HasOne(h => h.Person)
        .WithMany(w => w.EmailPersons)
        .HasForeignKey(h => h.PersonId)
        .OnDelete(DeleteBehavior.Cascade)
        .IsRequired();
    }
  }
}