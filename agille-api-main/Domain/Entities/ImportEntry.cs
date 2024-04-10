using System;
using AgilleApi.Domain.Shared;

namespace AgilleApi.Domain.Entities
{
    public abstract class ImportEntry: Entity
    {
        protected ImportEntry(decimal value, Guid importFileId, string document, string companyName, DateTime referenceDate)
        {
            Value = value;
            ImportFileId = importFileId;
            Document = document;
            CompanyName = companyName;
            ReferenceDate = referenceDate;
        }

        public decimal Value { get; set; }
        public Guid ImportFileId { get; set; }
        public ImportFile ImportFile { get; set; }
        public string Document { get; set; }
        public string CompanyName { get; set; }
        public DateTime ReferenceDate {get;set;}
        public bool IsInvalid { get; set; } = false;
    }
}