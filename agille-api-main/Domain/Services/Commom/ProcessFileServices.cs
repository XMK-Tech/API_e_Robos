using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public abstract class ProcessFileServices<T>
    where T : ImportEntry
{
    protected readonly IGenericRepository<T> _repository;
    private readonly IImportParser<T> _parser;
    private readonly IImportFileReplacementServices _importFileServices;

    private readonly IInvalidateDivergenciesServices _invalidateDivergenciesServices;

    protected ProcessFileServices(IGenericRepository<T> repository, IImportParser<T> parser, IImportFileReplacementServices importFileServices, IInvalidateDivergenciesServices invalidateDivergenciesServices)
    {
        _repository = repository;
        _parser = parser;
        _importFileServices = importFileServices;
        _invalidateDivergenciesServices = invalidateDivergenciesServices;
    }

    public void ProcessFile(ImportFile file)
    {
        if (file.Status == ImportStatus.DeniedForDuplicity)
            throw new DuplicateCancellationException("Arquivo recusado! Já houve uma importação com os dados referentes a essa competência.");

        var entries = _parser.Parse(file);

        var continueImport = DuplicateValidation(file, entries);
        if (!continueImport)
            return;

        if (file.Status == ImportStatus.ApprovedReplacement)
            _importFileServices.SetStatus(file, ImportStatus.Done);

        _repository.InsertMany(entries.ToList());
    }
    
    public bool DuplicateValidation(ImportFile file, IEnumerable<T> entries)
    {
        if (file.Status == ImportStatus.WaitingForReplacementValidation)
            return false;    

        var references = entries.Select(e => e.ReferenceDate);
        if (AlreadyDeclaredPeriod(references))
            if (file.Status == ImportStatus.ApprovedReplacement)
                ChangeEntitiesState(references, true, file.Id);
            else
            {
                _importFileServices.SetStatus(file, ImportStatus.WaitingForReplacementValidation);
                return false;
            }

        return true;
    }

    private void ChangeEntitiesState(IEnumerable<DateTime> references, bool isInvalid, Guid fileId)
    {
        var target = references.Select(e => new DateTime(e.Year, e.Month, 1)).ToList();
        
        var entities = _repository
                        .Query()
                        .Where(e => !e.IsInvalid)
                        .Where(e => target.Contains(e.ReferenceDate.AddDays((e.ReferenceDate.Day - 1) * -1)))
                        .ToList();

        _invalidateDivergenciesServices.Invalidate(target);

        var files = entities.Select(e => e.ImportFileId).ToList();
        _importFileServices.SetReplaced(files, new() { fileId });

        entities.ForEach(e => e.IsInvalid = isInvalid);
        _repository.UpdateMany(entities);
    }
    
    private bool AlreadyDeclaredPeriod(IEnumerable<DateTime> references)
    {
        references = references.Select(e => new DateTime(e.Year, e.Month, 1));
        
        return  _repository
                    .Query()
                    .Select(e => new DateTime(e.ReferenceDate.Year, e.ReferenceDate.Month, 1))
                    .Distinct()
                    .ToList()
                    .Where(e => references.Contains(e))
                    .Any();
    }
}