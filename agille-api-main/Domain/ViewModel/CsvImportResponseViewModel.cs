using AgilleApi.Domain.Interfaces.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.ViewModel;
public class CsvInsertViewModel
{
    public Guid AttachmentId { get; set; }
}

public class CsvResponseViewModel : BaseJsonContent
{
    public CsvResponseViewModel(string fileUrl, List<ItemCsvError> erros)
    {
        FileUrl = fileUrl;
        Itens = erros;
        ThereWereProblemsImporting = erros.Any();
    }

    public bool ThereWereProblemsImporting { get; set; } = false;
    public string FileUrl { get; set; }
    public List<ItemCsvError> Itens { get; set; }
}

public class ItemCsvError
{
    public ItemCsvError(int line, IEnumerable<string> errors)
    {
        Line = line;
        Errors = errors;
    }
    public int Line { get; set; }
    public IEnumerable<string> Errors { get; set; }
}