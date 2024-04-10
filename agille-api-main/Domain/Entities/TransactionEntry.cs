using System;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities
{
    public class TransactionEntry : ImportEntry
    {
        public TransactionEntryType TransactionType { get; set; }
        public string CardOperatorDocument { get; set; }
        public TransactionEntry(decimal value, Guid importFileId, string document, string companyName, DateTime referenceDate, TransactionEntryType transactionType, string cardOperatorDocument) : base(value, importFileId, document, companyName, referenceDate)
        {
            TransactionType = transactionType;
            CardOperatorDocument = cardOperatorDocument;
        }
    }

    public class TransactionEntryMap : IEntityTypeConfiguration<TransactionEntry>
    {
        public void Configure(EntityTypeBuilder<TransactionEntry> builder)
        {
            builder.ToTable("TransactionEntry");
            builder.HasKey(h => h.Id);
            builder.HasOne(h => h.ImportFile).WithMany(h => h.TransactionEntries).HasForeignKey(h => h.ImportFileId);
        }
    }
}