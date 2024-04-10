using AgilleApi.Domain.ViewModel;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ITaxProcessServices
{
    Task<byte[]> Insert(TaxProcessInsertUpdateViewModel model);
}