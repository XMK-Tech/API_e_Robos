using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class RubricAccount : Entity
{
    public RubricAccount() { }

    public RubricAccount(string account, string title, string function, string detail, RubricAccountStatus status, RubricAccountOrigin origin, string classifications, Guid id) 
    {
        Account = account;
        Title = title;
        Function = function;
        Detail = detail;
        Status = status;
        OriginOfBalance = origin;
        Classifications = classifications;
        RubricId = id;
    }

    public string Account { get; set; }
    public string Title { get; set; }
    public string Function { get; set; }
    public string Detail { get; set; }

    public RubricAccountStatus Status { get; set; }
    public RubricAccountOrigin OriginOfBalance { get; set; }

    public string Classifications { get; set; }

    public Guid RubricId { get; set; }
    public Rubric Rubric { get; set; }
}

public class RubricAccountMap : IEntityTypeConfiguration<RubricAccount>
{
    public void Configure(EntityTypeBuilder<RubricAccount> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(s => s.Rubric)
            .WithMany(rubric => rubric.Accounts)
            .OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(ad => ad.RubricId)
            .IsRequired();
    }
}