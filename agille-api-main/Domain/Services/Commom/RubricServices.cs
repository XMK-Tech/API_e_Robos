using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class RubricServices : IRubricServices
{
    private readonly IRubricRepository _repository;
    private readonly IRubricAccountRepository _accountRepository;

    public RubricServices(IRubricRepository repository, IRubricAccountRepository accountRepository)
    {
        _repository = repository;
        _accountRepository = accountRepository;
    }

    public IEnumerable<RubricViewModel> List(Metadata meta, RubricParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, meta, @params);

        return _repository
                .ExecuteGenericQuery(query, meta, ViewModelConverter());
    }

    public IEnumerable<RubricAccountViewModel> ListAccounts(Guid rubricId, Metadata meta)
    {
        var query = _accountRepository
                    .Query()
                    .Where(account => account.RubricId == rubricId)
                    .OrderByDescending(account => account.OriginOfBalance)
                    .ThenBy(account => account.Account);

        return _accountRepository
                .ExecuteGenericQuery(query, meta, AccountViewModelConverter());
    }

    public IQueryable<RubricAccount> GetQueryForYear(string year)
    {
        var lastYear = (int.Parse(year) - 1).ToString();
        return _repository
                .Query()
                .Where(e => e.Reference.Year.ToString() == year || e.Reference.Year.ToString() == lastYear)
                .SelectMany(e => e.Accounts);
    }
    public RubricViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(rubric => rubric.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("Rubric not found.");

        return entity;
    }

    public void Insert(RubricInsertUpdateViewModel model)
    {
        var entity = ConvertyEntity(model);
        _repository.Insert(entity);
    }

    public void Update(Guid id, RubricInsertUpdateViewModel model)
    {
        var entity = Get(id);

        if (entity == null)
            throw new NotFoundException($"Entity not found.");

            var transaction = _repository.Transaction().BeginTransaction();

        try
        {
            _accountRepository.DeleteMany(entity.Accounts.ToList());

            ConvertyEntity(model, entity);

            _accountRepository.InsertMany(entity.Accounts.ToList());

            _repository.Update(entity);

            transaction.Commit();
        }  
        catch (Exception ex)
        {
            transaction.Rollback();

            throw ex;
        }
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }
    public void DeleteAccount(Guid rubricAccountId)
    {
        _accountRepository.Delete(rubricAccountId);
    }

    private static Expression<Func<Rubric, RubricViewModel>> ViewModelConverter()
    {
        return entity => new RubricViewModel
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Name = entity.Name,
            StateId = entity.StateId,
            StateName = entity.State.Name,
            Reference = entity.Reference,
            TotalAccounts = entity.Accounts.Count(),
        };
    }

    private static Expression<Func<RubricAccount, RubricAccountViewModel>> AccountViewModelConverter()
    {
        return account => new RubricAccountViewModel
        {
            Id = account.Id,
            CreatedAt = account.CreatedAt,

            Account = account.Account,
            Title = account.Title,
            Function = account.Function,
            Detail = account.Detail,

            Status = account.Status,
            OriginOfBalance = account.OriginOfBalance,

            Classifications = account.Classifications
        };
    }

    private static IQueryable<Rubric> Filter(IQueryable<Rubric> query, Metadata meta, RubricParams @params)
    {
        query = query
                .WhereIf(@params.Name, rubric => rubric.Name.Contains(@params.Name))
                .WhereIf(@params.StateId, rubric => rubric.StateId == @params.StateId)
                .WhereIf(@params.Reference, rubric => rubric.Reference == @params.Reference)
                .WhereIf(@params.Year, rubric => rubric.Reference.Year.ToString() == @params.Year);

        Expression <Func<Rubric, object>> orderBy = meta.SortColumn.ToLower()
                switch
        {
            "name" => rubric => rubric.Name,
            "reference" => rubric => rubric.Reference,
            "statename" => rubric => rubric.State.Name,
            _ => rubric => rubric.CreatedAt,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdAt";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }

    private static Rubric ConvertyEntity(RubricInsertUpdateViewModel model, Rubric entity = null)
    {
        if (entity == null) 
            entity = new Rubric();

        entity.Name = model.Name;
        entity.StateId = model.StateId;
        entity.Reference = model.Reference;
        entity.Accounts = model.Accounts.Select(e => new RubricAccount(e.Account, e.Title, e.Function, e.Detail, e.Status, e.OriginOfBalance, e.Classifications, entity.Id)).ToList();
        return entity;
    }

    private Rubric Get(Guid id)
    {
        return GetAll()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private IQueryable<Rubric> GetAll()
    {
        return _repository
                .Query()
                .Include(e => e.Accounts);
    }
}