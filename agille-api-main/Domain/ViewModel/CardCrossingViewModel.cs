using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilleApi.Domain.ViewModel;

public class SimpleCardCrossingReportViewModel
{
    public SimpleCardCrossingReportViewModel() { }
    public SimpleCardCrossingReportViewModel(Guid id, DateTime startingReference, DateTime endingReference, int divergencyCount)
    {
        Id = id;
        StartingReference = startingReference;
        EndingReference = endingReference;
        DivergencyCount = divergencyCount;
    }

    public Guid Id { get; set; }
    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
    public int DivergencyCount { get; set; }
}

public class CardCrossingViewModel
{
    public CardCrossingViewModel() { }
    public CardCrossingViewModel(Guid id, ICollection<CardDivergencyEntryViewModel> data, DateTime startingReference, DateTime endingReference, string requesterName, bool hasInvalidDivergences)
    {
        Id = id;
        Data = data;
        StartingReference = startingReference;
        EndingReference = endingReference;
        RequesterName = requesterName;

        DivergencyCount = data.Count;
        HasInvalidDivergences = hasInvalidDivergences;
    }

    public Guid Id { get; set; }
    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
    public string RequesterName { get; set; }
    public int DivergencyCount { get; set; }
    public bool HasInvalidDivergences { get; set; }
    public ICollection<CardDivergencyEntryViewModel> Data { get; set; }
}

public class CardCrossingInsertIntervalViewModel
{
    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
}

public class CardCrossingMonthInsertViewModel
{
    public DateTime Reference { get; set; }
}