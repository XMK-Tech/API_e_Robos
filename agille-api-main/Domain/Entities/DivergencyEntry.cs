using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities;

public class DivergencyEntry: BaseDivergencyEntry
{
    public DivergencyEntry(decimal difference, string document, string companyName, DateTime referenceDate, decimal invoiceValue, decimal transactionValue, Guid dataCrossingId)
        :base(difference, document, companyName, referenceDate, invoiceValue, transactionValue)
    {
        DataCrossingId = dataCrossingId;
    }
    public Guid DataCrossingId { get; set; }
    public DataCrossing DataCrossing { get; set; }
}

public class DivergencyEntryMap : IEntityTypeConfiguration<DivergencyEntry>
{
    public void Configure(EntityTypeBuilder<DivergencyEntry> builder)
    {
        builder.ToTable("DivergencyEntry");
        builder.HasKey(h => h.Id);
    }
}