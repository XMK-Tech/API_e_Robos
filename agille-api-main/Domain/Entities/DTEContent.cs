using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Entities;

[Serializable]
public class DTEContent : BaseJsonContent
{
    public DTEContent() { }
    public DTEContent(string json) 
    {
        LoadFromJson(json);
    }

    public string DTEModel { get; set; }

    public void Patch(DTEContentViewModel dte)
    {
        if (dte == null)
            return;

        DTEModel = DTEModel.Patch(dte.DTEModel);
    }

    public DTEContentViewModel ConvertToViewModel()
    {
        return new(this);
    }
}