using AgilleApi.Domain.Shared;
using System;

namespace AgilleApi.Domain.Entities;

public class BaseDivergencyEntry : Entity
{
    public BaseDivergencyEntry() { }
    public BaseDivergencyEntry(decimal difference, string document, string companyName, 
        DateTime referenceDate, decimal invoiceValue, decimal transactionValue)
    {
        Difference = difference;
        Document = document;
        CompanyName = companyName;
        ReferenceDate = referenceDate;
        InvoiceValue = invoiceValue;
        TransactionValue = transactionValue;
    }

    public decimal InvoiceValue { get; set; }
    public decimal TransactionValue { get; set; }
    public decimal Difference { get; set; }
    public string Document { get; set; }
    public string CompanyName { get; set; }
    public DateTime ReferenceDate { get; set; }
    public bool IsInvalid { get; set; } = false;
}