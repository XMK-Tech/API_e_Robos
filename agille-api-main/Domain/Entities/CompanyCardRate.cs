using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class CompanyCardRate : Entity
{
    public CompanyCardRate(double rate, Guid companyId, Guid cardOperatorId)
    {
        Rate = rate;
        CompanyId = companyId;
        CardOperatorId = cardOperatorId;
    }

    public double Rate { get; set; }

    public Guid CompanyId { get; set; }
    public JuridicalPersonBase Company { get; set; }

    public Guid CardOperatorId { get; set; }
    public JuridicalPersonBase CardOperator { get; set; }
}

public class CompanyCardRateMap : IEntityTypeConfiguration<CompanyCardRate>
{
    public void Configure(EntityTypeBuilder<CompanyCardRate> builder)
    {
        builder.ToTable("CompanyCardRate");
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.Company)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(ad => ad.CompanyId);

        builder.HasOne(s => s.CardOperator)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(ad => ad.CardOperatorId);
    }
}