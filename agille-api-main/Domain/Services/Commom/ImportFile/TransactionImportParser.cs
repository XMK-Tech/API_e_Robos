using System;
using System.Collections.Generic;
using System.Globalization;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.Services.Commom
{

    public class TransactionImportParser : IImportParser<TransactionEntry>
    {
        private readonly ImportFileFetcher _fetcher;

        public TransactionImportParser(ImportFileFetcher fetcher)
        {
            this._fetcher = fetcher;
        }
        public IEnumerable<TransactionEntry> Parse(ImportFile file)
        {
            var entries = new List<TransactionEntry>();
            var lines = _fetcher.GetFileContents(file.AttachmentId)
            .Split("\n", StringSplitOptions.TrimEntries);
            foreach (var line in lines)
            {
                var entry = ParseLine(file, line);
                entries.Add(entry);
            }
            return entries;
        }

        private static TransactionEntry ParseLine(ImportFile file, string line)
        {
            //TODO: add missing fields
            decimal value = decimal.Parse(line.Substring(line.Length - 15), CultureInfo.InvariantCulture);
            string document = line.Substring(line.Length - 44, 14);
            string date = line.Substring(11, 8);
            DateTime referenceDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            TransactionEntryType type = ((int.Parse(line.Substring(0, 3), CultureInfo.InvariantCulture) == 100) ? TransactionEntryType.DEBIT : TransactionEntryType.CREDIT);
            string cardOperatorDocument = line.Substring(line.Length - 30, 14);
            var entry = new TransactionEntry(
                value,
                file.Id,
                document,
                null,
                referenceDate,
                type,
                cardOperatorDocument
            );
            return entry;
        }
    }
}