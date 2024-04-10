using System;
using System.Collections.Generic;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities
{
    public class DataCrossing : Entity
    {
        public DataCrossing(DataCrossingStatus status, DateTime startingReference, DateTime endingReference, Guid? responsibleId)
        {
            Status = status;
            StartingReference = startingReference;
            EndingReference = endingReference;
            ResponsibleId = responsibleId;
        }

        public DataCrossingStatus Status { get; set; }
        public DateTime StartingReference { get; set; }
        public Guid? ResponsibleId { get; set; }
        public DateTime EndingReference { get; set; }
        public ICollection<InvoiceEntry> InvoiceEntries { get; set; }
        public ICollection<TransactionEntry> TransactionEntries { get; set; }
        public ICollection<DivergencyEntry> DivergencyEntries { get; set; }
    }

    public class DataCrossingMap : IEntityTypeConfiguration<DataCrossing>
    {
        public void Configure(EntityTypeBuilder<DataCrossing> builder)
        {
            builder.ToTable("DataCrossing");
            builder.HasKey(h => h.Id);
            builder.HasMany(dc => dc.DivergencyEntries)
            .WithOne(dc => dc.DataCrossing)
            .HasForeignKey(dc => dc.DataCrossingId);

        }
    }
}