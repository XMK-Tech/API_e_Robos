using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class PhysicalPersonBase : Entity
{
    public PhysicalPersonBase() { }
    public PhysicalPersonBase(string discriminator)
    {
        Discriminator = discriminator;
    }
    public PhysicalPersonBase(string firstName, string lastName, string detail, Gender gender, Guid? companyId, string discriminator = "PhysicalPerson")
    {
        FirstName = firstName;
        LastName = lastName;
        Detail = detail;
        Gender = gender;
        CompanyId = companyId;
        Discriminator = discriminator;
    }

    public void Update(string firstName, string lastName, string detail, Gender gender, Guid? companyId, string discriminator = "PhysicalPerson")
    {
        FirstName = firstName;
        LastName = lastName;
        Detail = detail;
        Gender = gender;
        CompanyId = companyId;
        Discriminator = discriminator;
    }

    public string Discriminator { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Detail { get; set; }
    public Gender Gender { get; set; }
    public Guid? CompanyId { get; set; }
    public JuridicalPersonBase Company { get; set; }
    public Guid PersonId { get; set; }
    public PersonBase Person { get; set; }
    public List<JuridicalPersonBase> Companies { get; set; } = new List<JuridicalPersonBase>();
}

public class PhysicalPersonBaseMap : IEntityTypeConfiguration<PhysicalPersonBase>
{
    public void Configure(EntityTypeBuilder<PhysicalPersonBase> builder)
    {
        builder.ToTable("PhysicalPerson");
        builder.HasDiscriminator<string>("Discriminator")
            .HasValue<PhysicalPersonBase>("PhysicalPerson");
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.Person)
            .WithOne(ad => ad.PhysicalPerson)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey<PhysicalPersonBase>(ad => ad.PersonId);

        builder.HasOne(s => s.Company)
            .WithOne()
            .HasForeignKey<PhysicalPersonBase>(ad => ad.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(u => u.CompanyId)
            .IsUnique(false);

        builder.Property(e => e.FirstName).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.LastName).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.Detail).HasMaxLength(200).IsRequired(false);
    }
}
