using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class AuditEntry
{
    public AuditEntry(EntityEntry entry)
    {
        Entry = entry;
    }
    
    public EntityEntry Entry { get; }
    public Guid? UserId { get; set; }
    public string TableName { get; set; }
    public string IpAddress { get; set; }
    public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
    public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
    public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
    public string AuditType { get; set; }
    public List<string> ChangedColumns { get; } = new List<string>();
    
    public Audit ToAudit()
    {
        return new()
        {
            UserId = UserId,
            Type = AuditType,
            TableName = TableName,
            IpAddress = IpAddress,
            PrimaryKey = JsonConvert.SerializeObject(KeyValues),
            OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
            AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns)
        };
    }
}