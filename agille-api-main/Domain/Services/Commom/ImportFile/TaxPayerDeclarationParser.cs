using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Services.Commom;

public class TaxPayerDeclarationParser
{
    private readonly ImportFileFetcher _fetcher;
    private readonly AddressServices _addressServices;

    public static readonly char CSVBreaker = '╣';
    private Dictionary<string, Guid> CityMap = new();

    public TaxPayerDeclarationParser(ImportFileFetcher fetcher, AddressServices addressServices)
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

    public List<((TaxPayerDeclarationViewModel, DeclarationImportProprietyData), string)> Parse(Guid attachmentId)
    {
        var declarations = new List<((TaxPayerDeclarationViewModel, DeclarationImportProprietyData), string)>();

        var data = _fetcher.GetFileContents(attachmentId);
        var lines = data.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Length == 0)
                continue;

            var entry = ParseLine(lines[i]);
            declarations.Add((entry, lines[i]));
        }

        return declarations;
    }

    private (TaxPayerDeclarationViewModel, DeclarationImportProprietyData) ParseLine(string line)
    {
        var itens = line.Split(CSVBreaker);
        return (new()
        {
            Number = itens[5],
            Cib = itens[4],
            Year = itens[2],

            Total = ParseNumber(itens[45]),
            PermanentPreservationArea = ParseNumber(itens[46]),
            LegalReserveArea = ParseNumber(itens[47]),
            TaxableArea = ParseNumber(itens[53]),
            AreaOccupiedWithWorks = ParseNumber(itens[54]),
            UsableArea = ParseNumber(itens[55]),
            AreaWithReforestation = ParseNumber(itens[58]),
            AreaUsedInRuralActivity = ParseNumber(itens[59]),

            OwnerDocument = itens[28].SanitazeDocument()
        }, 
        new()
        {
            Name = itens[13],
            CAR = itens[65],
            Situation = itens[12],
            IncraCode = itens[15],
            TotalArea = (double)ParseNumber(itens[14]),

            Address = new()
            {
                Street = $"{itens[16]} {itens[17]}",
                District = itens[18],
                Zipcode = itens[25],
                PostalCode = itens[25],
                CityId = FindCityId(itens[20]),
            }
        });
    }

    private static DateTime ParseDate(string item)
    {
        _ = DateTime.TryParse(item, out DateTime date);
        return date;
    }

    private static decimal ParseNumber(string item)
    {
        _ = decimal.TryParse(item, out decimal number);
        return number;
    }
}