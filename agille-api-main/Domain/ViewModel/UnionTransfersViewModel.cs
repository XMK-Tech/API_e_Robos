using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgilleApi.Domain.ViewModel;

public class UnionTransfersParams
{
    public DateTime? StartingReference { get; set; }
    public DateTime? EndingReference { get; set; }
    public decimal? MinValue { get; set; }
    public decimal? MaxValue { get; set; }
    public UnionTransfersStatus? Status { get; set; }
}

public abstract class UnionTransfersViewModelBase
{
    public UnionTransfersViewModelBase() { }
    public UnionTransfersViewModelBase(decimal value, DateTime date, UnionTransfersStatus status)
    {
        Value = value;
        Date = date;
        Status = status;
    }

    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public UnionTransfersStatus Status { get; set; }
}

public class UnionTransfersViewModel : UnionTransfersViewModelBase
{
    public UnionTransfersViewModel() { }
    public UnionTransfersViewModel(decimal value, DateTime date, UnionTransfersStatus status, Guid id) 
        : base(value, date, status)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class UnionTransfersInsertUpdateViewModel : UnionTransfersViewModelBase { }

public class UnionTransfersDashboard
{
    public UnionTransfersDashboard(decimal totalValue, DateTime reference, IEnumerable<UnionTransfersDashboardItem> itens)
    {
        TotalValue = totalValue;
        Itens = itens;

        StartingReference = reference.Date.AddYears(-1).AddMonths(1);
        EndingReference = reference.Date;        
    }

    public decimal TotalValue { get; set; }
    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
    public IEnumerable<UnionTransfersDashboardItem> Itens { get; set; }
}

public class UnionTransfersDashboardItem
{
    public UnionTransfersDashboardItem(decimal value, int year, int month)
    {
        Value = value;
        Date = new DateTime(year, month, 1);

        Month = Date.ToString("MMMM");
        Year = Date.Year.ToString();        
    }

    public decimal Value { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public DateTime Date { get; set; }
}

public class UnionTransferReportModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [JsonIgnore]
    public string UserName { get; set; }
    [JsonIgnore]
    public string Image { get; set; }
    [JsonIgnore]
    public List<UnionTransferReportItem> Itens { get; set; }
}

public class UnionTransferReportItem
{
    public UnionTransferReportItem(int month, int year, decimal value)
    {
        Reference = new(year, month, 1);
        Value = value;
    }

    public DateTime Reference { get; set; }
    public decimal Value { get; set; }
}