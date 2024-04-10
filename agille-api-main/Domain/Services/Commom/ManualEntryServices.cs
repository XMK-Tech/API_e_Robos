using System;
using System.Linq;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;

namespace AgilleApi.Domain.Services.Commom;

public class ManualEntryServices : ProcessFileServices<InvoiceEntry>
{
    public ManualEntryServices(IGenericRepository<InvoiceEntry> repository, IImportParser<InvoiceEntry> parser, IImportFileReplacementServices importFileServices, IInvalidateDivergenciesServices invalidateDivergenciesServices) 
        : base(repository, parser, importFileServices, invalidateDivergenciesServices)
    {
    }

    public decimal DeclaredValue(string document, DateTime reference)
    {
        return _repository
            .Query()
            .Where(e => e.Document.Replace("-", "").Replace(".", "").Replace("/", "")
                            ==
                        document.Replace("/", "").Replace("-", "").Replace(".", ""))
            .Where(e => e.ReferenceDate.Year == reference.Year && e.ReferenceDate.Month == reference.Month)
            .ToList()
            .Select(e => e.Value)
            .DefaultIfEmpty(0)
            .Sum();
    }
}