using System.Collections.Generic;
using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Services.Commom
{
    public interface IImportParser<T> where T : ImportEntry
    {
        IEnumerable<T> Parse(ImportFile file);
    }
}