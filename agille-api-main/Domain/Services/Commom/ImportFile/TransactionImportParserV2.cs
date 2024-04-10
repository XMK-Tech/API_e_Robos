using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AgilleApi.Domain.Services.Commom;

public class TransactionImportParserV2 : IImportParser<TransactionEntry>
{
    private readonly ImportFileFetcher _fetcher;
    private static readonly char CSVBreaker = '|';

    public TransactionImportParserV2(ImportFileFetcher fetcher)
    {
        _fetcher = fetcher;
    }

    public IEnumerable<TransactionEntry> Parse(ImportFile file)
    {
        var entries = new List<TransactionEntry>();
        var lines = _fetcher
                    .GetFileContents(file.AttachmentId)
                    .Split("\n", StringSplitOptions.TrimEntries);

        for (int i = 1; i < lines.Length; i++)
        {
            var entry = ParseLine(file, lines[i]);
            entries.Add(entry);
        }

        return entries;
    }

    private static TransactionEntry ParseLine(ImportFile file, string line)
    {
        var colums = line.Split(CSVBreaker);

        decimal value = decimal.Parse(colums[6], new CultureInfo("pt-BR"));
        string document = colums[4].SanitazeDocument();
        string cardOperatorDocument = colums[1];
        DateTime referenceDate = DateTime.ParseExact(colums[3], "yyyyMM", CultureInfo.InvariantCulture);

        return new TransactionEntry(
            value,
            file.Id,
            document,
            null,
            referenceDate,
            TransactionEntryType.UNINFORMED,
            cardOperatorDocument
        );
    }
}