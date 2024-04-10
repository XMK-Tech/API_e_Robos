using System;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities {
    public class NoticeDivergencyEntry: Entity {
        public Notice Notice {get; set;}
        public Guid NoticeId {get; set;}
        public Guid DivergencyEntryId {get; set;}
    }

    public class NoticeDivergencyEntryMap : IEntityTypeConfiguration<NoticeDivergencyEntry> {
        public void Configure(EntityTypeBuilder<NoticeDivergencyEntry> builder) {
            builder.ToTable("NoticeDivergencyEntry");
            builder.HasKey(h => h.Id);
            builder.HasOne(e => e.Notice)
            .WithMany(n => n.NoticeDivergencyEntries)
            .HasForeignKey(e => e.NoticeId);
        }
    }
}