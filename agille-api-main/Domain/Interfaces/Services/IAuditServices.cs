using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IAuditServices
{
    List<Audit> GetEvents(IEnumerable<AuditType> events, Guid id, string targetColumn = null, DateTime ? startingReference = null, DateTime? endingReference = null);
    byte[] ViewLog(AuditParams @params);
}