using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IVerificationServices
{
    VerificationViewModel View(Guid id);
    FilterSumViewModel GetFilterSum(VerificationParams @params);
    void InsertCompetenceIfNotExists(DateTime competence);
}