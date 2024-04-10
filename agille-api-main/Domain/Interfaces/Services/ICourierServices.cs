using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using PostOfficeConsumer;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ICourierServices
{
    Task<enderecoERP> GetAddress(string zipCode);
    Task<byte[]> TryPost(CourierDataViewModel data);
}