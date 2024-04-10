using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Json;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Entities;

[Serializable]
public class ISSContent : BaseJsonContent, IContentJson, IConvertableToViewModel<ISSContentViewModel>
{
    public ISSContent() { }
    public ISSContent(string json)
    {
        LoadFromJson(json);
    }
    public ISSContent(string responsibleName, string legalBasisWarning, string legalBasisNotice)
    {
        ResponsibleName = responsibleName;
        LegalBasisWarning = legalBasisWarning;
        LegalBasisNotice = legalBasisNotice;
    }

    public ISSContent(ISSContentViewModel model)
    {
        if (model == null)
            return;

        ResponsibleName = model.ResponsibleName;
        LegalBasisWarning = model.LegalBasisWarning;
        LegalBasisNotice = model.LegalBasisNotice;
    }

    public string ResponsibleName { get; set; }
    public string LegalBasisWarning { get; set; }
    public string LegalBasisNotice { get; set; }

    public ISSContentViewModel ConvertToViewModel()
    {
        return new ISSContentViewModel(this);
    }

    public void Patch(ISSContentViewModel iss)
    {
        if (iss == null)
            return;
        
        ResponsibleName = ResponsibleName.Patch(iss.ResponsibleName);
        LegalBasisWarning = LegalBasisWarning.Patch(iss.LegalBasisWarning);
        LegalBasisNotice = LegalBasisNotice.Patch(iss.LegalBasisNotice);
    }
}
