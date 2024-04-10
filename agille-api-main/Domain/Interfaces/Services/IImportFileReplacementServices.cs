using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IImportFileReplacementServices
{
    void SetReplaced(List<Guid> targets, List<Guid> exceptions);
    void SetStatus(ImportFile file, ImportStatus status);
    void SetStatus(List<ImportFile> files, ImportStatus status);
}