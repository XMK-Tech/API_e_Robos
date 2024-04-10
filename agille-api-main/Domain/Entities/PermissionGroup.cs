using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class PermissionGroup : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public Guid SystemId { get; set; }
        //public Domain.Entities.System System { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }

    public class PermissionGroupMap : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> builder)
        {
            builder.ToTable("PermissionGroup");
            builder.HasKey(h => h.Id);

            //builder.HasOne(s => s.System)
            //    .WithMany(ad => ad.PermissionGroups)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .HasForeignKey(ad => ad.SystemId);

            builder.Property(e => e.Code).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(200).IsRequired();
        }
    }
}