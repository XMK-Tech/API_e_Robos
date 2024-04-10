using AgilleApi.Domain.ViewModel;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IBareLandValueServices
{
    bool Exist(string year);
    BareLandValuesViewModel GetByYear(string year);
    BareLandValuesViewModel UpSert(BareLandValuesViewModel model, string year);
}