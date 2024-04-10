using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class ChecklistParams
{
    public string Document { get; set; }
    public DateTime? Date { get; set; }
    public ChecklistStatus? StatusBackoffice { get; set; }
    public ChecklistAuditorFilter? StatusAuditor { get; set; }
}

public abstract class ChecklistViewModelBase
{
    public string Text { get; set; }
    public ChecklistStatus Status { get; set; }
    public string Justification { get; set; }
}

public class ChecklistViewModel : ChecklistViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdateAt { get; set; }

    public IEnumerable<AttachmentViewModel> Attachments { get; set; }
}

public class ChecklistInsertUpdateViewModel : ChecklistViewModelBase { }

public class ChecklistInsertUpdateAttachmentsViewModel
{
    public List<Guid> Attachments { get; set; } = new();
}

public class ChecklistUpdateViewModel
{
    public ChecklistStatus Status { get; set; }
    public string Justification { get; set; }
}