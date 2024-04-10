using System;
using System.Collections.Generic;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.ViewModel; 
public class NoticeInsertUpdateViewModel 
{
    public Guid TemplateId {get;set;}
    public IEnumerable<Guid> DivergencyIds { get; set; }
    public NoticeType Type { get; set; }
    public decimal Aliquot {get;set;}
    public string Observation {get;set;}
    public int? DaysToExpire {get;set;}
    public NoticeBaseRate? RateType { get; set; } = NoticeBaseRate.Null;
}

public class NoticeManualInsertUpdateViewModel
{
    public Guid TemplateId { get; set; }
    public Guid SubjectId { get; set; }
    public NoticeType Type { get; set; }
    public decimal Aliquot { get; set; }
    public string Observation { get; set; }
    public int? DaysToExpire { get; set; }
    public NoticeBaseRate? RateType { get; set; } = NoticeBaseRate.Null;
    public Dictionary<string, string> Tags { get; set; } = new();
}

public class GetNoticeParamsViewModel 
{
    public NoticeType? Type {get;set;}
    public string Document {get;set;}
    public string? Number {get;set;}
    public string Name {get;set;}
    public string CompanyName {get;set;}
    public Module? Module {get;set;}
}

public abstract class NoticeViewModelBase
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public string Url { get; set; }
    public NoticeType Type { get; set; }
    public decimal Aliquot { get; set; }
    public string Observation { get; set; }
    public string Name { get; set; }
    public NoticeBaseRate RateType { get; set; }
    public Module Module { get; set; }
}

public class NoticeViewModel : NoticeViewModelBase
{
    public string Number {get;set;}
    public string Document {get;set;}
    public string CompanyName {get;set;}
    public DateTime Date {get;set;}
    public DateTime DueDate {get;set;}
    public NoticeStatus Status { get; set; }
    public string StatusDescription { get; set; }

    public Guid? PersonId { get; set; }

    public IEnumerable<Guid> DivergencyIds { get; set; }
    public IEnumerable<TaxActionViewModel> TaxActions { get; set; }
    public ReturnProtocolViewModel ReturnProtocol { get; set; }
}

public class CompleteNoticeViewModel : NoticeViewModelBase
{
    public CompleteNoticeViewModel() { }
    public CompleteNoticeViewModel(Notice notice, string CompanyName, string url, List<DivergencyEntryViewModel> divergencys, IEnumerable<TaxActionViewModel> taxActions, ReturnProtocolViewModel returnProtocol)
    {
        Id = notice.Id;
        TemplateId = notice.TemplateId;
        Type = notice.Type;
        Aliquot = notice.Aliquot;
        Observation = notice.Observation;
        Name = CompanyName;
        Url = url;
        Content = notice.Content;
        Divergencys = divergencys;
        TaxActions = taxActions;
        ReturnProtocol = returnProtocol;
    }

    public string Content { get; set; }
    public DateTime ExpiresIn { get; set; }

    public IEnumerable<DivergencyEntryViewModel> Divergencys { get; set; }
    public IEnumerable<TaxActionViewModel> TaxActions { get; set; }
    public ReturnProtocolViewModel ReturnProtocol { get; set; }
}

public class UpdateNoticeViewdState
{
    public Guid NoticeId { get; set; }
    public bool WasViewd { get; set; }
}

public class NoticeUpdateStatusViewModel
{
    public Guid? AttachmentId { get; set; }
    public Guid NoticeId { get; set; }
    public NoticeStatus? Status { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}

public class TemplatePreviewModel
{
    public string Template { get; set; }
}