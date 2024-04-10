using AgilleApi.Domain.ViewModel;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IPersonImportServices
{
    CsvResponseViewModel InsertCSV(CsvInsertViewModel fileBody);
}