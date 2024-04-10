using System;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel
{
    public class BankListViewModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
    }
    public class BankListViewModelResult
    {
        public BankListViewModelResult(Guid id, Guid personId, string number, string name, string agency, string agencyDigit, string accountNumber, string accountDigit)
        {
            Id = id;
            PersonId = personId;
            Number = number;
            Name = name;
            Agency = agency;
            AgencyDigit = agencyDigit;
            AccountNumber = accountNumber;
            AccountDigit = accountDigit;
        }

        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Agency { get; set; }
        public string AgencyDigit { get; set; }
        public string AccountNumber { get; set; }
        public string AccountDigit { get; set; }
    }

  public class BankInsertUpdateViewModel
  {
    [Required]
    public Guid? PersonId { get; set; }
    [Required]
    public string Number { get; set; }// Número do banco, ex: 001
    [Required]
    public string Name { get; set; }// Nome do banco, ex: Banco do Brasil
    [Required]
    public string Agency { get; set; }// Número do agência, ex: 0941
    // Na doc o AgencyDigit é obrigatorio, mas nem todo Banco tem um
    public string AgencyDigit { get; set; }// Dígito da agência, ex: 5
    [Required]
    public string AccountNumber { get; set; }// Número da conta, ex: 22007
    // Na doc o AccountDigit é obrigatorio, mas nem todo Banco tem um
    public string AccountDigit { get; set; }// Dígito da conta, ex: 8
  }

}
