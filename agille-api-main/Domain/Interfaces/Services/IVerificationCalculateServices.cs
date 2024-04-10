using AgilleApi.Domain.ViewModel;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IVerificationCalculateServices
{
    IEnumerable<VerificationViewModel> List(Metadata meta, VerificationParams @params);
}