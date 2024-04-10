using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Commom;

public class UnionTransfersServices : IUnionTransfersServices
{
    private readonly IUnionTransfersRepository _repository;
    private readonly IPDFGenerator _pDFGenerator;
    private readonly IEntitiesServices _entitiesServices;
    private readonly ISessionServices _sessionServices;
    private readonly MiddlewareClient _middlewareClient;

    public UnionTransfersServices(IUnionTransfersRepository repository, IPDFGenerator pDFGenerator, IEntitiesServices entitiesServices, ISessionServices sessionServices, MiddlewareClient middlewareClient)
    {
        _repository = repository;
        _pDFGenerator = pDFGenerator;
        _entitiesServices = entitiesServices;
        _sessionServices = sessionServices;
        _middlewareClient = middlewareClient;
    }

    public IEnumerable<UnionTransfersViewModel> View(UnionTransfersParams @params, Metadata meta)
    {
        var query = Filter(Query(), @params, meta);
        return _repository.ExecuteQuery(query, meta).Select(ConvertToViewModel);
    }
    
    public UnionTransfersViewModel View(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, $"Repasse a união(Id: {id})");

        return ConvertToViewModel(entity);
    }

    public UnionTransfersDashboard Dashboard()
    {
        var now = DateTime.Now;
        var entities = GetLastMonths(now);

        var itens = entities
                    .GroupBy(e => new { e.Date.Month, e.Date.Year})
                    .Select(e => new UnionTransfersDashboardItem(e.Select(e => e.Value).Sum(), e.Key.Year, e.Key.Month))
                    .ToList();

        itens = ValidateDashboardItens(itens, now);

        var sum = entities.Select(e => e.Value).Sum();
        return new(sum, now, itens);
    }

    public UnionTransfersViewModel Insert(UnionTransfersInsertUpdateViewModel model)
    {
        ValidateModel(model);
        
        var entity = ConvertToEntity(model);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    public UnionTransfersViewModel Update(UnionTransfersInsertUpdateViewModel model, Guid id)
    {
        ValidateModel(model);

        var entity = Get(id);
        ThrowIfNull(entity, $"Repasse a união(Id: {id})");

        entity.Value = model.Value;
        entity.Date = model.Date;
        entity.Status = model.Status;

        _repository.Update(entity);

        return ConvertToViewModel(entity);
    }

    public void ChangeStatus(UnionTransfersStatus status, Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, $"Repasse a união(Id: {id})");

        entity.Status = status;

        _repository.Update(entity);
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, $"Repasse a união(Id: {id})");

        _repository.Delete(id);
    }

    public async Task<byte[]> Print(UnionTransferReportModel model)
    {
        if (model.StartDate > model.EndDate)
            throw new BadRequestException("O intervalo informado é inválido.");

        model.Image = _entitiesServices.GetBase64Image();
        model.UserName = GetUserName();

        model.Itens = _repository
                        .Query()
                        .Where(e => e.Date >= model.StartDate && e.Date <= model.EndDate)
                        .ToList()
                        .GroupBy(e => new {e.Date.Month, e.Date.Year})
                        .Select(e => new UnionTransferReportItem(e.Key.Month, e.Key.Year, e.Select(f => f.Value).DefaultIfEmpty(0).Sum()))
                        .OrderBy(e => e.Reference)
                        .ToList();
                        

        return await _pDFGenerator.Generate(model, "UnionTransfer");
    }

    private string GetUserName()
    {
        var userId = _sessionServices.GetUserId();

        if (!userId.HasValue)
            return null;

        var user = _middlewareClient.GetUserInfos(new List<Guid>() { userId.Value }).FirstOrDefault();
        return user?.Fullname;
    }

    private UnionTransfers Get(Guid id)
    {
        return Query()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }
    
    private IQueryable<UnionTransfers> Query()
    {
        return _repository.Query();
    }

    private IQueryable<UnionTransfers> GetLastMonths(DateTime now)
    {
        var startingReference = now.AddYears(-1).AddMonths(1);
        var endingReference = now;

        return Query()
                .Where(e => e.Status == UnionTransfersStatus.Active)
                .Where(e => e.Date.Year >= startingReference.Year)
                .Where(e => e.Date.Year <= endingReference.Year)
                .Where(e => e.Date.Year != endingReference.Year || e.Date.Month <= endingReference.Month)
                .Where(e => e.Date.Year != startingReference.Year || e.Date.Month >= startingReference.Month);
    }

    private static UnionTransfers ConvertToEntity(UnionTransfersInsertUpdateViewModel model)
    {
        return new(model.Value, model.Date, model.Status);
    }

    private static UnionTransfersViewModel ConvertToViewModel(UnionTransfers entity)
    {
        return new(entity.Value, entity.Date, entity.Status, entity.Id);
    }

    private static List<UnionTransfersDashboardItem> ValidateDashboardItens(List<UnionTransfersDashboardItem> itens, DateTime now)
    {
        var startingReference = now.AddYears(-1).AddMonths(1);
        var endingReference = now;

        var months = itens.Select(e => e.Date.Month);
        var allMonths = Enumerable.Range(1, 12);
        var missing = allMonths.Where(e => !months.Contains(e)).ToList();

        missing.ForEach(e =>
        {
            var year = DefineMissingDashboardItemYear(startingReference, endingReference, e);
            itens.Add(new(0, year, e));
        });

        return itens.OrderBy(e => e.Date).ToList();
    }

    private static int DefineMissingDashboardItemYear(DateTime staringReference, DateTime endingReference, int month)
    {
        return (endingReference.Month < month) ? staringReference.Year : endingReference.Year;
    }

    private static void ValidateModel(UnionTransfersInsertUpdateViewModel model)
    {
        if (model.Value <= 0)
            throw new BadRequestException($"O valor '{model.Value}' é inválido.");
    }

    private static void ThrowIfNull(object entity, string message = "entidade")
    {
        if (entity == null)
            throw new NotFoundException($"{message} não encontrado.");
    }

    private static IQueryable<UnionTransfers> Filter(IQueryable<UnionTransfers> query, UnionTransfersParams @params, Metadata meta)
    {
        query = query
            .WhereIf(@params.StartingReference, e => e.Date >= @params.StartingReference)
            .WhereIf(@params.EndingReference, e => e.Date <= @params.EndingReference)
            .WhereIf(@params.MinValue, e => e.Value >= @params.MinValue)
            .WhereIf(@params.MaxValue, e => e.Value <= @params.MinValue)
            .WhereIf(@params.Status, e => e.Status == @params.Status);

        string sortColLowercase = meta.SortColumn.ToLower();
        Expression<Func<UnionTransfers, Object>> filter = sortColLowercase switch
        {
            "value" => e => e.Value,
            "date" => e => e.Date,
            "status" => e => e.Status,
            _ => x => x.CreatedAt
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdat";

        var direction = meta.SortDirection.ToLower();
        query = (direction == "desc") ? query.OrderByDescending(filter) : query.OrderBy(filter);

        return query;
    }
}