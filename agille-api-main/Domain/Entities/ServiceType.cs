using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class ServiceType : Entity
{
    public ServiceType() { }
    public ServiceType(string name, string code)
    {
        Name = name;
        Code = code;
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public ICollection<ServiceTypeDescription> Descriptions { get; set; }
}

public class ServiceTypeMap : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Code).HasMaxLength(20);
    }
}