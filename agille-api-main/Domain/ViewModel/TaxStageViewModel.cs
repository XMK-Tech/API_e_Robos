using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public abstract class TaxStageCommonInfo
{
    public DateTime? CertificationDate { get; set; }
    public TaxStageType Type { get; set; }
    public ProcessStatus Status { get; set; }
}

public abstract class TaxStageViewModelBase : TaxStageCommonInfo
{
    public TaxStageViewModelBase() { }
    public TaxStageViewModelBase(
        DateTime? certificationDate,
        DateTime? cutOffDate,
        string aRCode,
        string number,
        TaxStageType type,
        ProcessStatus status,
        decimal? fineAmount,
        string trackingCode,
        Guid? subjectId)
    {
        CertificationDate = certificationDate;
        CutOffDate = cutOffDate;
        ARCode = aRCode;
        Number = number;
        Type = type;
        Status = status;
        FineAmount = fineAmount;
        TrackingCode = trackingCode;
        SubjectId = subjectId;
    }

    public Guid? SubjectId { get; set; }

    public DateTime? CutOffDate { get; set; }

    public decimal? FineAmount { get; set; }
    public string TrackingCode { get; set; }

    public string ForwardTermUrl { get; set; }
    public string JoiningTermUrl { get; set; }

    public string ARCode { get; set; }
    public string Number { get; set; }
}

public class TaxStageViewModel : TaxStageViewModelBase
{
    public TaxStageViewModel() { }
    public TaxStageViewModel(Guid id, DateTime? certificationDate, DateTime? cutOffDate, string aRCode, string number, TaxStageType type, ProcessStatus status, decimal? fineAmount, string trackingCode, Guid? subjectId, string subjectName, DateTime createdAt)
        : base(certificationDate, cutOffDate, aRCode, number, type, status, fineAmount, trackingCode, subjectId)
    {
        Id = id;
        SubjectName = subjectName;
        CreatedAt = createdAt;
    }

    public Guid Id { get; set; }
    public string SubjectName { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid? AnsweredById { get; set; }
    public string AnsweredByName { get; set; }
    public Guid? ReplyTo { get; set; }

    public List<AttachmentViewModel> Attachments { get; set; }
}

public class TaxStageInsertUpdateViewModel : TaxStageViewModelBase
{
    public List<Guid> AttachmentIds { get; set; }
}

public class TaxStageReplyInsertViewModel : TaxStageCommonInfo
{
    public List<Guid> AttachmentIds { get; set; }
}

public class TaxStageForwardingTermViewModel
{
    public Guid TaxProcedureId { get; set; }
    public int? HomePageNumber { get; set; }
    public int? FinalPageNumber { get; set; }
    public int? AtualPageNumber { get; set; }
    public bool SpaceForLetterhead { get; set; } = false;
    public bool WithObjection { get; set; } = false;
}

public class ForwardingTermNoticeModel : TaxStageForwardingTermViewModel
{
    public ForwardingTermNoticeModel(TaxStageForwardingTermViewModel @base)
    {
        TaxProcedureId = @base.TaxProcedureId;
        HomePageNumber = @base.HomePageNumber;
        FinalPageNumber = @base.FinalPageNumber;
        AtualPageNumber = @base.AtualPageNumber;
        SpaceForLetterhead = @base.SpaceForLetterhead;
        WithObjection = @base.WithObjection;

        WithObjectionText = (WithObjection) ? "com" : "sem";
    }

    public ForwardingTermNoticeModel(TaxStageJoinTermViewModel @base)
    {
        TaxStageId = @base.TaxStageId;
        HomePageNumber = @base.HomePageNumber;
        AtualPageNumber = @base.AtualPageNumber;
        SpaceForLetterhead = @base.SpaceForLetterhead;
        FinalPageNumber = @base.FinalPageNumber;

        WithObjection = false;
        WithObjectionText = null;
    }

    public Guid? TaxStageId { get; set; } = null;

    public string WithObjectionText { get; set; }

    public string SubjectName { get; set; }
    public string SubjectDocument { get; set; }
    public string ProprietyCib { get; set; }
    public string Auditor { get; set; }

    public string DocumentNumber { get; set; }
    public string ProcessNumber { get; set; }

    public string Image { get; set; }
    public string StateInitials { get; set; }
    public string EntityName { get; set; }

    public TaxStageType Type { get; set; }
}

public class TaxStageJoinTermViewModel
{
    public Guid TaxStageId { get; set; }
    public int? HomePageNumber { get; set; }
    public int? FinalPageNumber { get; set; }
    public int? AtualPageNumber { get; set; }
    public bool SpaceForLetterhead { get; set; } = false;
}

public class TaxStageARViewModel : ARViewModel
{
    public static TaxStageARViewModel FromArViewModel(
        ARViewModel arVm,
        Guid stageId
    )
    {
        return new TaxStageARViewModel()
        {
            AdditionalInformation = arVm.AdditionalInformation,
            Devolution = arVm.Devolution,
            Recipient = arVm.Recipient,
            TaxStageId = stageId,
        };
    }
    public Guid TaxStageId { get; set; }
}