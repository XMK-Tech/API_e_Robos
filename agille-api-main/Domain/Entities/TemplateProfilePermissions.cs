using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
    public class TemplateProfilePermissions : Entity
    {
        protected TemplateProfilePermissions()
        {

        }
        public TemplateProfilePermissions(Guid profileId, Guid permissionId)
        {
            ProfileId = profileId;
            PermissionId = permissionId;
        }

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }

    public class TemplateProfilePermissionsMap : IEntityTypeConfiguration<TemplateProfilePermissions>
    {
        public void Configure(EntityTypeBuilder<TemplateProfilePermissions> builder)
        {
            builder.ToTable("TemplateProfilePermissions");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.Profile)
                .WithMany(ad => ad.TemplateProfilePermissions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ad => ad.ProfileId);

            builder.HasOne(s => s.Permission)
                .WithMany(ad => ad.TemplateProfilePermissions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ad => ad.PermissionId);
        }
    }
}
