using AgilleApi.Domain.ViewModel;
using System;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IARServices
{
    Task<ARViewModel> CourierBaseAddress(Guid subjectId);
    Task<byte[]> GenerateAR(ARViewModel model, Guid subjectId);
    Task<byte[]> GenerateAR(CourierDataViewModel model);
    Task<(byte[], string)> JoinTerm(ForwardingTermInsertUpdateViewModel model, Guid subjectId);
}