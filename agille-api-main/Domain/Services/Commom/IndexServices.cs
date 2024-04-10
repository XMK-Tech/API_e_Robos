using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class IndexServices : IIndexServices
{
    private readonly IIndexRepository _repository;

    public IndexServices(IIndexRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<IndexViewModel> List(Metadata meta, IndexParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, meta, @params);

        return _repository
                .ExecuteGenericQuery(query, meta, ViewModelConverter());
    }

    public IEnumerable<IndexViewModel> ListLastDeclarations(Metadata meta)
    {
        var query = _repository
                    .Query()
                    .GroupBy(index => index.Type)
                    .Select(group => group.OrderByDescending(e => e.Reference).FirstOrDefault())
                    .ToList();

        return _repository
                .ExecuteGenericQuery(query.AsQueryable(), meta, ViewModelConverter());
    }

    public IndexViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(index => index.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("Index not found.");

        return entity;
    }

    public void Insert(IndexViewModel model)
    {
        var entity = ConvertToEntity(model);
        _repository.Insert(entity);
    }

    public void Update(Guid id, IndexViewModel model)
    {
        var entity = _repository.GetById(id);
        if (null == entity)
        {
            throw new NotFoundException($"Entity {id} was not found in Index.");
        }

        UpdateEntity(model, entity);
        _repository.Update(entity);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }

    public decimal GetSelicRate(string year, string month)
    {
        var yearInt = int.Parse(year ?? "0");
        var monthInt = int.Parse(month ?? "0");
        var beginDate = new DateTime(yearInt, monthInt, 1);
        var dateNow = DateTime.Now;
        var endingDate = new DateTime(dateNow.Year, dateNow.Month, 1);

        var rangePercentageList = _repository.Query()
            .Where(x => x.Reference.Date >= beginDate.Date &&
                        x.Reference.Date <= endingDate.Date)
            .Select(x => x.Percentage).ToList();

            return rangePercentageList.Sum();
    }

    private static Expression<Func<Entities.Index, IndexViewModel>> ViewModelConverter()
    {
        return entity => new IndexViewModel()
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Type = entity.Type,
            Percentage = entity.Percentage,
            Reference = entity.Reference,
        };
    }

    private static IQueryable<Entities.Index> Filter(IQueryable<Entities.Index> query, Metadata meta, IndexParams @params)
    {
        query = query
                .WhereIf(@params.Type, index => index.Type == @params.Type)
                .WhereIf(@params.Percentage, index => index.Percentage == @params.Percentage)
                .WhereIf(@params.Reference, index => index.Reference == @params.Reference)
                .WhereIf(@params.Year, index => index.Reference.Year.ToString() == @params.Year);

        Expression<Func<Entities.Index, object>> orderBy = meta.SortColumn.ToLower()
                switch
        {
            "type" => index => index.Type,
            "percentage" => index => index.Percentage,
            "reference" => index => index.Reference,
            _ => index => index.CreatedAt,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdAt";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }

    public static Entities.Index ConvertToEntity(IndexViewModel model)
    {
        return new Entities.Index(model.Type, model.Percentage, model.Reference);  
    }

    public static void UpdateEntity(IndexViewModel model, Entities.Index entity)
    {
        entity.Type = model.Type;
        entity.Percentage = model.Percentage;
        entity.Reference = model.Reference;
    }
}