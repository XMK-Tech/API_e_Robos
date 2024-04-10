using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class AgiprevBatchCrawlerFileInsertViewModel
{
    public DateTime Competence { get; set; }

    public List<AgiprevCrawlerItemViewModel> Itens { get; set; } = new();
}

public class AgiprevCrawlerItemViewModel
{
    public Guid AttachmentId { get; set; }
    public string DataDescription { get; set; }
}

public class AgiprevCrawlerFileInsertViewModel : AgiprevCrawlerItemViewModel
{
    public DateTime Competence { get; set; }
}

public class AgiprevImportParams
{
    public DateTime Reference { get; set; }
}

public class CrawlerCommandViewModel
{
    public string Command { get; set; }
}