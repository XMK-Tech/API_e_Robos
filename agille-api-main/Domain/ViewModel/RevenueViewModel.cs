using System;

namespace AgilleApi.Domain.ViewModel;

public class RevenueParams
{
    public int? Index { get; set; }
    
    public string Account { get; set; }
    public string Description { get; set; }
    public string Year { get; set; }

    public decimal? MinPredictedDeductions { get; set; }
    public decimal? MaxPredictedDeductions { get; set; }

    public decimal? MinDeductions { get; set; }
    public decimal? MaxDeductions { get; set; }

    public decimal? MinPredictedUpdated { get; set; }
    public decimal? MaxPredictedUpdated { get; set; }

    public decimal? MinEffectedValue { get; set; }
    public decimal? MaxEffectedValue { get; set; }

    public decimal? MinPredictedValue { get; set; }
    public decimal? MaxPredictedValue { get; set; }

    public decimal? MinCollection { get; set; }
    public decimal? MaxCollection { get; set; }
    public string CityConfig { get; set; }

    public DateTime? Reference { get; set; }


    public bool? IsFromMainEntity { get; set; } = null;
}

public abstract class RevenueViewModelBase
{
    public string Account { get; set; }
    public string Description { get; set; }
    
    public decimal PredictedDeductions { get; set; }
    public decimal Deductions { get; set; }
    public decimal PredictedUpdated { get; set; }
    public decimal EffectedValue { get; set; }
    public decimal PredictedValue { get; set; }
    public decimal Collection { get; set; }

    public DateTime Reference { get; set; }

    public bool IsFromMainEntity { get; set; } = true;
    public Guid? RelatedEntityId { get; set; }
    public string EntityName { get; set; }

    public Guid? CrawlerFileId { get; set; }
}

public class RevenueViewModel : RevenueViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Index { get; set; }
}

public class RevenueInsertUpdateViewModel : RevenueViewModelBase
{ }

public class RevenueImportParams
{
    public DateTime Reference { get; set; }
}