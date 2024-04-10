using Newtonsoft.Json;
using System;

namespace AgilleApi.Domain.Entities;

[Serializable]
public class SIGEPWEBCredentials
{
    public SIGEPWEBCredentials() { }
    public SIGEPWEBCredentials(string json)
    {
        LoadFromJson(json);
    }
    public SIGEPWEBCredentials(string user, string password, string administrativeCode, string contract, string document, string sE, string card)
    {
        User = user;
        Password = password;
        AdministrativeCode = administrativeCode;
        Contract = contract;
        Document = document;
        SE = sE;
        Card = card;
    }

    public string User { get; set; }
    public string Password { get; set; }
    public string AdministrativeCode { get; set; }
    public string Contract { get; set; }
    public string Document { get; set; }
    public string SE { get; set; }
    public string Card { get; set; }

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