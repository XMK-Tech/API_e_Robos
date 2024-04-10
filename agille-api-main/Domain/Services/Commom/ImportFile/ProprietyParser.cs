using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Services.Commom;

public class ProprietyParser
{
    private readonly ImportFileFetcher _fetcher;
    private readonly AddressServices _addressServices;

    public static readonly char CSVBreaker = '╣';

    public ProprietyParser(ImportFileFetcher fetcher, AddressServices addressServices)
    {
        _fetcher = fetcher;
        _addressServices = addressServices;
    }

    public Guid FindCityId(string cityName)
    {
        return _addressServices.GetCityId(cityName) ?? Guid.Empty;
    }

    public List<(ProprietyInsertUpdateViewModel, string)> Parse(Guid attachmentId)
    {
        var proprieties = new List<(ProprietyInsertUpdateViewModel, string)>();

        var data = _fetcher.GetFileContents(attachmentId);
        var lines = data.Split('\n');

        for(int i=1; i<lines.Length;i++)
        {
            if (lines[i].Length == 0)
                continue;

            var entry = ParseLine(lines[i], attachmentId);
            proprieties.Add((entry, lines[i]));
        }

        return proprieties;
    }

    private ProprietyInsertUpdateViewModel ParseLine(string line, Guid attachmentId)
    {
        var itens = line.Split(CSVBreaker);
        return new()
        {
            CibNumber        = ParseFieldFromCSVItem(itens[0]),
            Situation        = ParseFieldFromCSVItem(itens[5]),
            Name             = ParseFieldFromCSVItem(itens[1]),
            DeclaredArea     = ParseAreaFromField(itens[7]),
            IncraCode        = ParseFieldFromCSVItem(itens[6]),
            LinkedCib        = ParseFieldFromCSVItem(itens[10].Substring(0, itens[10].Length - 1)),
            FromAttachmentId = attachmentId,

            Address = new()
            {
                Street      = ParseFieldFromCSVItem(itens[2]),
                District    = ParseFieldFromCSVItem(itens[3]),
                CityId      = FindCityId(itens[4]),
                Zipcode     = ParseFieldFromCSVItem(itens[8]),
            }
        };
    }

    private static string ParseFieldFromCSVItem(string prop)
    {
        if (string.IsNullOrEmpty(prop) || string.IsNullOrWhiteSpace(prop) || prop.Contains("*****"))
            return "";

        return prop.Replace("\t", "");
    }

    private static double ParseAreaFromField(string prop)
    {
        if (string.IsNullOrEmpty(prop) || string.IsNullOrWhiteSpace(prop) || prop.Contains("*****"))
            return 0;

        try
        {
            prop = prop.Substring(0, (prop.Length-2));
            return double.Parse(prop);
        }
        catch
        {
            return 0;
        }
    }
}