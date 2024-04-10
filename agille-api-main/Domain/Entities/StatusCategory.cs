using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities
{
  public class StatusCategory : Entity
  {
    public StatusCategory()
    {

    }
    public StatusCategory(string code, string name, string description)
    {
      Code = code;
      Name = name;
      Description = description;
    }

    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
  public class StatusCategoryMap : IEntityTypeConfiguration<StatusCategory>
  {
    public void Configure(EntityTypeBuilder<StatusCategory> builder)
    {
      builder.ToTable("StatusCategories");
      builder.HasKey(h => h.Id);

      builder.Property(e => e.Code).HasMaxLength(200).IsRequired();
      builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
      builder.Property(e => e.Description).HasMaxLength(500).IsRequired();
    }
  }
}
