using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class ImportFileReplacementServices : IImportFileReplacementServices
{
    private readonly IImportFileRepository _repository;

    public ImportFileReplacementServices(IImportFileRepository repository)
    {
        _repository = repository;
    }

    public void SetStatus(ImportFile file, ImportStatus status)
    {
        SetStatus(new List<ImportFile>() { file }, status);
    }

    public void SetStatus(List<ImportFile> files, ImportStatus status)
    {
        if (files == null)
            return;

        files.ForEach(e => e.Status = status);
        _repository.UpdateMany(files);
    }

    public void SetReplaced(List<Guid> targets, List<Guid> exceptions)
    {
        var entities = _repository
                        .Query()
                        .Where(e => e.Status == ImportStatus.Done)
                        .Where(e => !exceptions.Contains(e.Id))
                        .Where(e => targets.Contains(e.Id))
                        .ToList();

        SetStatus(entities, ImportStatus.Replaced);
    }
}