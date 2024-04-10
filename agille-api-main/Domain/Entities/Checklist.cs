using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class Checklist : Entity
{
    public Checklist() { }
    public Checklist(string text, ChecklistStatus status)
    {
        Text = text;
        Status = status;
    }

    public string Text { get; set; }
    public ChecklistStatus Status { get; set; }
    public string Justification { get; set; }
    public Guid? UserId { get; set; }

    public ICollection<ChecklistAttachment> Attachments { get; set; }
}

public class ChecklistMap : IEntityTypeConfiguration<Checklist>
{
    public void Configure(EntityTypeBuilder<Checklist> builder)
    {
        builder.HasKey(h => h.Id);
    }
}