using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class ServiceTypeDescription : Entity
{
    public ServiceTypeDescription() { }
    public ServiceTypeDescription(string description, decimal? iSSRate, decimal? iSSAnnualValue, Guid serviceTypeId, string code)
    {
        Description = description;
        ISSRate = iSSRate;
        ISSAnnualValue = iSSAnnualValue;
        ServiceTypeId = serviceTypeId;
        Code = code;
    }

    public string Code { get; set; }
    public string Description { get; set; }
    public decimal? ISSRate { get; set; }
    public decimal? ISSAnnualValue { get; set; }

    public Guid ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; }
}

public class ServiceTypeDescriptionMap : IEntityTypeConfiguration<ServiceTypeDescription>
{
    public void Configure(EntityTypeBuilder<ServiceTypeDescription> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Code).HasMaxLength(20);

        builder.HasOne(s => s.ServiceType)
            .WithMany(st => st.Descriptions)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(s => s.ServiceTypeId);
    }
}