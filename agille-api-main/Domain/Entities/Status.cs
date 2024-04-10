using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
  public class Status : Entity
  {
    public Status(){}

    public Status(string code, string name, string description, string color, Guid statusCategoryId)
    {
      Code = code;
      Name = name;
      Description = description;
      Color = color;
      StatusCategoryId = statusCategoryId;
    }

    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public Guid StatusCategoryId { get; set; }
    public StatusCategory StatusCategory { get; set; }
  }
  public class StatusMap : IEntityTypeConfiguration<Status>
  {
    public void Configure(EntityTypeBuilder<Status> builder)
    {
      builder.ToTable("Status");
      builder.HasKey(h => h.Id);

      builder.HasOne(s => s.StatusCategory)
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict)
          .HasForeignKey(ad => ad.StatusCategoryId);

      builder.Property(e => e.Code).HasMaxLength(200).IsRequired();
      builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
      builder.Property(e => e.Description).HasMaxLength(500).IsRequired();
      builder.Property(e => e.Color).HasMaxLength(10).IsRequired();
    }
  }
}
