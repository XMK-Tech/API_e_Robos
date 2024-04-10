using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class CardDivergencyEntry : BaseDivergencyEntry
{
    public CardDivergencyEntry() { }
    public CardDivergencyEntry(decimal difference, string document, string companyName, DateTime referenceDate, decimal invoiceValue, decimal transactionValue, Guid reportId, int transactionsCount, decimal averageRate, decimal amountOnAverageRate, decimal declaredRate, decimal amountOnDeclaredRate)
        : base(difference, document, companyName, referenceDate, invoiceValue, transactionValue)
    {
        ReportId = reportId;

        TransactionsCount = transactionsCount;

        AverageRate = averageRate;
        AmountOnAverageRate = amountOnAverageRate;

        DeclaredRate = declaredRate;
        AmountOnDeclaredRate = amountOnDeclaredRate;

        OperatorIsRegistered = !string.IsNullOrEmpty(companyName);
    }

    public int TransactionsCount { get; set; }

    public decimal AverageRate { get; set; }
    public decimal AmountOnAverageRate { get; set; }

    public decimal DeclaredRate { get; set; }
    public decimal AmountOnDeclaredRate { get; set; }

    public bool OperatorIsRegistered { get; set; }

    public Guid ReportId { get; set; }
    public CardCrossingReport Report { get; set; }
}

public class CardDivergencyEntryMap : IEntityTypeConfiguration<CardDivergencyEntry>
{
    public void Configure(EntityTypeBuilder<CardDivergencyEntry> builder)
    {
        builder.ToTable("CardDivergencyEntry");
        builder.HasKey(h => h.Id);

        builder.HasOne(e => e.Report)
            .WithMany(e => e.Divergencies)
            .HasForeignKey(e => e.ReportId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}