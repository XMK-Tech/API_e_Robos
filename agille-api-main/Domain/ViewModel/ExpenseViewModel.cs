using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class ExpenseParams
{
    public string Creditor { get; set; } // credor
    public string Year { get; set; }
    public string Effort { get; set; } // empenho
    

    public decimal? MinValue { get; set; }
    public decimal? MaxValue { get; set; }
    
    public DateTime? Reference { get; set; }
    public DateTime? Competence { get; set; }

    public ExpenseType? Type { get; set; }
    public string CityConfig { get; set; }

    public bool? IsFromMainEntity { get; set; } = null;
}

public abstract class ExpenseViewModelBase
{
    public ExpenseType Type { get; set; }
    public string Description { get; set; }
    public string Year { get; set; }
    public string PASEP { get; set; }
    public int Index { get; set; }
    public decimal Value { get; set; }

    public DateTime Reference { get; set; }
    public DateTime PaymentDate { get; set; }

    public bool IsFromMainEntity { get; set; } = true;
    public Guid? RelatedEntityId { get; set; }
    public string EntityName { get; set; }

    public Guid? CrawlerFileId { get; set; }
}

public class ExpenseViewModel : ExpenseViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public string TypeDescription { get => Type.GetDescription(); }

    public IEnumerable<ExpenseAttachmentViewModel> Attachments { get; set; }
}

public class ExpenseInsertUpdateViewModel : ExpenseViewModelBase
{ }

public abstract class ExpenseAttachmentViewModelBase
{
    public string Favored { get; set; }
    public string Document { get; set; }
    public string Contract { get; set; }
    public string Validity { get; set; }
    public string Description { get; set; }

    public EffortType Type { get; set; }
}

public class ExpenseAttachmentViewModel : ExpenseAttachmentViewModelBase
{
    public DateTime CreatedAt { get; set; }
    public string TypeDescription { get => Type.GetDescription(); }
    public AttachmentViewModel Attachment { get; set; }
}

public class ExpenseAttachmentInsertUpdateViewModel : ExpenseAttachmentViewModelBase
{
    public Guid AttachmentId { get; set; }
}