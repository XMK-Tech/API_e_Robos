using System;

namespace AgilleApi.Domain.ViewModel
{
    public class EmployeeViewModel
    {
    public EmployeeViewModel()
    {

    }
        public EmployeeViewModel(string position, string code, float salary, float technicalHourValue, DateTime contractionDate, DateTime? resignationDate, string displayName, string profileName, Guid id)
        {
            Position = position;
            Code = code;
            Salary = salary;
            TechnicalHourValue = technicalHourValue;
            ContractionDate = contractionDate;
            ResignationDate = resignationDate;
            DisplayName = displayName;
            ProfileName = profileName;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Position { get; set; }
        public string Code { get; set; }
        public float Salary { get; set; }
        public float TechnicalHourValue { get; set; }
        public DateTime ContractionDate { get; set; }
        public Nullable<DateTime> ResignationDate { get; set; }
        public string DisplayName { get; set; }
        public string ProfileName { get; set; }
    }

    public class EmployeeListViewModel
    {
        public EmployeeListViewModel(Guid id, string code, string position, DateTime contractionDate, DateTime? resignationDate, bool status)
        {
            Id = id;
            Code = code;
            Position = position;
            ContractionDate = contractionDate;
            ResignationDate = resignationDate;
            Status = status;
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Position { get; set; }
        public DateTime ContractionDate { get; set; }
        public Nullable<DateTime> ResignationDate { get; set; }
        public bool Status { get; set; }
    }
    public class EmployeeParams
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Position { get; set; }
        public DateTime ContractionDateMin { get; set; }
        public DateTime ContractionDateMax { get; set; }
        public Nullable<DateTime> ResignationDateMin { get; set; }
        public Nullable<DateTime> ResignationDateMax { get; set; }
        public bool Status { get; set; }
    }

    public class ListBankAccounts
    {
        public ListBankAccounts(Guid bankId, string number, string agency, string accountNumber, bool primaryAccount)
        {
            BankId = bankId;
            Number = number;
            Agency = agency;
            PrimaryAccount = primaryAccount;

      //ex.: 0123456789
      if (accountNumber.Length >= 4)
      {
        string initialCarac = "";
        for (var i = 0; i < accountNumber.Length - 3; i++)
          initialCarac += "*";

        var lastCarac = "";
        lastCarac = accountNumber.Substring(accountNumber.Length - 3);
        AccountNumber = initialCarac + lastCarac;
      }
      else
        AccountNumber = accountNumber;
      //*******789
    }

        public Guid BankId { get; set; }
        public string Number { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
        public bool PrimaryAccount { get; set; }
    }
    public class BankAccountsInsertViewModel
    {
        public string Number { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
    }
    public class Salaries
    {
        public Salaries(Guid? id, DateTime? paymentDate, float? amount)
        {
            Id = id;
            PaymentDate = paymentDate;
            Amount = amount;
        }

        public Guid? Id { get; set; }
        public DateTime? PaymentDate { get; set; }
        public float? Amount { get; set; }
    }
}
