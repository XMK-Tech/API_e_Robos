using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class Rubric : Entity
{
    public Rubric() { }
    public Rubric(string name, Guid stateId, DateTime reference)
    {
        Name = name;
        StateId = stateId;
        Reference = reference;
    }

    public string Name { get; set; }
    public Guid StateId { get; set; }
    public State State { get; set; }
    public DateTime Reference { get; set; }

    public ICollection<RubricAccount> Accounts { get; set; }
}

public class RubricMap : IEntityTypeConfiguration<Rubric>
{
    public void Configure(EntityTypeBuilder<Rubric> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(h => h.State)
              .WithMany()
              .HasForeignKey(h => h.StateId)
              .OnDelete(DeleteBehavior.NoAction)
              .IsRequired();
    }
}