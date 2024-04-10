using AgilleApi.Domain.ViewModel;
using Newtonsoft.Json;

namespace AgilleApi.Domain.Entities;

public class Content
{
    public Content() { }
    public Content(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        LoadFromJson(json);
    }

    public Content(string iTRData, string iSSData, string dTEData, string agiprevData)
    {
        SetITRContent(iTRData);
        SetISSContent(iSSData);
        SetDTEContent(dTEData);
        SetAgiprevContent(agiprevData);
    }

    public bool? DemoMode { get; set; } = false;
    public ITRContent ITR { get; set; } = new();
    public ISSContent ISS { get; set; } = new();
    public DTEContent DTE { get; set; } = new();
    public AgiprevContent Agiprev { get; set; } = new();

    private void SetITRContent(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        if (ITR == null)
            ITR = new ITRContent();

        ITR.LoadFromJson(json);
    }

    private void SetISSContent(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        if (ISS == null)
            ISS = new ISSContent();
        

        ISS.LoadFromJson(json);
    }

    private void SetDTEContent(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        if (DTE == null)
            DTE = new DTEContent();

        DTE.LoadFromJson(json);
    }

    private void SetAgiprevContent(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        if (Agiprev == null)
            Agiprev = new AgiprevContent();

        Agiprev.LoadFromJson(json);
    }

    public void Patch(
        ITRContentViewModel itr, 
        ISSContentViewModel iss, 
        DTEContentViewModel dte, 
        AgiprevContentViewModel agiprev, 
        bool? demoMode = false)
    {
       if(demoMode.HasValue)
            DemoMode = demoMode.Value;

        ITR.Patch(itr);
        ISS.Patch(iss);
        DTE.Patch(dte);
        Agiprev.Patch(agiprev);
    }

    public string ConvertToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public void LoadFromJson(string json)
    {
        if (string.IsNullOrEmpty(json))
            return;

        JsonConvert.PopulateObject(json, this);
    }
}