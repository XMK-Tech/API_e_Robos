using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;

namespace AgilleApi.Domain.Services.Commom;

public class DivergencyEntryServices : IDivergencyEntryServices
{
    private readonly IDivergencyEntryRepository _repository;
    private readonly IJuridicalPersonServices _juridicalPersonServices;

    public DivergencyEntryServices(IDivergencyEntryRepository repository, IJuridicalPersonServices juridicalPersonServices) 
    {
        _repository = repository;
        _juridicalPersonServices = juridicalPersonServices;
    }

    public IEnumerable<DataCrossingEntryViewModel> GetByCrossing(Guid crossingId)
    {
        var query = _repository
                    .Query()
                    .Where(e => e.DataCrossingId == crossingId)
                    .OrderBy(e => e.Difference);

        var documents = query.ToList().Select(e => e.Document.SanitazeDocument());

        var documentMap = _juridicalPersonServices.DocumentsExists(documents);
        var companyIds = _juridicalPersonServices.GetIdsByDocument(documents);

        return query
                .Select((i) => ConvertToViewModel(i, documentMap[i.Document.Replace("/", "").Replace(".", "").Replace("-", "")], companyIds[i.Document.Replace("/", "").Replace(".", "").Replace("-", "")]));
    }

    public List<DivergencyEntry> GetByIds(IEnumerable<Guid> divergencyIds)
    {
        return _repository
                .Query()
                .Where(e => divergencyIds.Contains(e.Id))
                .ToList();
    }

    public IEnumerable<DivergencyEntry> GetAll(DateTime startDate, DateTime endDate)
    {
        return _repository
                .Query()
                .Where(e => e.CreatedAt >= startDate && e.CreatedAt <= endDate)
                .ToList();
    }

    public DivergencysDataViewModel GetDivergencysCount(GetEntriesViewModel model, Metadata meta)
    {
        if (model.StartingReference > model.EndingReference)   
            throw new BadHttpRequestException("A data final não pode ser anterior a data inicial!");

        var entries = GetAll(model.StartingReference, model.EndingReference).OrderBy(e => e.CreatedAt);
        var entriesGroups = entries.GroupBy(e => new { e.CreatedAt.Year, e.CreatedAt.Month });

        List<DivergencyViewModel> groupsData = new List<DivergencyViewModel>();
        foreach (var group in entriesGroups)
        {
            var key = group.Key;
            var monthName = group.FirstOrDefault()?.CreatedAt.ToString(@"MMMM", new CultureInfo("PT-pt"));
            groupsData.Add(new DivergencyViewModel(group.Count(), monthName, key.Year.ToString(), key.Month));
        }

        return new DivergencysDataViewModel(model.StartingReference, model.EndingReference, entries.Count(), groupsData);
    }

    private static DataCrossingEntryViewModel ConvertToViewModel(DivergencyEntry i, bool companyExists, Guid? companyId)
    {
        return new DataCrossingEntryViewModel()
        {
            CompanyDocument = i.Document,
            Difference = i.Difference,
            InvoiceAmount = i.InvoiceValue,
            TransactionAmount = i.TransactionValue,
            ReferenceDate = i.ReferenceDate,
            Id = i.Id,
            IsCompanyRegistered = companyExists,
            CompanyId = companyId,
            IsInvalid = i.IsInvalid,
        };
    }

}
