using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class JuridicalPersonServiceTypeDescription : Entity
{
    public JuridicalPersonServiceTypeDescription() { }
    public JuridicalPersonServiceTypeDescription(Guid serviceTypeDescriptionId, Guid juridicalPersonId)
    {
        ServiceTypeDescriptionId = serviceTypeDescriptionId;
        JuridicalPersonId = juridicalPersonId;
    }

    public Guid ServiceTypeDescriptionId { get; set; }
    public ServiceTypeDescription ServiceTypeDescription { get; set; }
    
    public Guid JuridicalPersonId { get; set; }
    public JuridicalPersonBase JuridicalPerson { get; set; }
}

public class JuridicalPersonServiceTypeDescriptionMap : IEntityTypeConfiguration<JuridicalPersonServiceTypeDescription>
{
    public void Configure(EntityTypeBuilder<JuridicalPersonServiceTypeDescription> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.JuridicalPerson)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(s => s.JuridicalPersonId);

        builder.HasOne(s => s.ServiceTypeDescription)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(s => s.ServiceTypeDescriptionId);
    }
}