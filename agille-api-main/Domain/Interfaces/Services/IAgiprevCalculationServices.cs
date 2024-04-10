using AgilleApi.Domain.ViewModel;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IAgiprevCalculationServices
{
    ReportResponseViewModel Calculate(string year);
    decimal CalculateAmountToArbitrate(string year, string month);
}