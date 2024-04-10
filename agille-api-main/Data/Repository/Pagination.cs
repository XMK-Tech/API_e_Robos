using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Data.Repository;

public static class Pagination<T> where T : class
{
    public static IQueryable<T> Get(Metadata metadata, IQueryable<T> query)
    {
        int pagination = metadata.Limit == 0 ? 20 : metadata.Limit;
        int pageCount = ((query.Count() - 1) / pagination) + 1;

        metadata.Offset = Math.Min(metadata.Offset == 0 ? 1 : metadata.Offset, pageCount);
        query = query.Skip((metadata.Offset - 1) * pagination).Take(pagination);
        return query;
    }

    public static List<U> Execute<U>(Metadata metadata, IQueryable<T> query, Expression<Func<T, object>> orderBy = null, Expression<Func<T, U>> selector = null) where U : class
    {
        metadata.DataSize = query.Count();

        if (metadata.SortDirection == "asc" && orderBy != null)
            query = query.OrderBy(orderBy);
        if (metadata.SortDirection == "desc" && orderBy != null)
            query = query.OrderByDescending(orderBy);

        return Pagination<U>.Get(metadata, query.Select(selector)).ToList();
    }
}