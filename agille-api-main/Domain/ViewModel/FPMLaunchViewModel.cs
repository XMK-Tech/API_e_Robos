using System;

namespace AgilleApi.Domain.ViewModel;

public class FPMLaunchParams
{
    public string Description { get; set; }
    public string IncomeAccount { get; set; }
    public string Year { get; set; }

    public decimal? MinCollected { get; set; }
    public decimal? MaxCollected { get; set; }

    public decimal? MinAccumulated { get; set; }
    public decimal? MaxAccumulated { get; set; }

    public DateTime? MinReference { get; set; }
    public DateTime? MaxReference { get; set; }
    public DateTime? Competence { get; set; }

    public string CityConfig { get; set; }
}

public abstract class FPMLaunchViewModelBase
{
    public string Description { get; set; }
    public string IncomeAccount { get; set; }
    public decimal Collected { get; set; }
    public decimal Accumulated { get; set; }
    public DateTime Reference { get; set; }
    public DateTime Competence { get; set; }
    public Guid? CrawlerFileId { get; set; }
}

public class FPMLaunchViewModel : FPMLaunchViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class FPMInsertUpdateViewModel : FPMLaunchViewModelBase
{ }

public class FPMImporParams
{
    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
}