using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Json;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Entities;


[Serializable]
public class ITRContent : BaseJsonContent, IContentJson, IConvertableToViewModel<ITRContentViewModel>
{
    public ITRContent() { }
    public ITRContent(string json)
    {
        LoadFromJson(json);
    }

    public int ProprietyCount { get; set; }
    public string Document { get; set; }
    public string IBGECode { get; set; }
    public string State { get; set; }
    public string Seal { get; set; }
    public string MunicipalityNumber { get; set; }
    public string Neighborhood { get; set; }
    public string FinanceSecretary { get; set; }
    public string LogoUrl { get; set; }

    public bool ContractStatus { get; set; }
    public bool DemarcationZones { get; set; }

    public DateTime ContractComplaint { get; set; }
    public DateTime ContractValidity { get; set; }

    public double FundraisingPerspective { get; set; }
    public double FundraisingEffective { get; set; }
    public double HerdIndex { get; set; }

    public decimal Aliquot { get; set; }

    public string CARShapeFileUrl { get; set; }
    public string Center { get; set; }
    public string GMapsName { get; set; }
    public string CityLimitsFile {get;set;}
    
    public SIGEPWEBCredentials Credentials { get; set; }
    public string CredentialsJson { get => GetCredential(); set => SetCredential(value); }

    public ITRContentViewModel ConvertToViewModel()
    {
        return new ITRContentViewModel(this);
    }

    private string GetCredential()
    {
        if (Credentials == null)
            return "";
        else
            return Credentials.ConvertToJson();
    }

    private void SetCredential(string json)
    {
        if(Credentials == null)
            Credentials = new(json);
        else
            Credentials.LoadFromJson(json);
    }

    public void Patch(ITRContentViewModel model)
    {
        if (model == null)
            return;

        if(model.ProprietyCount.HasValue)
            ProprietyCount = model.ProprietyCount.Value;

        if(model.ContractStatus.HasValue)
            ContractStatus = model.ContractStatus.Value;

        if (model.DemarcationZones.HasValue)
            DemarcationZones = model.DemarcationZones.Value;

        if (model.ContractComplaint.HasValue)
            ContractComplaint = model.ContractComplaint.Value;

        if (model.ContractValidity.HasValue)
            ContractValidity = model.ContractValidity.Value;

        if (model.FundraisingPerspective.HasValue)
            FundraisingPerspective = model.FundraisingPerspective.Value;

        if (model.FundraisingEffective.HasValue)
            FundraisingEffective = model.FundraisingEffective.Value;

        if (model.HerdIndex.HasValue)
            HerdIndex = model.HerdIndex.Value;

        if (model.Aliquot.HasValue)
            Aliquot = model.Aliquot.Value;

        if(model.Credentials != null && model.Credentials.User != null & model.Credentials.Password != null)
            Credentials = new(model.Credentials.ConvertToJson());

        Document = Document.Patch(model.Document);
        IBGECode = IBGECode.Patch(model.IBGECode);
        State = State.Patch(model.State);
        Seal = Seal.Patch(model.Seal);
        MunicipalityNumber = MunicipalityNumber.Patch(model.MunicipalityNumber);
        Neighborhood = Neighborhood.Patch(model.Neighborhood);
        FinanceSecretary = FinanceSecretary.Patch(model.FinanceSecretary);
        LogoUrl = LogoUrl.Patch(model.LogoUrl);
        
        CARShapeFileUrl = CARShapeFileUrl.Patch(model.CARShapeFileUrl);
        Center = Center.Patch(model.Center);
        GMapsName = GMapsName.Patch(model.GMapsName);
        CityLimitsFile = CityLimitsFile.Patch(model.CityLimitsFile);
    }
}