using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class CollectionParams
{
	public string Year { get; set; }

	public decimal? MinPasepValue { get; set; }
	public decimal? MaxPasepValue { get; set; }
	
	public decimal? MinSelicValue { get; set; }
	public decimal? MaxSelicValue { get; set; }
	
	public DateTime? Reference { get; set; }
	public DateTime? Payday { get; set; }
    public string CityConfig { get; set; }

    public bool? IsFromMainEntity { get; set; } = null;
}

public abstract class CollectionViewModelBase
{
	public decimal PasepValue { get; set; }
	public decimal SelicValue { get; set; }
	public DateTime Reference { get; set; }
	public DateTime Payday { get; set; }
	
	public bool IsFromMainEntity { get; set; } = true;
	public Guid? RelatedEntityId { get; set; }
	public string EntityName { get; set; }
	public Guid? CrawlerFileId { get; set; }
}

public class CollectionInsertUpdateViewModel : CollectionViewModelBase
{ }

public class CollectionViewModel : CollectionViewModelBase
{
	public Guid Id { get; set; }
	public DateTime CreatedAt { get; set; }

	public IEnumerable<CollectionAttachmentViewModel> Attachments { get; set; }
}

public abstract class CollectionAttachmentViewModelBase
{
	public string Description { get; set; }
	public CollectionAttachmentType Type { get; set; }
}

public class CollectionAttachmentViewModel : CollectionAttachmentViewModelBase
{
	public DateTime CreatedAt { get; set; }
	public string TypeDescription { get => Type.GetDescription(); }
	public AttachmentViewModel Attachment { get; set; }
}

public class CollectionAttachmentInsertUpdateViewModel : CollectionAttachmentViewModelBase
{
	public Guid AttachmentId { get; set; }
}

public class CollectionPDFViewModel
{
    public CollectionPDFViewModel(){}

    public CollectionPDFViewModel(string totalPasepValue, string totalSelicValue)
    {
        TotalPasepValue = totalPasepValue;
        TotalSelicValue = totalSelicValue;
    }

    public string TotalPasepValue { get; set; }
    public string TotalSelicValue { get; set; }
}