using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AgilleApi.Domain.Services.Commom;

public class ManualImportParserV2 : IImportParser<InvoiceEntry>
{
    private readonly ImportFileFetcher _fetcher;
    private static readonly char CSVBreaker = '|';

    public ManualImportParserV2(ImportFileFetcher fetcher)
    {
        _fetcher = fetcher;
    }

    public IEnumerable<InvoiceEntry> Parse(ImportFile file)
    {
        var entries = new List<InvoiceEntry>();
        var lines = _fetcher
                    .GetFileContents(file.ManualFileId)
                    .Split("\n");

        for (int i = 1; i < lines.Length; i++)
        {
            var entry = ParseLine(file, lines[i]);
            entries.Add(entry);
        }

        return entries;
    }

    private static InvoiceEntry ParseLine(ImportFile file, string line)
    {
        var colums = line.Split(CSVBreaker);

        var document = colums[6].SanitazeDocument();
        var value = decimal.Parse(colums[14], new CultureInfo("pt-BR"));
        var reference = DateTime.Parse(colums[1], new CultureInfo("pt-BR"));

        return new InvoiceEntry(
            value,
            file.Id,
            document,
            null,
            reference,
            ""
        );
    }
}