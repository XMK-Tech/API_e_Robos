using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface ITaxPayerDeclarationServices
{
    TaxPayerDeclarationViewModel GetDeclaration(string year, Guid proprietyId, string cib = "");
    TaxPayerDeclarationViewModel GetDeclaration(TaxPayerDeclarationParams @params);
    IEnumerable<TaxPayerDeclarationViewModel> List(Metadata meta, TaxPayerDeclarationParams @params);
    CsvResponseViewModel Import(CsvInsertViewModel model);
    TaxPayerDeclarationViewModel Upsert(TaxPayerDeclarationViewModel model, TaxPayerDeclarationParams @params);
}