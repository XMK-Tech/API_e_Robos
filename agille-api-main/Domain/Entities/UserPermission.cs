using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
    public class UserPermission
    {
        public UserPermission()
        {

        }
        public UserPermission(Guid userId, Guid permissionId)
        {
            UserId = userId;
            PermissionId = permissionId;
        }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }

    public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("UserPermission");
            builder.HasKey(sc => new { sc.PermissionId, sc.UserId });


            builder.HasOne(h => h.User)
              .WithMany(w => w.UserPermissions)
              .HasForeignKey(h => h.UserId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();

            builder.HasOne(h => h.Permission)
              .WithMany(w => w.UserPermissions)
              .HasForeignKey(h => h.PermissionId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();
        }
    }
}
