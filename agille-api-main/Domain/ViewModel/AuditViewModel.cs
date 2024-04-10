using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public class AuditParams
{
    public Guid? UserId { get; set; }
    public int Lines = 100;
    public AuditType? Type { get; set; }
    public string IpAddress { get; set; }
}