using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgilleApi.Domain.ViewModel;

public class TaxProcedureParams
{
    public string IntimationYear { get; set; }
    public string ProcessNumber { get; set; }
    public string CibNumber { get; set; }
    public string ProprietyName { get; set; }
    public ProcedureParamType? ParamType { get; set; }
    public ProcedureStatus? Status { get; set; } 
    public DateTime? CreatedAt { get; set; }
}

public abstract class TaxProcedureViewModelBase
{
    public string IntimationYear { get; set; }
    public string ProcessNumber { get; set; }
    public List<ProcedureParamType> TaxParams { get; set; }
    public ProcedureStatus Status { get; set; }
}

public class TaxProcedureViewModel : TaxProcedureViewModelBase
{
    public Guid Id { get; set; }
    public string CibNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<TaxStageViewModel> Stages { get; set; }
    public ProprietyViewModel Propriety { get; set; }
}

public class TaxProcedureInsertUpdateViewModelViewModel : TaxProcedureViewModelBase
{
    public Guid ProprietyId { get; set; }
}

public class TaxProcedureDashboard
{
    public TaxProcedureDashboard(int total, DateTime reference, List<TaxProcedureDashboardItem> itens)
    {
        Total = total;
        Itens = itens;

        StartingReference = reference.Date.AddYears(-1).AddMonths(1);
        EndingReference = reference.Date;
    }

    public int Total { get; set; }
    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
    public List<TaxProcedureDashboardItem> Itens { get; set; } = new();
}

public class TaxProcedureDashboardItem
{
    public TaxProcedureDashboardItem(int count, int year, int month)
    {
        Count = count;
        Date = new DateTime(year, month, 1);

        Month = Date.ToString("MMMM");
        Year = Date.Year.ToString();
    }

    public int Count { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public DateTime Date { get; set; }
}

public class BaseTaxProcedureReportModel
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [JsonIgnore]
    public string UserName { get; set; }
    [JsonIgnore]
    public string Image { get; set; }
}

public class TaxProcedureReportModel : BaseTaxProcedureReportModel
{
    [JsonIgnore]
    public List<TaxProcedureReportItem> Itens { get; set; }
}

public class TaxProcedureReportItem
{
    public TaxProcedureReportItem(TaxStage entity, string processNumber)
    {
        if (entity == null)
            return;

        ResponseDate = entity.CutOffDate;
        ProcessNumber = processNumber;

        DateTime? answeredin = entity?.AnsweredByStage?.CertificationDate;
        Tempest = (answeredin.HasValue && ResponseDate.HasValue && answeredin.Value.Date <= ResponseDate.Value.Date) ? "Sim" : "Não";
    }

    public DateTime? ResponseDate { get; set; }
    public string ProcessNumber { get; set; }
    public string Tempest { get; set; }
}

public class TaxProcedureReportLogModel : BaseTaxProcedureReportModel
{
    [JsonIgnore]
    public List<TaxProcedureReportLogItem> Itens { get; set; }
}

public class TaxProcedureReportLogItem
{
    public TaxProcedureReportLogItem(string processNumber, string activity, DateTime date, string resposible)
    {
        ProcessNumber = processNumber;
        Activity = activity;
        Date = date;
        Responsible = resposible;
    }

    public Guid ProcedureId { get; set; }
    public string ProcessNumber { get; set; }
    
    public string Activity { get; set; }
    public DateTime Date { get; set; }
    public string Responsible { get; set; }
}