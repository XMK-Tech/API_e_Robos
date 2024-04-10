using AgilleApi.Domain.Entities;
using System;

namespace AgilleApi.Domain.ViewModel;

public abstract class BaseDivergencyEntryViewModel
{
    public BaseDivergencyEntryViewModel() { }
    public BaseDivergencyEntryViewModel(BaseDivergencyEntry divergency)
    {
        Id = divergency.Id;
        InvoiceValue = Round(divergency.InvoiceValue);
        TransactionValue = Round(divergency.TransactionValue);
        Difference = Round(divergency.Difference);
        Document = divergency.Document;
        CompanyName = divergency.CompanyName;
        ReferenceDate = divergency.ReferenceDate;
        IsInvalid = divergency.IsInvalid;
    }
    public BaseDivergencyEntryViewModel(Guid id, decimal difference, string document, string companyName, DateTime referenceDate, decimal invoiceValue, decimal transactionValue, bool isInvalid)
    {
        Id = id;
        InvoiceValue = Round(invoiceValue);
        TransactionValue = Round(transactionValue);
        Difference = Round(difference);
        Document = document;
        CompanyName = companyName;
        ReferenceDate = referenceDate;
        IsInvalid = isInvalid;
    }

    public Guid Id { get; set; }
    public decimal InvoiceValue { get; set; }
    public decimal TransactionValue { get; set; }
    public decimal Difference { get; set; }
    public string Document { get; set; }
    public string CompanyName { get; set; }
    public DateTime ReferenceDate { get; set; }
    public bool IsInvalid { get; set; }
    protected static decimal Round(decimal number) => Math.Round(number, 2);
}

public class DivergencyEntryViewModel : BaseDivergencyEntryViewModel
{
    public DivergencyEntryViewModel() { }
    public DivergencyEntryViewModel(BaseDivergencyEntry divergency)
        : base(divergency)
    {
        if(divergency is DivergencyEntry div)
            DataCrossingId = div.DataCrossingId;
        else if(divergency is CardDivergencyEntry card)
            DataCrossingId = card.ReportId;
    }
    public DivergencyEntryViewModel(Guid id, decimal difference, string document, string companyName, DateTime referenceDate, decimal invoiceValue, decimal transactionValue, Guid dataCrossingId, bool isInvalid)
        : base(id, difference, document, companyName, referenceDate, invoiceValue, transactionValue, isInvalid)
    {
        DataCrossingId = dataCrossingId;
    }

    public Guid DataCrossingId { get; set; }
}

public class CardDivergencyEntryViewModel
{
    public CardDivergencyEntryViewModel() { }
    public CardDivergencyEntryViewModel(CardDivergencyEntry divergency)
    {
        OperatorName = divergency.CompanyName;
        OperatorDocument = divergency.Document;
        OperatorIsRegistered = divergency.OperatorIsRegistered;

        IsInvalid = divergency.IsInvalid;

        Date = divergency.ReferenceDate;

        Amount = Round(divergency.TransactionValue);
        DeclaredTransactedValue = Round(divergency.InvoiceValue);
        DeclaredAndAverageDivergence = Round(Amount - DeclaredTransactedValue);


        CrossId = divergency.ReportId;
        SubOperationId = divergency.Id;

        Year = divergency.ReferenceDate.Year.ToString();
        Month = divergency.ReferenceDate.Month.ToString();

        TransactionsCount = divergency.TransactionsCount;
        AverageRate = Round(divergency.AverageRate);
        DeclaredRate = Round(divergency.DeclaredRate);

        AmountOnAverageRate = Round(divergency.AmountOnAverageRate);
        AmountOnDeclaredRate = Round(divergency.AmountOnDeclaredRate);
    }

    public Guid CrossId { get; set; }
    public Guid SubOperationId { get; set; }

    public string OperatorName { get; set; }
    public string OperatorDocument { get; set; }
    public bool OperatorIsRegistered { get; set; }
    public bool IsInvalid { get; set; }

    public decimal Amount { get; set; }
    public int TransactionsCount { get; set; }

    public decimal AverageRate { get; set; }
    public decimal AmountOnAverageRate { get; set; }

    public decimal DeclaredRate { get; set; }
    public decimal AmountOnDeclaredRate { get; set; }

    public decimal DeclaredTransactedValue { get; set; }
    public decimal DeclaredAndAverageDivergence { get; set; }

    public DateTime Date { get; set; }

    public string Year { get; set; }
    public string Month { get; set; }

    protected static decimal Round(decimal number) => Math.Round(number, 2);
}