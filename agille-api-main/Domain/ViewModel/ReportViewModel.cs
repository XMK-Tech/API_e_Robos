using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class ReportViewModel
{
    public string Title { get; set; }
    public string Image { get; set; }
    public string EntityName { get; set; }
    public string EntityDocument { get; set; }
    public string RequestedBy { get; set; }
    public int TotalRecords { get; set; }
    public string Total { get; set; }
    public CollectionPDFViewModel CollectionTotals { get; set; }

    public DateTime? StartingReference { get; set; }
    public DateTime? EndingReference { get; set; }

    public string[] Headers { get; set; }
    public List<dynamic> Objects { get; set; }
    public List<List<string>> ObjectFields { get; set; }
    public List<string> FieldAlignments { get; set; }

    public bool IsLandscape { get; set; } = false;
    public bool HasInterval { get => StartingReference.HasValue && EndingReference.HasValue; }
    public bool HasTitle { get => !string.IsNullOrEmpty(Title); }
    public bool HasImage { get => !string.IsNullOrEmpty(Image); }
    public bool HasRequestedBy { get => !string.IsNullOrEmpty(RequestedBy); }
    public bool HasTotalRecords { get => TotalRecords > 0; }
    public bool HasTotal { get => !string.IsNullOrEmpty(Total); }
    public bool HasFieldAlignments { get => FieldAlignments?.Count > 0; }
    public bool HasCollectionTotals { get => CollectionTotals != null
                                             && (!string.IsNullOrEmpty(CollectionTotals.TotalSelicValue)
                                             || !string.IsNullOrEmpty(CollectionTotals.TotalPasepValue)); }
}

public class ReportIntervalViewModel
{
    public DateTime? StartingReference { get; set; }
    public DateTime? EndingReference { get; set; }
}

public class ReportResponseViewModel
{
    public byte[] Content { get; set; }
    public string ContentType { get; set; }
    public string Title { get; set; }
}