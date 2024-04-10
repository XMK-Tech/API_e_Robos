using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

[Serializable]
public class AgiprevContent : BaseJsonContent
{
    public AgiprevContent() { }
    public AgiprevContent(string json)
    {
        LoadFromJson(json);
    }

    public string IPMUrl { get; set; }
    public string FPMUrl { get; set; }
    public string ProcessNumber { get; set; }

    public string EstadoSigla { get; set; }
    public string MunicipioNome { get; set; }

    public List<string> Documents { get; set; }

    public void Patch(AgiprevContentViewModel content)
    {
        if (content == null)
            return;

        IPMUrl = IPMUrl.Patch(content.IPMUrl);
        FPMUrl = FPMUrl.Patch(content.FPMUrl);
        ProcessNumber = ProcessNumber.Patch(content.ProcessNumber);
        EstadoSigla = EstadoSigla.Patch(content.EstadoSigla);
        MunicipioNome = MunicipioNome.Patch(content.MunicipioNome);

        if (content.Documents != null)
            Documents = content.Documents;  
    }
}