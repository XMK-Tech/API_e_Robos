using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities
{

    public class InvoiceEntry : ImportEntry
    {
        public InvoiceEntry(decimal value, Guid importFileId, string document, string companyName, DateTime referenceDate, string municipalCode) : base(value, importFileId, document, companyName, referenceDate)
        {
            MunicipalCode = municipalCode;
        }

        public string MunicipalCode {get;set;}
    }

    public class InvoiceEntryMap : IEntityTypeConfiguration<InvoiceEntry>
    {
        public void Configure(EntityTypeBuilder<InvoiceEntry> builder)
        {
            builder.ToTable("InvoiceEntry");
            builder.HasKey(h => h.Id);
            builder.HasOne(h => h.ImportFile).WithMany(h => h.InvoiceEntries).HasForeignKey(h => h.ImportFileId);
        }
    }
}