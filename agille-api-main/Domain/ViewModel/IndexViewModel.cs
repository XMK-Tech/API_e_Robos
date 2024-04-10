using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public class IndexParams
{
    public string Year { get; set; }

    public IndexType? Type { get; set; }
    
    public decimal? Percentage { get; set; }

    public DateTime? Reference { get; set; }
}

public abstract class IndexViewModelBase
{
    public IndexType Type { get; set; }
    public decimal Percentage { get; set; }
    public DateTime Reference { get; set; }
}

public class IndexViewModel : IndexViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string TypeDescription { get => Type.GetDescription(); }
}

public class IndexInsertUpdateViewModel : IndexViewModelBase
{ }