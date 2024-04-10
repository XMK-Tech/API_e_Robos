using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class InvalidateDivergenciesServices : IInvalidateDivergenciesServices
{
    private readonly ICardDivergencyEntryRepository _cardDivergencyEntryRepository;
    private readonly IDivergencyEntryRepository _divergencyEntryRepository;

    public InvalidateDivergenciesServices(ICardDivergencyEntryRepository cardDivergencyEntryRepository, IDivergencyEntryRepository divergencyEntryRepository)
    {
        _cardDivergencyEntryRepository = cardDivergencyEntryRepository;
        _divergencyEntryRepository = divergencyEntryRepository;
    }

    public void Invalidate(List<DateTime> references)
    {
        if (references == null || !references.Any())
            return;

        references = references.Select(e => new DateTime(e.Year, e.Month, 1)).Distinct().ToList();

        InvalidatePeriod(_cardDivergencyEntryRepository, references);
        InvalidatePeriod(_divergencyEntryRepository, references);
    }
    
    private static void InvalidatePeriod<T>(IGenericRepository<T> repository, List<DateTime> target)
        where T : BaseDivergencyEntry
    {
        var entities = repository
                        .Query()
                        .Where(e => target.Contains(e.ReferenceDate.AddDays((e.ReferenceDate.Day - 1) * -1)))
                        .ToList();

        entities.ForEach(e => e.IsInvalid = true);

        if (entities.Any())
            repository.UpdateMany(entities);
    }
}