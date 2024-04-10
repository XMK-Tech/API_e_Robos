using System;
using System.Collections.Generic;
using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Services.Commom
{

    public class ManualImportParser : IImportParser<InvoiceEntry>
    {
        private readonly ImportFileFetcher _fetcher;

        public ManualImportParser(ImportFileFetcher fetcher) {
            this._fetcher = fetcher;
        }
        public IEnumerable<InvoiceEntry> Parse(ImportFile file)
        {
            var entries = new List<InvoiceEntry>();
            var lines = _fetcher.GetFileContents(file.ManualFileId)
            .Split("\n");
            var first = true;
            foreach (var line in lines)
            {
                if(first) {
                    first = false;
                    continue;
                }
                var entry = ParseLine(file, line);
                entries.Add(entry);
            }
            return entries;
        }

        private static InvoiceEntry ParseLine(ImportFile file, string line)
        {
            //TODO: Implement parsing logic
            var cells = line.Split(",");
            var municipalCode = cells[0];
            var document = cells[1];
            var referenceDate = cells[2];
            var value = decimal.Parse(cells[3]);
            var entry = new InvoiceEntry(
                value,
                file.Id,
                document,
                null,
                DateTime.Parse(
                    referenceDate,
                    new System.Globalization.CultureInfo("pt-BR")
                ),
                municipalCode
            );
            entry.ImportFile = file;
            return entry;
        }
    }
}