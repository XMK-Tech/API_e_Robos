using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilleApi.Domain.Services.Commom;

public class AuditServices : IAuditServices
{
    private readonly IAuditRepository _repository;

    private static readonly string[] _headers = new string[] { "Id", "UserId", "Type", "TableName", "OldValues", "NewValues", "AffectedColumns", "PrimaryKey", "Date" , "IpAddress"};
    private static readonly char CSVBreaker = ';';

    public AuditServices(IAuditRepository repository)
    {
        _repository = repository;
    }

    public List<Audit> GetEvents(IEnumerable<AuditType> events, Guid id, string targetColumn = null,DateTime? startingReference = null, DateTime? endingReference = null)
    {
        List<string> types = new();

        if(events != null && events.Any())
            types = events.Select(e => e.GetDescription()).ToList();

        var fk = "{\"Id\":\"" + id + "\"}";

        return _repository
                .Query()
                .WhereIf(types.Any(), x => types.Contains(x.Type))
                .Where(e => e.PrimaryKey == fk)
                .WhereIf(startingReference, e => e.CreatedAt >= startingReference)
                .WhereIf(endingReference, e => e.CreatedAt <= endingReference)
                .WhereIf(targetColumn, e => e.AffectedColumns.ToLower().Contains(targetColumn.ToLower()))
                .ToList();
    }
    
    public byte[] ViewLog(AuditParams @params)
    {
        var lines = new List<string>
        {
            BuildCsvHeader(),    
        };

        var entities = Filter(Query(), @params)
                        .Select(ConvertToCsvLine)
                        .ToList();
        
        lines.AddRange(entities);

        var bytes = Encoding.UTF8.GetBytes(string.Join("\n", lines));

        return bytes;
    }

    private IQueryable<Audit> Query()
    {
        return _repository.Query();
    }

    private static string BuildCsvHeader()
    {
        return string.Join(CSVBreaker.ToString(), _headers);
    }

    private static string ConvertToCsvLine(Audit entity)
    {
        return string.Join(CSVBreaker.ToString(), new string[]
        {
            entity.Id.ToString(),
            entity.UserId.ToString(),
            entity.Type.ToString(),
            entity.TableName,
            entity.OldValues,
            entity.NewValues,
            entity.AffectedColumns,
            entity.PrimaryKey,
            entity.CreatedAt.ToString(),
            entity.IpAddress,
        });
    }
    
    private static IQueryable<Audit> Filter(IQueryable<Audit> query, AuditParams @params)
    {
        return query
                .WhereIf(@params.UserId, e => e.UserId == @params.UserId)
                .WhereIf(@params.Type, e => e.Type == @params.Type.Value.GetDescription())
                .WhereIf(@params.IpAddress, e => e.IpAddress.Replace(".", "") == @params.IpAddress.Replace(".", ""))
                .OrderByDescending(e => e.CreatedAt)
                .Take(@params.Lines);
    }
}