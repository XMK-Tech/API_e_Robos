using System;
using System.Collections.Generic;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.ViewModel; 

public class ImportFileParams
{
    public ImportType? Type { get; set; }
    public ImportStatus? Status { get; set; }
    public string Reason { get; set; }
}

public abstract class BaseImportFileViewModel {
    public ImportType Type { get; set; }
    public bool IsSimplified {get;set;} = false;
    public DateTime CreatedAt {get;set;}
}
public class ImportFileInsertUpdateViewModel: BaseImportFileViewModel
{
    public Guid AttachmentId { get; set; }
}

public class ImportFileViewModel: BaseImportFileViewModel
{
    public Guid Id {get; set;}
    public AttachmentViewModel Attachment { get; set; }
    public AttachmentViewModel ManualFile { get; set; }
    public ImportStatus Status { get; set; }
    public string Reason {get;set;}

}

public class UploadManualFileViewModel {
    public Guid Id { get; set; }
    public Guid AttachmentId { get; set; }
}

public class RejectFileViewModel {
    public string Reason { get; set; }
}

public class ImportEntryViewModel {
    public string File { get; set; }
    public ImportType Type { get; set; }
    public int Total { get; set; }
}

public class GetEntriesViewModel {
    public DateTime StartingReference { get; set; }
    public DateTime EndingReference { get; set; }
}

public class ImportsDataViewModel
{
    public ImportsDataViewModel() { }

    public ImportsDataViewModel(DateTime startReference, DateTime endingReference, int total, List<ImportCountViewModel> data)
    {
        StartReference = startReference;
        EndingReference = endingReference;
        Total = total;
        Data = data;
    }

    public DateTime StartReference { get; set; }
    public DateTime EndingReference { get; set; }
    public int Total { get; set; }
    public List<ImportCountViewModel> Data;
}

public class ImportCountViewModel
{
    public ImportCountViewModel() { }
    public ImportCountViewModel(int importCount, string monthName, string year, int monthId)
    {
        ImportCount = importCount;
        MonthName = monthName;
        Year = year;
        MonthId = monthId;
    }

    public int ImportCount { get; set; }
    public string MonthName { get; set; }
    public string Year { get; set; }
    public int MonthId { get; set; }
}