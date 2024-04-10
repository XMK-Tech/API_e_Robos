using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities
{
  public class DynamicFieldOptions : Entity
  {
    public DynamicFieldOptions()
    {

    }
    public DynamicFieldOptions(string code, string display_table, string display_column, string schema = null, string table = null, string column = null, string columnKey = null)
    {
      Code = code;
      DisplayTable = display_table;
      DisplayColumn = display_column;
      Table = table;
      Column = column;
      ColumnKey = columnKey;
      Schema = schema;
    }

    public string Code { get; set; }
    public string DisplayTable { get; set; }
    public string DisplayColumn { get; set; }
    public string Schema { get; set; }
    public string Table { get; set; }
    public string Column { get; set; }
    public string ColumnKey { get; set; }
  }

  public class DynamicFieldOptionsMap : IEntityTypeConfiguration<DynamicFieldOptions>
  {
    public void Configure(EntityTypeBuilder<DynamicFieldOptions> builder)
    {
      builder.ToTable("DynamicFieldOptions");
      builder.HasKey(h => h.Id);

      builder.Property(e => e.Code).HasMaxLength(50).IsRequired();
      builder.Property(e => e.DisplayTable).HasMaxLength(50).IsRequired();
      builder.Property(e => e.DisplayColumn).HasMaxLength(50).IsRequired();
      builder.Property(e => e.Schema).HasMaxLength(50).IsRequired(false);
      builder.Property(e => e.Table).HasMaxLength(50).IsRequired(false);
      builder.Property(e => e.Column).HasMaxLength(50).IsRequired(false);
      builder.Property(e => e.ColumnKey).HasMaxLength(50).IsRequired(false);
    }
  }
}
