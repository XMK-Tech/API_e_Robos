using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IITRDeclarationServices
{
    ITRDeclarationViewModel GetITRDeclaration(Guid procedureId);
}