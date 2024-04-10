using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class RubricParams
{
    public string Name { get; set; }
    public string Year { get; set; }

    public Guid? StateId { get; set; }
    
    public DateTime? Reference { get; set; }
}

public abstract class RubricViewModelBase
{
    public string Name { get; set; }
    public Guid StateId { get; set; }
    public DateTime Reference { get; set; }
}

public class RubricViewModel : RubricViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string StateName { get; set; }
    public int TotalAccounts { get; set; }
}

public class RubricInsertUpdateViewModel : RubricViewModelBase
{
    public List<RubricAccountInsertUpdateViewModel> Accounts = new();
}

public class RubricAccountViewModelBase
{
    public string Account { get; set; }
    public string Title { get; set; }
    public string Function { get; set; }
    public string Detail { get; set; }

    public RubricAccountStatus Status { get; set; }
    public RubricAccountOrigin OriginOfBalance { get; set; }

    public string Classifications { get; set; }
}

public class RubricAccountViewModel : RubricAccountViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public string StatusDescription { get => Status.GetDescription(); }
    public string OriginOfBalanceDescription { get => OriginOfBalance.GetDescription(); }
}

public class RubricAccountInsertUpdateViewModel : RubricAccountViewModelBase
{ }

public class FilterSumViewModel
{
    public decimal Sum { get; set; }
    public int Count { get; set; }
}