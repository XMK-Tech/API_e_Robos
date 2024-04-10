using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public abstract class ReturnProtocolViewModelBase
{
    public ReturnProtocolViewModelBase() { }
    public ReturnProtocolViewModelBase(string document, string name, string phone, DateTime date, SignedBy signedBy)
    {
        Document = document;
        Name = name;
        Phone = phone;
        Date = date;
        SignedBy = signedBy;
    }

    public string Document { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime Date { get; set; }
    public SignedBy SignedBy { get; set; }
}

public class ReturnProtocolViewModel : ReturnProtocolViewModelBase
{
    public ReturnProtocolViewModel() { }
    public ReturnProtocolViewModel(string document, string name, string phone, DateTime date, Guid id, SignedBy signedBy)
        : base(document, name, phone, date, signedBy)
    {
        Id = id;
        SignedByDescription = signedBy.GetDescription();
    }

    public Guid Id { get; set; }
    public string SignedByDescription { get; set; }
}

public class ReturnProtocolInsertViewModel : ReturnProtocolViewModelBase { }