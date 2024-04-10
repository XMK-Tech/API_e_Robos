using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
    public class Profile : Entity
    {
        protected Profile()
        {

        }

        public Profile(string code, string name, string description, Guid owner_profile_id)
        {
            Code = code;
            Name = name;
            Description = description;
            OwnerProfileId = owner_profile_id;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerProfileId { get; set; }
        public Profile OwnerProfile { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Profile> Profiles { get; set; }

        public ICollection<TemplateProfilePermissions> TemplateProfilePermissions { get; set; }

    }

    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.OwnerProfile)
                .WithMany(ad => ad.Profiles)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(ad => ad.OwnerProfileId);

            builder.Property(e => e.Code).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(200).IsRequired();
        }
    }
}
