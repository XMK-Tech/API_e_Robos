using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities
{
  public class Attachment : Entity
  {
    public Attachment()
    {

    }
    public Attachment(string type, string url, string urlMetadata, string externalId, string displayName, string table, string tableId)
    {
      Type = type;
      Url = url;
      UrlMetadata = urlMetadata;
      ExternalId = externalId;
      DisplayName = displayName;
      Owner = table;
      OwnerId = tableId;
    }

    public string Type { get; set; }
    public string Url { get; set; }
    public string UrlMetadata { get; set; }
    public string ExternalId { get; set; }
    public string DisplayName { get; set; }
    public string Owner { get; set; }
    public string OwnerId { get; set; }
  }

  public class AttachmentMap : IEntityTypeConfiguration<Attachment>
  {
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
      builder.ToTable("Attachment");
      builder.HasKey(h => h.Id);

      builder.Property(e => e.Type).HasMaxLength(200).IsRequired();
      builder.Property(e => e.Url).HasMaxLength(500).IsRequired();
      builder.Property(e => e.UrlMetadata).HasMaxLength(500).IsRequired();
      builder.Property(e => e.ExternalId).HasMaxLength(200).IsRequired();
      builder.Property(e => e.DisplayName).HasMaxLength(200).IsRequired();
      builder.Property(e => e.Owner).HasMaxLength(200).IsRequired();
      builder.Property(e => e.OwnerId).HasMaxLength(200).IsRequired();
    }
  }
}
