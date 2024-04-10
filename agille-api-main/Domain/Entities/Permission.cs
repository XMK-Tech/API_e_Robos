using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class Permission : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerPermissionId { get; set; }
        public Permission OwnerPermission { get; set; }
        public Guid PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public ICollection<TemplateProfilePermissions> TemplateProfilePermissions { get; set; }
    }

    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(h => h.Id);

      builder.HasOne(s => s.OwnerPermission)
          .WithMany(ad => ad.Permissions)
          .OnDelete(DeleteBehavior.NoAction)
          .HasForeignKey(ad => ad.OwnerPermissionId);

      builder.HasOne(s => s.PermissionGroup)
          .WithMany(ad => ad.Permissions)
          .OnDelete(DeleteBehavior.Cascade)
          .HasForeignKey(ad => ad.PermissionGroupId);

            builder.Property(e => e.Code).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(200).IsRequired();
        }
    }
}