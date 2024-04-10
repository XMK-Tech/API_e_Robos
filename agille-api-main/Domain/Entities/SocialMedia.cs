using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
    public class SocialMedia : Entity
    {
        public SocialMedia()
        {

        }
        public SocialMedia(SocialMediaEnum type, string url, Guid person_id)
        {
            PersonId = person_id;
            Url = url;
            Type = type;
        }

        public Guid PersonId { get; set; }
        public PersonBase Person { get; set; }
        public string Url { get; set; }
        public SocialMediaEnum Type { get; set; }
    }

    public class SocialMediaMap : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedia");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.Person)
                .WithMany(ad => ad.SocialMedias)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(ad => ad.PersonId);

            builder.Property(e => e.Url).HasMaxLength(600).IsRequired();
        }
    }
}