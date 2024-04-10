using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class ProprietyOwners : Entity, ILoggable
{
    public ProprietyOwners() { }
    public ProprietyOwners(Guid proprietyId, Guid ownerId)
    {
        ProprietyId = proprietyId;
        OwnerId = ownerId;
    }

    public Guid ProprietyId { get; set; }
    public Propriety Propriety { get; set; }
    public Guid OwnerId { get; set; }
    public PersonBase Owner { get; set; }
}

public class ProprietyOwnersMap : IEntityTypeConfiguration<ProprietyOwners>
{
    public void Configure(EntityTypeBuilder<ProprietyOwners> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.Propriety)
            .WithMany(p => p.Owners)
            .HasForeignKey(e => e.ProprietyId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Owner)
            .WithMany(p => p.Proprieties)
            .HasForeignKey(e => e.OwnerId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}