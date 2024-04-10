using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class Taxpayer : Entity
{
    public Taxpayer() { }
    public Taxpayer(Guid userId, Guid juridicalPersonId)
    {
        UserId = userId;
        JuridicalPersonId = juridicalPersonId;
    }

    public Guid UserId { get; set; }
    public Guid JuridicalPersonId { get; set; }
    public JuridicalPersonBase JuridicalPerson { get; set; }
}

public class TaxpayerMap : IEntityTypeConfiguration<Taxpayer>
{
    public void Configure(EntityTypeBuilder<Taxpayer> builder)
    {
        builder.ToTable("Taxpayers");
        builder.HasKey(h => h.Id);

        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.JuridicalPersonId).IsRequired();
        
        builder.HasOne(e => e.JuridicalPerson)
            .WithMany()
            .HasForeignKey(e => e.JuridicalPersonId);
    }
}