using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
    public class JuridicalPersonNotices : Entity
    {
        public JuridicalPersonNotices() { }
        public JuridicalPersonNotices(Guid noticeId, Guid juridicalPersonId)
        {
            NoticeId = noticeId;
            JuridicalPersonId = juridicalPersonId;
        }
        public JuridicalPersonNotices(Notice notice, JuridicalPersonBase juridicalPerson)
        {
            Notice = notice;
            NoticeId = notice.Id;
            JuridicalPerson = juridicalPerson;
            JuridicalPersonId = juridicalPerson.Id;
        }

        public Guid NoticeId { get; set; }
        public Notice Notice { get; set; }
        public Guid JuridicalPersonId { get; set; }
        public JuridicalPersonBase JuridicalPerson { get; set; }
        public bool WasViewed { get; set; } = false;
    }

    public class JuridicalPersonNoticesMap : IEntityTypeConfiguration<JuridicalPersonNotices>
    {
        public void Configure(EntityTypeBuilder<JuridicalPersonNotices> builder)
        {
            builder.ToTable("JuridicalPersonNotices");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

            builder.Property(p => p.NoticeId)
                .IsRequired(true);
            builder.Property(p => p.JuridicalPersonId)
                .IsRequired(true);

            builder.HasOne(u => u.Notice)
                .WithMany()
                .HasForeignKey(u => u.NoticeId);
            builder.HasOne(u => u.JuridicalPerson)
                .WithMany()
                .HasForeignKey(u => u.JuridicalPersonId);
        }
    }
}
