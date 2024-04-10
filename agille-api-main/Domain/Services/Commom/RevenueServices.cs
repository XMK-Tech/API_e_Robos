using AgilleApi.Domain.Entities;
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

public class RevenueServices : IRevenueServices
{
    private readonly IRevenueRepository _repository;
    private readonly IReportServices _reportServices;
    private readonly ILogosServices _logosServices;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IAgiprevCrawlerServices _agiprevCrawlerServices;

    public RevenueServices(
        IRevenueRepository repository, 
        IReportServices reportServices, 
        ILogosServices logosServices, 
        IEntitiesServices entitiesServices, 
        IAgiprevCrawlerServices agiprevCrawlerServices)
    {
        _repository = repository;
        _reportServices = reportServices;
        _logosServices = logosServices;
        _entitiesServices = entitiesServices;
        _agiprevCrawlerServices = agiprevCrawlerServices;
    }

    public IEnumerable<RevenueViewModel> List(Metadata meta, RevenueParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, meta, @params);

        return _repository
                .ExecuteGenericQuery(query, meta, ViewModelConverter());
    }

    public ReportResponseViewModel GeneratePDFReport(Metadata meta, RevenueParams @params)
    {
        var tableData = GenerateHeadersAndBody(meta, @params);

        tableData.Title = "RECEITAS";

        var entity = _entitiesServices.View();
        tableData.Image = _logosServices.GetUrlLogoInBase64(entity.EntityImage);
        tableData.EntityName = entity.Name;
        tableData.EntityDocument = entity.Document;

        return _reportServices.GeneratePDFReport(tableData);
    }
    
    public ReportResponseViewModel GenerateCSVReport(Metadata meta, RevenueParams @params)
    {
        var tableData = GenerateHeadersAndBody(meta, @params);
        return _reportServices.GenerateCSVReport(tableData.Headers, tableData.Objects.ToList());
    }
    
    private ReportViewModel GenerateHeadersAndBody(Metadata meta, RevenueParams @params)
    {
        var query = _repository.Query()
            .Where(e => e.IsFromMainEntity);

        var list = Filter(query, meta, @params).ToList();

        var queryDynamic = list.Select(e => new
        {
            e.Account,
            e.Description,
            Reference = e.Reference.ToString("MM/yyyy"),
            EffectedValue = e.EffectedValue.FormatValue(),
        } as dynamic);

        var headers = new string[]
        {
            "Conta",
            "Descricao",
            "Competencia",
            "Total",
        };

        var referencesDates = list.OrderBy(e => e.Reference).Select(e => e.Reference).ToList();
        var totalRecords = list.Count;
        var total = list.Select(x => x.EffectedValue).Sum().FormatValue();
        var fieldAlignments = new List<string>()
        {
            "center", "center", "center", "right"
        };

        return new ReportViewModel()
        {
            TotalRecords = totalRecords,
            Total = total,
            FieldAlignments = fieldAlignments,

            Headers = headers,
            Objects = queryDynamic.ToList(),

            StartingReference = referencesDates.FirstOrDefault(),
            EndingReference = referencesDates.LastOrDefault(),
        };
    }

    public RevenueViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("Revenue not found.");

        return entity;
    }

    public FilterSumViewModel GetFilterSum(RevenueParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, null, @params);

        return new()
        {
            Sum = query.Select(e => e.EffectedValue).Sum(),
            Count = query.Count()
        };
    }

    public IQueryable<Revenue> GetQueryForYear(string year)
    {
        return _repository
                    .Query()
                    .Where(revenue => revenue.Reference.Year.ToString() == year)
                    .Where(revenue => revenue.IsFromMainEntity);
    }
    
    public IQueryable<Revenue> GetQueryForCompetence(string year, string month)
    {
        return GetQueryForYear(year)
                .Where(revenue => revenue.Reference.Month.ToString() == month);
    }

    public void ImportFromCrawler(AgiprevImportParams @params)
    {
        var models = _agiprevCrawlerServices.Import<RevenueInsertUpdateViewModel>(@params.Reference);

        models.ForEach(e => e.Reference = @params.Reference);

        var entities = models.Select(ConvertToEntity).ToList();
        _repository.InsertMany(entities);
    }

    public void Insert(RevenueInsertUpdateViewModel model)
    {
        ThrowExceptionIfModelIsInvalid(model);

        var entity = ConvertToEntity(model);
        _repository.Insert(entity);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }

    public void Update(Guid id, RevenueInsertUpdateViewModel model)
    {
        ThrowExceptionIfModelIsInvalid(model);

        var entity = _repository.GetById(id);
        if (entity == null)
            throw new NotFoundException("Revenue not found.");

        UpdateEntity(model, entity);
        _repository.Update(entity);
    }

    private static void ThrowExceptionIfModelIsInvalid(RevenueInsertUpdateViewModel model)
    {
        var messages = new List<string>();

        if (string.IsNullOrEmpty(model.Description))
            messages.Add("Description is required.");

        if (model.PredictedDeductions < 0)
            messages.Add("PredictedDeductions must be greater than zero.");

        if (model.Deductions < 0)
            messages.Add("Deductions must be greater than zero.");

        if (model.PredictedUpdated < 0)
            messages.Add("PredictedUpdated must be greater than zero.");

        if (model.EffectedValue < 0)
            messages.Add("EffectedValue must be greater than zero.");

        if (model.PredictedValue < 0)
            messages.Add("PredictedValue must be greater than zero.");

        if (model.Collection < 0)
            messages.Add("Collection must be greater than zero.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private static Expression<Func<Revenue, RevenueViewModel>> ViewModelConverter()
    {
        return revenue => new RevenueViewModel()
        {
            Id = revenue.Id,
            CreatedAt = revenue.CreatedAt,
            Index = revenue.Index,
            PredictedDeductions = revenue.PredictedDeductions,
            Deductions = revenue.Deductions,
            Description = revenue.Description,
            Account = revenue.Account,
            PredictedUpdated = revenue.PredictedUpdated,
            EffectedValue = revenue.EffectedValue,
            PredictedValue = revenue.PredictedValue,
            Collection = revenue.Collection,

            Reference = revenue.Reference,

            IsFromMainEntity = revenue.IsFromMainEntity,
            RelatedEntityId = revenue.RelatedEntityId
        };
    }

    private static IQueryable<Revenue> Filter(IQueryable<Revenue> query, Metadata meta, RevenueParams @params)
    {
        query = query
                .WhereIf(@params.Description, r => r.Description.Contains(@params.Description))
                .WhereIf(@params.Year, r => r.Reference.Year.ToString() == @params.Year)
                .WhereIf(@params.Account, r => r.Account.Contains(@params.Account))
                .WhereInRange(@params.MinPredictedDeductions, @params.MaxPredictedDeductions, r => r.PredictedDeductions)
                .WhereInRange(@params.MinDeductions, @params.MaxDeductions, r => r.Deductions)
                .WhereInRange(@params.MinPredictedUpdated, @params.MaxPredictedUpdated, r => r.PredictedUpdated)
                .WhereInRange(@params.MinEffectedValue, @params.MaxEffectedValue, r => r.EffectedValue)
                .WhereInRange(@params.MinPredictedValue, @params.MaxPredictedValue, r => r.PredictedValue)
                .WhereInRange(@params.MinCollection, @params.MaxCollection, r => r.Collection)
                .WhereIf(@params.Reference, r => r.Reference.Month == @params.Reference.Value.Month && r.Reference.Year == @params.Reference.Value.Year)
                .WhereIf(@params.CityConfig, r => r.Description.ToLower().StartsWith(@params.CityConfig.ToLower()))
                .WhereIf(@params.IsFromMainEntity != null, r => r.IsFromMainEntity == @params.IsFromMainEntity);

        if (meta == null)
            return query;

        Expression<Func<Revenue, object>> orderBy = meta.SortColumn.ToLower()
                switch
        {
            "account" => x => x.Account,
            "predicteddeductions" => x => x.PredictedDeductions,
            "deductions" => x => x.Deductions,
            "description" => x => x.Description,
            "predictedupdated" => x => x.PredictedUpdated,
            "effectedvalue" => x => x.EffectedValue,
            "predictedvalue" => x => x.PredictedValue,
            "collection" => x => x.Collection,
            "reference" => x => x.Reference,
            _ => x => x.CreatedAt,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdAt";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }

    private static Revenue ConvertToEntity(RevenueInsertUpdateViewModel model)
    {
        return new Revenue(
            0,
            model.PredictedDeductions,
            model.Deductions,
            model.Description,
            model.PredictedUpdated,
            model.EffectedValue,
            model.PredictedValue,
            model.Collection,
            model.Reference,
            model.Account,
            model.IsFromMainEntity,
            model.RelatedEntityId)
        {
            CrawlerFileId = model.CrawlerFileId
        };
    }

    private static void UpdateEntity(RevenueInsertUpdateViewModel model, Revenue entity)
    {
        entity.PredictedDeductions = model.PredictedDeductions;
        entity.Deductions = model.Deductions;
        entity.Description = model.Description;
        entity.PredictedUpdated = model.PredictedUpdated;
        entity.EffectedValue = model.EffectedValue;
        entity.PredictedValue = model.PredictedValue;
        entity.Collection = model.Collection;
        entity.Reference = model.Reference;
        entity.Account = model.Account ?? entity.Account;
        entity.IsFromMainEntity = model.IsFromMainEntity;
        entity.RelatedEntityId = model.RelatedEntityId;
    }
}