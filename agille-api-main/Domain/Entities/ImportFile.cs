using System;
using System.Collections.Generic;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities
{
    public class ImportFile : Entity
    {
        public ICollection<InvoiceEntry> InvoiceEntries {get;set;}
        public ICollection<TransactionEntry> TransactionEntries {get;set;}

        public ImportFile(ImportType type, ImportStatus status, bool isSimplified, Guid? attachmentId = null)
        {
            Type = type;
            Status = status;
            IsSimplified = isSimplified;
            AttachmentId = attachmentId;
        }
        public Attachment ManualFile {get ;set;}
        public Guid? ManualFileId {get;set;}
        public Attachment Attachment { get; set; }
        public Guid? AttachmentId { get; set; }
        public ImportType Type { get; set; }
        public ImportStatus Status { get; set; }
        public string RejectReason { get; set; }
        public bool IsSimplified {get;set;}
    }

    public class ImportFileMap : IEntityTypeConfiguration<ImportFile>
    {
        public void Configure(EntityTypeBuilder<ImportFile> builder)
        {
            builder.ToTable("ImportFile");
            builder.HasOne<Attachment>(i => i.Attachment)
            .WithOne()
            .HasForeignKey<ImportFile>(h => h.AttachmentId);

            
            builder.HasOne<Attachment>(i => i.ManualFile)
            .WithOne()
            .HasForeignKey<ImportFile>(h => h.ManualFileId);
        }
    }
}