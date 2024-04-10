using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace AgilleApi.Data.ContextDb;

public class ContextLogger
{
    private readonly ISessionServices _sessionServices;

    public ContextLogger(ISessionServices sessionServices)
    {
        _sessionServices = sessionServices;
    }

    public Audit CreateLog(EntityEntry entry)
    {
        if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
            return null;

        var auditEntry = new AuditEntry(entry)
        {
            TableName = entry.Entity.GetType().Name,
            UserId = _sessionServices.GetUserId(),
            IpAddress = _sessionServices.RemoteIpAddress()
        };
        
        foreach (var property in entry.Properties)
        {
            string propertyName = property.Metadata.Name;
            var originalValue = entry?.GetDatabaseValues()?.GetValue<object>(propertyName);
            
            if (property.Metadata.IsPrimaryKey())
            {
                auditEntry.KeyValues[propertyName] = property.CurrentValue;
                continue;
            }
            switch (entry.State)
            {
                case EntityState.Added:
                    auditEntry.AuditType = AuditType.Create.GetDescription();
                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                    break;
                case EntityState.Deleted:
                    auditEntry.AuditType = AuditType.Delete.GetDescription();
                    auditEntry.OldValues[propertyName] = originalValue;
                    break;
                case EntityState.Modified:
                    if (property.IsModified)
                    {
                        if (originalValue?.ToString() != property?.CurrentValue?.ToString())
                            auditEntry.ChangedColumns.Add(propertyName);

                        auditEntry.AuditType = AuditType.Update.GetDescription();
                        auditEntry.OldValues[propertyName] = originalValue;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                    }
                    break;
            }
        }

        return auditEntry.ToAudit();
    }
}