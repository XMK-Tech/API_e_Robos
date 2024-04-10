using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Json;
using AgilleApi.Domain.Interfaces.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class EntitiesViewModel
{
    public EntitiesViewModel(ISSContent iss, ITRContent itr, DTEContent dte, EntityAddress address, AgiprevContent agiprev)
    {
        ISS = new(iss);
        ITR = new(itr);
        DTE = new(dte);
        Address = new(address);
        Agiprev = new(agiprev);
    }

    public string Name { get; set; }
    public string EntityImage { get; set; }
    public string Document { get; set; }
    
    public bool? DemoMode { get; set; } = false;

    public EntityAddressViewModel Address { get; set; }
    public ISSContentViewModel ISS { get; set; }
    public ITRContentViewModel ITR { get; set; }
    public DTEContentViewModel DTE { get; set; }
    public AgiprevContentViewModel Agiprev { get; set; }

}

public class EntityAddressViewModel
{
    public EntityAddressViewModel() { }
    public EntityAddressViewModel(EntityAddress entity)
    {
        if (entity == null)
            return;

        Street = entity.Street;
        District = entity.District;
        Complement = entity.Complement;
        Zipcode = entity.Zipcode;
        Number = entity.Number;
        Type = entity.Type;
        CityId = entity.CityId;
        CityName = entity.CityName;
        StateId = entity.StateId;
        StateName = entity.StateName;
    }

    public string Street { get; set; } = "";
    public string District { get; set; } = "";
    public string Complement { get; set; } = "";
    public string Zipcode { get; set; } = "";
    public string Number { get; set; } = "";

    public AddressType? Type { get; set; } = AddressType.Others;
    public Guid? CityId { get; set; }
    public string CityName { get; set; }

    public Guid? StateId { get; set; }
    public string StateName { get; set; }
}

public class ISSContentViewModel : BaseJsonContent, IContentJson
{
    public ISSContentViewModel(ISSContent content)
    {
        if (content == null)
            return;

        ResponsibleName = content.ResponsibleName;
        LegalBasisNotice = content.LegalBasisNotice;
        LegalBasisWarning = content.LegalBasisWarning;
    }

    public string ResponsibleName { get; set; }
    public string LegalBasisWarning { get; set; }
    public string LegalBasisNotice { get; set; }
}

public class ITRContentViewModel : BaseJsonContent, IContentJson
{
    public ITRContentViewModel(ITRContent content)
    {
        if (content == null)
            return;

        Document = content.Document;
        IBGECode = content.IBGECode;
        State = content.State;
        Seal = content.Seal;
        ProprietyCount = content.ProprietyCount;
        MunicipalityNumber = content.MunicipalityNumber;
        Neighborhood = content.Neighborhood;
        FinanceSecretary = content.FinanceSecretary;
        LogoUrl = content.LogoUrl;

        ContractStatus = content.ContractStatus;
        DemarcationZones = content.DemarcationZones;

        ContractComplaint = content.ContractComplaint;
        ContractValidity = content.ContractValidity;

        FundraisingPerspective = content.FundraisingPerspective;
        FundraisingEffective = content.FundraisingEffective;
        HerdIndex = content.HerdIndex;

        Aliquot = content.Aliquot;

        CARShapeFileUrl = content.CARShapeFileUrl;
        Center = content.Center;
        GMapsName = content.GMapsName;
        CityLimitsFile = content.CityLimitsFile;

        if (content.Credentials != null)
            Credentials = new SIGEPWEBCredentialsViewModel(content.Credentials);
    }

    public string Document { get; set; }
    public string IBGECode { get; set; }
    public string State { get; set; }
    public string Seal { get; set; }
    public int? ProprietyCount { get; set; }
    public string MunicipalityNumber { get; set; }
    public string Neighborhood { get; set; }
    public string FinanceSecretary { get; set; }
    public string LogoUrl { get; set; }

    public bool? ContractStatus { get; set; }
    public bool? DemarcationZones { get; set; }

    public DateTime? ContractComplaint { get; set; }
    public DateTime? ContractValidity { get; set; }

    public double? FundraisingPerspective { get; set; }
    public double? FundraisingEffective { get; set; }
    public double? HerdIndex { get; set; }

    public decimal? Aliquot { get; set; }
    public string CARShapeFileUrl { get; set; }
    public string Center { get; set; }
    public string GMapsName { get; set; }
    public string CityLimitsFile { get; set; }

    public SIGEPWEBCredentialsViewModel Credentials { get; set; }
}

public class DTEContentViewModel : BaseJsonContent, IContentJson
{
    public DTEContentViewModel(DTEContent content)
    {
        if (content == null)
            return;

        DTEModel = content.DTEModel;
    }

    public string DTEModel { get; set; }
}

public class SIGEPWEBCredentialsViewModel : BaseJsonContent
{
    public SIGEPWEBCredentialsViewModel() { }
    public SIGEPWEBCredentialsViewModel(string user, string password, string administrativeCode, string contract, string document, string sE, string card)
    {
        User = user;
        Password = password;
        AdministrativeCode = administrativeCode;
        Contract = contract;
        Document = document;
        SE = sE;
        Card = card;
    }
    public SIGEPWEBCredentialsViewModel(SIGEPWEBCredentials entity) 
        : this(entity.User, entity.Password, entity.AdministrativeCode, entity.Contract, entity.Document, entity.SE, entity.Card)
    { }

    public string User { get; set; }
    public string Password { get; set; }
    public string AdministrativeCode { get; set; }
    public string Contract { get; set; }
    public string Document { get; set; }
    public string SE { get; set; }
    public string Card { get; set; }
}

public class AgiprevContentViewModel : BaseJsonContent, IContentJson
{
    public AgiprevContentViewModel(string iPMUrl, string fPMUrl, string processNumber, string estadoSigla, string municipioNome, List<string> documents)
    {
        IPMUrl = iPMUrl;
        FPMUrl = fPMUrl;
        ProcessNumber = processNumber;
        EstadoSigla = estadoSigla;
        MunicipioNome = municipioNome;
        Documents = documents;
    }

    public AgiprevContentViewModel(AgiprevContent agiprev)
        : this(agiprev?.IPMUrl, agiprev?.FPMUrl, agiprev?.ProcessNumber, agiprev?.EstadoSigla, agiprev?.MunicipioNome, agiprev?.Documents)
    {   }

    public string IPMUrl { get; set; }
    public string FPMUrl { get; set; }
    public string ProcessNumber { get; set; }
    public string EstadoSigla { get; set; }
    public string MunicipioNome {  get; set; }

    public List<string> Documents { get; set; }
}