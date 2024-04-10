using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IInvalidateDivergenciesServices
{
    void Invalidate(List<DateTime> references);
}