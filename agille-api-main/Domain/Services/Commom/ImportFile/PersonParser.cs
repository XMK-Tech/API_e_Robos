using AgilleApi.Domain.Enums;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Services.Commom;

public class PersonParser
{
    private readonly ImportFileFetcher _fetcher;
    private readonly AddressServices _addressServices;

    public static readonly char CSVBreaker = '╣';

    private Dictionary<string, Guid> CityMap = new();

    public PersonParser(ImportFileFetcher fetcher, AddressServices addressServices)
    {
        _fetcher = fetcher;
        _addressServices = addressServices;
    }

    public Guid FindCityId(string cityName)
    {
        Guid city;

        if (CityMap.ContainsKey(cityName))
        {
            city = CityMap[cityName];
        }
        else
        {
            city = _addressServices.GetCityId(cityName) ?? Guid.Empty;
            CityMap.Add(cityName, city);
        }
        
        return city;
    }

    public List<(PersonViewModelBase, string)> Parse(Guid attachmentId)
    {
        var proprieties = new List<(PersonViewModelBase, string)>();

        var data = _fetcher.GetFileContents(attachmentId);
        var lines = data.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Length == 0)
                continue;

            var entry = ParseLine(lines[i], attachmentId);
            proprieties.Add((entry, lines[i]));
        }

        return proprieties;
    }

    public PersonViewModelBase ParseLine(string line, Guid attachmentId)
    {
        var itens = line.Split(CSVBreaker);

        var phones = new List<PhoneViewModel>() { new PhoneViewModel(PhoneType.Null, ParseFieldFromCSVItem(itens[3])) };
        var addresses = new List<AddressInsertUpdateViewModel>()
        {
            new AddressInsertUpdateViewModel()
            {
                Function = AddressFunction.Common,
                Type = AddressType.Others,
                Street = ParseFieldFromCSVItem(itens[4]),
                Number = ParseFieldFromCSVItem(itens[5]),
                Complement = ParseFieldFromCSVItem(itens[6]),
                District = ParseFieldFromCSVItem(itens[7]),
                Zipcode = ParseFieldFromCSVItem(itens[8]),
                CityId = FindCityId(itens[9]),
            },
            new AddressInsertUpdateViewModel()
            {
                Function = AddressFunction.Correspondence,
                Type = AddressType.Others,
                Street = ParseFieldFromCSVItem(itens[11]),
                Number = ParseFieldFromCSVItem(itens[12]),
                Complement = ParseFieldFromCSVItem(itens[13]),
                District = ParseFieldFromCSVItem(itens[14]),
                Zipcode = ParseFieldFromCSVItem(itens[15]),
                CityId = FindCityId(itens[16]),
            }
        };

        return GetPersonType(itens[1]) switch
        {
            PersonType.Juridical => new JuridicalPersonInsertUpdateViewModel()
            {
                Document = ParseFieldFromCSVItem(itens[1]),
                Name = ParseFieldFromCSVItem(itens[2]),
                DisplayName = ParseFieldFromCSVItem(itens[2]),

                ProprietyCib = ParseFieldFromCSVItem(itens[0]),
                ImmunityYears = ParseFieldFromCSVItem(itens[22]),
                ReasonForImmunity = ParseFieldFromCSVItem(itens[23]),
                StartDate = ParseDateTime(itens[24]),
                EndDate = ParseDateTime(itens[25]),

                LegalRepresentativeName = ParseFieldFromCSVItem(itens[20]),
                LegalRepresentativeDocument = ParseFieldFromCSVItem(itens[21]),

                InventoryPersonName = ParseFieldFromCSVItem(itens[18]),
                InventoryPersonDocument = ParseFieldFromCSVItem(itens[19]),

                Phones = phones,
                Addresses = addresses
            },
            PersonType.Physical => new PhysicalPersonInsertUpdateViewModel()
            {
                Document = ParseFieldFromCSVItem(itens[1]),
                Name = ParseFieldFromCSVItem(itens[2]),
                DisplayName = ParseFieldFromCSVItem(itens[2]),

                ProprietyCib = ParseFieldFromCSVItem(itens[0]),
                ImmunityYears = ParseFieldFromCSVItem(itens[22]),
                ReasonForImmunity = ParseFieldFromCSVItem(itens[23]),
                StartDate = ParseDateTime(itens[24]),
                EndDate = ParseDateTime(itens[25]),

                LegalRepresentativeName = ParseFieldFromCSVItem(itens[20]),
                LegalRepresentativeDocument = ParseFieldFromCSVItem(itens[21]),

                InventoryPersonName = ParseFieldFromCSVItem(itens[18]),
                InventoryPersonDocument = ParseFieldFromCSVItem(itens[19]),

                Phones = phones,
                Addresses = addresses
            },
            _ => null,
        };
    }

    private static PersonType GetPersonType(string document)
    {
        return document.Contains('/') ? PersonType.Juridical : PersonType.Physical;
    }

    private static string ParseFieldFromCSVItem(string prop)
    {
        if (string.IsNullOrEmpty(prop) || string.IsNullOrWhiteSpace(prop) || prop.Contains("*****"))
            return "";

        return prop;
    }
    
    private static DateTime ParseDateTime(string prop)
    {
        if (string.IsNullOrEmpty(prop) || string.IsNullOrWhiteSpace(prop) || prop.Contains("*****"))
            return DateTime.MinValue;

        _ = DateTime.TryParse(prop, out DateTime final);

        return final;
    }
}