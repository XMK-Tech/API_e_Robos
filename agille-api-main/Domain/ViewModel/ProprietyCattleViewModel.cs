using AgilleApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public abstract class ProprietyCattleViewModelBase
{
    public ProprietyCattleViewModelBase() { }
    public ProprietyCattleViewModelBase(int month, int cattle, int buffalos, int equine, int sheep, int goats)
    {
        Reference = month;
        Cattle = cattle;
        Buffalos = buffalos;
        Equine = equine;
        Sheep = sheep;
        Goats = goats;
    }

    public int Reference { get; set; } = 0;

    public int Cattle { get; set; } = 0;
    public int Buffalos { get; set; } = 0;
    public int Equine { get; set; } = 0;
    public int Sheep { get; set; } = 0;
    public int Goats { get; set; } = 0;
}

public class ProprietyCattleViewModel : ProprietyCattleViewModelBase
{
    public ProprietyCattleViewModel() { }
    public ProprietyCattleViewModel(int month, int cattle, int buffalos, int equine, int sheep, int goats, string year, Guid procedureId)
        : base(month, cattle, buffalos, equine, sheep, goats)
    {
        Year = year;
        ProcedureId = procedureId;
    }
    
    public string Year { get; set; }
    public Guid ProcedureId { get; set; }
}

public class ProprietyCattleInsertUpdateViewModel : ProprietyCattleViewModelBase
{ }

public class CattleManyViewModel
{
    public Guid? ProcedureId { get; set; }
    public List<ProprietyCattleInsertUpdateViewModel> Models { get; set; } = new();
}