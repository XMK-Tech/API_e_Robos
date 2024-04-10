using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class PersonBase : Entity, ILoggable
{
    public PersonBase() { }
    public PersonBase(string name, string document, string displayName, DateTime? date, PersonType type, bool status, string profilePicUrl = null, string cibNumber = "", string immunityYears = "", DateTime? startDate = null, DateTime? endDate = null)
    {
        Name = name;
        Document = document;
        DisplayName = displayName;
        ProfilePicUrl = profilePicUrl;
        CibNumber = cibNumber;
        ImmunityYears = immunityYears;
        Date = date;
        Type = type;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
    }
    public PersonBase(string name, string agiPrevCode, AgiPrevPersonType agiPrevPersonType, string document)
    {
        Name = name;
        AgiPrevCode = agiPrevCode;
        AgiPrevPersonType = agiPrevPersonType;
        Type = PersonType.Physical;
        Status = true;
        Document = document;
    }

    public void Update(string name, string document, string displayName, DateTime? date, PersonType type, bool status, string profilePicUrl = null, string cibNumber = "", string immunityYears = "", DateTime? startDate = null, DateTime? endDate = null)
    {
        Name = name;
        Document = document;
        DisplayName = displayName;
        ProfilePicUrl = profilePicUrl;
        CibNumber = cibNumber;
        ImmunityYears = immunityYears;
        Date = date;
        Type = type;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
    }
    public void Update(string name, string agiPrevCode, string document)
    {
        Name = name;
        AgiPrevCode = agiPrevCode;
        Document = document;
    }

    public string Name { get; set; }
    public string Document { get; set; }
    public string GeneralRecord { get; set; }
    public string DisplayName { get; set; }
    public string ProfilePicUrl { get; set; }
    public DateTime? Date { get; set; }

    public PersonType Type { get; set; }
    public bool Status { get; set; }
    public List<Phone> Phones { get; set; }
    public List<SocialMedia> SocialMedias { get; set; }

    public ICollection<EmailPerson> EmailPersons { get; set; }
    public ICollection<AddressPerson> Addresses { get; set; }
    public ICollection<ProprietyOwners> Proprieties { get; set; }

    public User User { get; set; }
    public JuridicalPersonBase JuridicalPerson { get; set; }
    public PhysicalPersonBase PhysicalPerson { get; set; }

    public string SocialName { get; set; }
    public string CibNumber { get; set; }
    public string ImmunityYears { get; set; }
    public string ReasonForImmunity { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Guid? LegalRepresentativeId { get; set; }
    public PersonBase LegalRepresentative { get; set; }
    public string LegalRepresentativeObs { get; set; }

    public Guid? InventoryPersonId { get; set; }
    public PersonBase InventoryPerson { get; set; }
    public string InventoryObs { get; set; }

    public Guid? UserId { get; set; }

    public string AgiPrevCode { get; set; }
    public AgiPrevPersonType AgiPrevPersonType { get; set; }
    public Operator Operator { get; set; }
    public Server Server { get; set; }
}

public class PersonBaseMap : IEntityTypeConfiguration<PersonBase>
{
    public void Configure(EntityTypeBuilder<PersonBase> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        builder.Property(e => e.SocialName).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.Document).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.DisplayName).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.ProfilePicUrl).HasMaxLength(600).IsRequired(false);

        builder.Property(e => e.CibNumber).HasMaxLength(80).IsRequired(false);
        builder.Property(e => e.ImmunityYears).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.ReasonForImmunity).HasMaxLength(80).IsRequired(false);

        builder.Property(e => e.InventoryObs).HasMaxLength(600).IsRequired(false);
        builder.Property(e => e.InventoryObs).HasMaxLength(600).IsRequired(false);

        builder.Property(e => e.UserId).IsRequired(false);

        builder.HasOne(e => e.LegalRepresentative)
                .WithMany()
                .HasForeignKey(e => e.LegalRepresentativeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

        builder.HasOne(e => e.InventoryPerson)
                .WithMany()
                .HasForeignKey(e => e.InventoryPersonId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
    }
}