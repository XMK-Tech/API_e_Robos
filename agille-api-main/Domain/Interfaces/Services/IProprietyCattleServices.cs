using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IProprietyCattleServices
{
    void Upsert(CattleManyViewModel entities);
    IEnumerable<ProprietyCattleViewModel> View(Guid proprietyId);
}