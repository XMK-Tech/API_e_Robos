using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public class ARViewModel
{
    public string AdditionalInformation { get; set; }
    public CourierAddressViewModel Recipient { get; set; }
    public CourierAddressViewModel Devolution { get; set; }
}

public class ForwardingTermInsertUpdateViewModel
{
    public int? HomePageNumber { get; set; }
    public int? FinalPageNumber { get; set; }
    public int? AtualPageNumber { get; set; }
    public bool SpaceForLetterhead { get; set; } = false;
    public bool WithObjection { get; set; } = false;
    public string ProprietyCib { get; set; }
    public string DocumentNumber { get; set; }
    public string ProcessNumber { get; set; }
    public TaxStageType Type { get; set; } = TaxStageType.ReplyToNoticeWarn;
}

public class ForwardingTerm : ForwardingTermInsertUpdateViewModel
{
    public ForwardingTerm(ForwardingTermInsertUpdateViewModel baseTerm)
    {
        HomePageNumber = baseTerm.HomePageNumber;
        FinalPageNumber = baseTerm.FinalPageNumber;
        AtualPageNumber = baseTerm.AtualPageNumber;
        SpaceForLetterhead = baseTerm.SpaceForLetterhead;
        WithObjection = baseTerm.WithObjection;
        DocumentNumber = baseTerm.DocumentNumber;
        ProcessNumber = baseTerm.ProcessNumber;
        ProprietyCib = ProprietyCib;

        WithObjectionText = (WithObjection) ? "com" : "sem";
    }

    public string WithObjectionText { get; set; }

    public string SubjectName { get; set; }
    public string SubjectDocument { get; set; }
    
    public string Auditor { get; set; }

    public string Image { get; set; }
    public string StateInitials { get; set; }
    public string EntityName { get; set; }
}