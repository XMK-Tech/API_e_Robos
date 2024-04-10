using AgilleApi.Domain.ViewModel;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IAgiprevCalculationMonthServices
{
    ReportResponseViewModel Calculate(string year, int month);
}