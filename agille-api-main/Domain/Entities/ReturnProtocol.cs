using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class ReturnProtocol : Entity
{
    public ReturnProtocol() { }
    public ReturnProtocol(string document, string name, string phone, DateTime date, SignedBy signedBy)
    {
        Document = document;
        Name = name;
        Phone = phone;
        Date = date;
        SignedBy = signedBy;
    }

    public string Document { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime Date { get; set; }
    public SignedBy SignedBy { get; set; }
}

public class ReturnProtocolMap : IEntityTypeConfiguration<ReturnProtocol>
{
    public void Configure(EntityTypeBuilder<ReturnProtocol> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(e => e.Document).HasMaxLength(60).IsRequired();
        builder.Property(e => e.Name).HasMaxLength(120).IsRequired();
        builder.Property(e => e.Phone).HasMaxLength(60).IsRequired();
        builder.Property(e => e.Date).IsRequired();
    }
}