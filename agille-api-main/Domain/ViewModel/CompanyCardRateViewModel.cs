using System;

namespace AgilleApi.Domain.ViewModel;

public abstract class CompanyCardRateViewModelBase
{
    public CompanyCardRateViewModelBase() { }
    public CompanyCardRateViewModelBase(double rate, Guid companyId, Guid cardOperatorId, string cardOperatorName, string companyName, string companyDocument)
    {
        Rate = rate;
        CompanyId = companyId;
        CardOperatorId = cardOperatorId;
        CardOperatorName = cardOperatorName;
        CompanyName = companyName;
        CompanyDocument = companyDocument;
    }

    public double Rate { get; set; }
    public Guid CompanyId { get; set; }
    public Guid CardOperatorId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyDocument { get; set; }
    public string CardOperatorName { get; set; }
}

public class CompanyCardRateViewModel : CompanyCardRateViewModelBase
{
    public CompanyCardRateViewModel() { }
    public CompanyCardRateViewModel(Guid id, double rate, Guid companyId, Guid cardOperatorId, string cardOperatorName, string companyName, string companyDocument)
        : base(rate, companyId, cardOperatorId, cardOperatorName, companyName, companyDocument)
    { 
        Id = id;
    }

    public Guid Id { get; set; }
}

public class CompanyCardRateInsertUpdateViewModel : CompanyCardRateViewModelBase
{
    public CompanyCardRateInsertUpdateViewModel() { }
    public CompanyCardRateInsertUpdateViewModel(double rate, Guid companyId, Guid cardOperatorId, string cardOperatorName, string companyName, string companyDocument)
        : base(rate, companyId, cardOperatorId, cardOperatorName, companyName, companyDocument)
    { }
}

public class CardOperatorAverageViewModel
{
    public CardOperatorAverageViewModel() { }
    public CardOperatorAverageViewModel(Guid cardOperatorId, decimal declaredRate, decimal average, int count)
    {
        CardOperatorId = cardOperatorId;
        DeclaredRate = Round(declaredRate);
        Average = Round(average);
        Count = count;
    }
    public CardOperatorAverageViewModel(string document, decimal declaredRate, decimal average, int count)
    {
        CardOperatorDocument = document;
        DeclaredRate = Round(declaredRate);
        Average = Round(average);
        Count = count;
    }

    public Guid? CardOperatorId { get; set; }
    public string CardOperatorDocument { get; set; }
    public decimal? DeclaredRate { get; set; }
    public decimal Average { get; set; }
    public int Count { get; set; }

    protected static decimal Round(decimal number) => Math.Round(number, 2);
}