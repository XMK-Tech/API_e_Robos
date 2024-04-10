using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class Audit : Entity
{
    public Audit() { }
    public Audit(Guid? userId, string type, string tableName, string oldValues, string newValues, string affectedColumns, string primaryKey, string ipAddress)
    {
        UserId = userId;
        Type = type;
        TableName = tableName;
        OldValues = oldValues;
        NewValues = newValues;
        AffectedColumns = affectedColumns;
        PrimaryKey = primaryKey;
        IpAddress = ipAddress;
    }

    public Guid? UserId { get; set; }
    public string Type { get; set; }
    public string TableName { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
    public string AffectedColumns { get; set; }
    public string PrimaryKey { get; set; }
    public string IpAddress { get; set; }
}

public class AuditMap : IEntityTypeConfiguration<Audit>
{
    public void Configure(EntityTypeBuilder<Audit> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.TableName).HasMaxLength(75).IsRequired();
    }
}