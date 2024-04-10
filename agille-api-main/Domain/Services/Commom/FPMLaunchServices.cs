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

public class FPMLaunchServices : IFPMLaunchServices
{
    private readonly IFPMLaunchRepository _repository;
    private readonly IAgiprevCrawlerServices _agiprevCrawlerServices;

    public FPMLaunchServices(IFPMLaunchRepository repository, IAgiprevCrawlerServices agiprevCrawlerServices)
    {
        _repository = repository;
        _agiprevCrawlerServices = agiprevCrawlerServices;
    }

    public IEnumerable<FPMLaunchViewModel> List(Metadata meta, FPMLaunchParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, meta, @params);

        return _repository
                .ExecuteGenericQuery(query, meta, ViewModelConverter());
    }

    public FPMLaunchViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("FPMLaunch not found.");

        return entity;
    }

    public IQueryable<FPMLaunch> GetQueryForCompetence(string year, string month)
    {
        return _repository
                .Query()
                .Where(fpmlaunch => fpmlaunch.Competence.Year.ToString() == year)
                .Where(fpmlaunch => fpmlaunch.Competence.Month.ToString() == month);
    }

    public void ImportFromCrawler(AgiprevImportParams @params)
    {
        var models = _agiprevCrawlerServices.Import<FPMInsertUpdateViewModel>(@params.Reference);

        var entities = models.Select(ConvertToEntity).ToList();
        _repository.InsertMany(entities);
    }

    private static FPMLaunch ConvertToEntity(FPMInsertUpdateViewModel model)
    {
        return new()
        {
            Description = model.Description,
            IncomeAccount = "0",
            Collected = model.Collected,
            Accumulated = 0,
            Reference = model.Reference,
            Competence = model.Competence,
            CrawlerFileId = model.CrawlerFileId
        };
    }

    private static Expression<Func<FPMLaunch, FPMLaunchViewModel>> ViewModelConverter()
    {
        return fpmLaunch => new FPMLaunchViewModel()
        {
            Id = fpmLaunch.Id,
            CreatedAt = fpmLaunch.CreatedAt,
            Description = fpmLaunch.Description,
            IncomeAccount = fpmLaunch.IncomeAccount,
            Collected = fpmLaunch.Collected,
            Accumulated = fpmLaunch.Accumulated,
            Reference = fpmLaunch.Reference,
            Competence = fpmLaunch.Competence,
        };
    }

    private static IQueryable<FPMLaunch> Filter(IQueryable<FPMLaunch> query, Metadata meta, FPMLaunchParams @params)
    {
        query = query
                .WhereIf(@params.Description, fpm => fpm.Description.Contains(@params.Description))
                .WhereIf(@params.IncomeAccount, fpm => fpm.IncomeAccount.Contains(@params.IncomeAccount))
                .WhereIf(@params.Year, fpm => fpm.Competence.Year.ToString() == @params.Year)
                .WhereIf(@params.Competence, fpm => fpm.Competence.Year == @params.Competence.Value.Year && fpm.Competence.Month == @params.Competence.Value.Month)
                .WhereIf(@params.CityConfig, fpm => fpm.Description.ToLower().StartsWith(@params.CityConfig.ToLower()))
                .WhereInRange(@params.MinCollected, @params.MaxCollected, fpm => fpm.Collected)
                .WhereInRange(@params.MinAccumulated, @params.MaxAccumulated, fpm => fpm.Accumulated)
                .WhereInRange(@params.MinReference, @params.MaxReference, fpm => fpm.Reference);

        Expression<Func<FPMLaunch, object>> orderBy = meta.SortColumn.ToLower()
                switch
        {
            "description" => fpm => fpm.Description,
            "incomeaccount" => fpm => fpm.IncomeAccount,
            "collected" => fpm => fpm.Collected,
            "accumulated" => fpm => fpm.Accumulated,
            "competence" => fpm => fpm.Competence,
            _ => fpm => fpm.Reference,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "Reference";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }
}