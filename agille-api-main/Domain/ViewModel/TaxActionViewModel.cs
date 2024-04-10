using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public class TaxActionViewModel
{
    public TaxActionViewModel() { }
    public TaxActionViewModel(Guid id, string description, bool statusHasChanged, NoticeStatus? fromStatus, NoticeStatus? toStatus, Guid userId, DateTime date, Guid? attachmentId, AttachmentViewModel attachment)
    {
        Id = id;
        Description = description;
        StatusHasChanged = statusHasChanged;
        FromStatus = fromStatus;
        ToStatus = toStatus;
        UserId = userId;
        Date = date;
        AttachmentId = attachmentId;
        Attachment = attachment;

        if(FromStatus.HasValue)
            FromStatusDescription = FromStatus.Value.GetDescription();

        if (ToStatus.HasValue)
            ToStatusDescription = ToStatus.Value.GetDescription();
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool StatusHasChanged { get; set; }
    public NoticeStatus? FromStatus { get; set; }
    public NoticeStatus? ToStatus { get; set; }
    public string FromStatusDescription { get; set; }
    public string ToStatusDescription { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public Guid? AttachmentId { get; set; }
    public AttachmentViewModel Attachment { get; set; }
}