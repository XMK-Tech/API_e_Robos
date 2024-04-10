using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class JuridicalPersonBase : Entity
{
    public JuridicalPersonBase() { }
    public JuridicalPersonBase(string discriminator, string municipalRegistration, bool isCardOperator = false, double cardRate = 0)
    {
        Discriminator = discriminator;
        MunicipalRegistration = municipalRegistration;
        IsCardOperator = isCardOperator;
        CardRate = cardRate;
    }
    public void Update(string discriminator, string municipalRegistration, bool isCardOperator = false, double cardRate = 0)
    {
        Discriminator = discriminator;
        MunicipalRegistration = municipalRegistration;
        IsCardOperator = isCardOperator;
        CardRate = cardRate;
    }

    public string MunicipalRegistration { get; set; }
    public string Discriminator { get; set; }
    public PersonBase Person { get; set; }
    public Guid PersonId { get; set; }
    public bool Deleted { get; set; }

    public bool IsCardOperator { get; set; }
    public double CardRate { get; set; }
}

public class JuridicalPersonBaseMap : IEntityTypeConfiguration<JuridicalPersonBase>
{
    public void Configure(EntityTypeBuilder<JuridicalPersonBase> builder)
    {
        builder.ToTable("JuridicalPerson");
        builder.HasDiscriminator<string>("Discriminator")
            .HasValue<JuridicalPersonBase>("JuridicalPerson");
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.Person)
            .WithOne(ad => ad.JuridicalPerson)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey<JuridicalPersonBase>(ad => ad.PersonId);
    }
}
