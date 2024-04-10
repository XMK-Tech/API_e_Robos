using System;

namespace AgilleApi.Domain.ViewModel;

public class VerificationParams
{
    public string Exercise { get; set; }
    public string Year { get; set; }

    public decimal? MaxArbitrate { get; set; }
    public decimal? MinArbitrate { get; set; }

    public decimal? MaxUpdate { get; set; }
    public decimal? MinUpdate { get; set; }
}

public abstract class VerificatinViewModelBase
{
    public string Exercise { get; set; }
    public decimal ValueToArbitrate { get; set;}
    public decimal UpdateValue { get; set; }
}

public class VerificationViewModel : VerificatinViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CalculationUrlViewModel
{
    public string Url { get; set; }
}