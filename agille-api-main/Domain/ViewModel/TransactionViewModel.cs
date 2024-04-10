using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AgilleApi.Domain.ViewModel
{
    public class TransactionInsertUpdateViewModel
    {
        [Required]
        public TransactionType TransactionType { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        [Required]
        public Guid? AccountCategoryId { get; set; }
        [Required]
        public float? Amount { get; set; }
        public bool FromBank { get; set; }
        [JsonIgnore]
        public Guid StatusId { get; set; }
        [JsonIgnore]
        public Guid CreatedById { get; set; }
        [JsonIgnore]
        public Guid UpdatedById { get; set; }
    }
    public class TransactionParams
    {
        public string Document { get; set; }
        public string CardOperatorDocument { get; set; }
        public Guid DataCrossId { get; set; }
    }

    public class BaseInterval
    {
        public DateTime StartingReference { get; set; }
        public DateTime EndingReference { get; set; }
    }

    public class TransactionViewModel
    {
        public TransactionViewModel(Guid? id, string transactionType, DateTime? date, string notes, string paymentMethod, Guid? accountCategoryId, string accountCategory, float? amount, string operatorDocument = null)
        {
            Id = id;
            TransactionType = transactionType;
            Date = date;
            Notes = notes;
            PaymentMethod = paymentMethod;
            AccountCategoryId = accountCategoryId;
            AccountCategory = accountCategory;
            Amount = amount;
            OperatorDocument = operatorDocument;
        }

        public Guid? Id { get; set; }
        public string TransactionType { get; set; }
        public DateTime? Date { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        public Guid? AccountCategoryId { get; set; }
        public string AccountCategory { get; set; }
        public float? Amount { get; set; }
        public string OperatorDocument  { get; set; }
        public bool IsInvalid { get; set; }
    }
    public class TransactionParam
    {
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }
        public string Notes { get; set; }
        public Guid? AccountCategoryId { get; set; }
        public float? AmountMin { get; set; }
        public float? AmountMax { get; set; }
    }
    public class TransactionListViewModel : TransactionViewModel
    {
        public TransactionListViewModel(Guid id, string transactionType, DateTime date, string notes, string paymentMethod, Guid? accountCategoryId, string accountCategory, float amount) : base(id, transactionType, date, notes, paymentMethod, accountCategoryId, accountCategory, amount)
        {
        }

        public bool Editable { get; set; } = true;
    }

    public class TransactionsDataViewModel<T>
    {
        public TransactionsDataViewModel() { }
        public TransactionsDataViewModel(DateTime startReference, DateTime endingReference, int totalTransactions, IEnumerable<T> data)
        {
            StartReference = startReference;
            EndingReference = endingReference;
            TotalTransactions = totalTransactions;
            Data = data;
        }

        public DateTime StartReference { get; set; }
        public DateTime EndingReference { get; set; }
        public int TotalTransactions { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
    
    public abstract class TransactionTotalCountViewModelBase
    {
        public string Year { get; set; }
        public int MonthId { get; set; }
        public string MonthName { get; set; }
    }

    public class TransactionsCountVieModel : TransactionTotalCountViewModelBase
    {
        public TransactionsCountVieModel() { }
        public TransactionsCountVieModel(string year, int monthId, string monthName, int countCreditCard, int countDebitCard)
        {
            Year = year;
            MonthId = monthId;
            MonthName = monthName;
            CountCreditCard = countCreditCard;
            CountDebitCard = countDebitCard;
        }

        public int CountCreditCard { get; set; }
        public int CountDebitCard { get; set; }
    }
    public class TransactionsTotalViewModel : TransactionTotalCountViewModelBase
    {
        public TransactionsTotalViewModel() { }
        public TransactionsTotalViewModel(string year, int monthId, string monthName, decimal totalCreditCard, decimal totalDebitCard)
        {
            Year = year;
            MonthId = monthId;
            MonthName = monthName;
            TotalCreditCard = totalCreditCard;
            TotalDebitCard = totalDebitCard;
        }

        public decimal TotalCreditCard { get; set; }
        public decimal TotalDebitCard { get; set; }
    }
}
// 