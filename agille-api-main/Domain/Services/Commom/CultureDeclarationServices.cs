using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
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

public class CultureDeclarationServices : ICultureDeclarationServices
{
    private readonly ICultureDeclarationRepository _repository;
    private readonly ISessionServices _sessionServices;
    private readonly ICultureTypeServices _cultureTypeServices;
    private readonly IReportServices _reportServices;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IMiddlewareClient _middlewareClient;
    private readonly IProprietyServices _proprietyServices;

    public CultureDeclarationServices(
        ICultureDeclarationRepository repository,
        ISessionServices sessionServices,
        ICultureTypeServices cultureTypeServices,
        IReportServices reportServices,
        IEntitiesServices entitiesServices,
        IMiddlewareClient middlewareClient,
        IProprietyServices proprietyServices)
    {
        _repository = repository;
        _sessionServices = sessionServices;
        _cultureTypeServices = cultureTypeServices;
        _reportServices = reportServices;
        _entitiesServices = entitiesServices;
        _middlewareClient = middlewareClient;
        _proprietyServices = proprietyServices;
    }

    public IEnumerable<CultureDeclarationViewModel> List(CultureDeclarationParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, @params);

        return query
                .Select(ViewModelConverter())
                .ToList();
    }

    public CultureDeclarationViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("CultureDeclaration not found.");

        return entity;
    }

    public ReportResponseViewModel GenerateAgricultureReport(ReportIntervalViewModel interval)
    {
        var city = _entitiesServices.GetCityName();

        var query = ApplyReportInterval(_repository.Query(), interval)
                    .Where(e => e.Culture.Type == CultureTypeOptions.Agriculture)
                    .GroupBy(e => new { e.Year, e.Month, e.CultureId})
                    .Select(e => new
                    {
                        city,
                        Month = e.First().Month.GetDescription(),
                        e.First().Year,
                        e.First().Culture.Name,
                        Area = e.Sum(f => f.Area),
                    } as dynamic);

        var headers = new string[]
        {
            "Cidade",
            "Mes",
            "Ano",
            "Cultura",
            "Area de plantio"
        };
        var title = "RELATORIO AREA DE PLANTIO POR CULTURA";

        return GenerateReport(interval, title, headers, query);
    }

    public ReportResponseViewModel GenerateAnimalsReport(ReportIntervalViewModel interval)
    {
        var city = _entitiesServices.GetCityName();

        var query = ApplyReportInterval(_repository.Query(), interval)
                    .Where(e => e.Culture.Type == CultureTypeOptions.FishFarms || e.Culture.Type == CultureTypeOptions.Livestock)
                    .GroupBy(e => new { e.Year, e.Month, e.CultureId })
                    .Select(e => new
                    {
                        city,
                        Month = e.First().Month.GetDescription(),
                        e.First().Year,
                        e.First().Culture.Name,
                        Type = e.First().Culture.Type.GetDescription(),
                        Total = (e.Sum(f => f.Count) == 0) ? e.Sum(f => f.MaleCount + f.FemaleCount) : e.Sum(f => f.Count),
                        Male = e.Sum(f => f.MaleCount),
                        Female = e.Sum(f => f.FemaleCount)
                    } as dynamic);

        var headers = new string[]
        {
            "Cidade",
            "Mes",
            "Ano",
            "Especie",
            "Tipo",
            "Total",
            "Machos",
            "Femeas"
        };
        var title = "RELATORIO DE QUANTIDADE DE CABECAS POR ESPECIE DE ANIMAL";

        return GenerateReport(interval, title, headers, query);
    }

    public ReportResponseViewModel GenerateFishFarmsReport(ReportIntervalViewModel interval)
    {
        var city = _entitiesServices.GetCityName();

        var query = ApplyReportInterval(_repository.Query(), interval)
                    .Where(e => e.Culture.Type == CultureTypeOptions.FishFarms)
                    .GroupBy(e => new { e.Year, e.Month, e.CultureId })
                    .Select(e => new
                    {
                        city,
                        Month = e.First().Month.GetDescription(),
                        e.First().Year,
                        e.First().Culture.Name,
                        Total = e.Sum(f => f.Area),
                        Count = (e.Sum(f => f.Count) == 0) ? e.Sum(f => f.MaleCount + f.FemaleCount) : e.Sum(f => f.Count),
                    } as dynamic);

        var headers = new string[]
        {
            "Cidade",
            "Mes",
            "Ano",
            "Especie",
            "Laminas Dagua",
            "Individuos"
        };
        var title = "RELATORIO DE QUANTIDADE DE TOTAL DE LAMINA DAGUA";

        return GenerateReport(interval, title, headers, query);
    }

    private ReportResponseViewModel GenerateReport(ReportIntervalViewModel interval, string title, string[] headers, IQueryable<dynamic> query)
    {
        ThrowExceptionIfIntervalIsInvalid(interval);

        var image = _entitiesServices.GetBase64Image();
        var auditor = GetCurrentUserName();
        
        return _reportServices.GeneratePDFReport(title, headers, query.ToList(), image, interval.StartingReference, interval.EndingReference, auditor);
    }

    private static void ThrowExceptionIfIntervalIsInvalid(ReportIntervalViewModel interval)
    {
        if (interval.StartingReference.HasValue && interval.EndingReference.HasValue)
        {
            if (interval.StartingReference > interval.EndingReference)
                throw new BadRequestException("Invalid reference.");
        }
    }

    private static IQueryable<CultureDeclaration> ApplyReportInterval(IQueryable<CultureDeclaration> query, ReportIntervalViewModel interval)
    {
        query = query
                .WhereIf(interval.StartingReference, e => Convert.ToInt32(e.Year) >= interval.StartingReference.Value.Year)
                .WhereIf(interval.StartingReference, e => Convert.ToInt32(e.Year) != interval.StartingReference.Value.Year  || (int)e.Month >= interval.StartingReference.Value.Month)
                .WhereIf(interval.EndingReference, e => Convert.ToInt32(e.Year) <= interval.EndingReference.Value.Year)
                .WhereIf(interval.EndingReference, e => Convert.ToInt32(e.Year) != interval.EndingReference.Value.Year || (int)e.Month <= interval.EndingReference.Value.Month);

        return query;
    }

    private string GetCurrentUserName()
    {
        var userId = _sessionServices.GetUserId();
        
        var user = _middlewareClient
                    .GetUserInfos(new List<Guid>() { userId.Value })
                    .FirstOrDefault();
        return user?.Fullname;
    }

    public void Insert(CultureDeclarationInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var userId = _sessionServices.GetUserId();
        var entity = ConvertToEntity(model, userId);
        
        _repository.Insert(entity);
    }

    public void Update(Guid id, CultureDeclarationInsertUpdateViewModel model)
    {
        ValidateModel(model);
        
        var entity = _repository
            .Query()
            .Where(x => x.Id == id)
            .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("CultureDeclaration not found.");
		
        UpdateEntity(entity, model);

        _repository.Update(entity);
    }
    
    public void UpdateProprietyDeclarations(Guid proprietyId, string year, List<CultureDeclarationInsertUpdateManyViewModel> models)
    {
        ThrowExceptionIfProprietyDoesnExists(proprietyId);
        ThrowExceptionIfYearIsInvalid(year);

        models = NormalizeListWithoutDuplications(models);

        models.ForEach(e => ThrowExceptionIfModelIsInvalid(e));

        var proprietyEntities = ListProprietyDeclarationsForYear(proprietyId, year);

        var transaction = _repository.Transaction().BeginTransaction();
        try
        {
            var userId = _sessionServices.GetUserId();
            UpdateMany(proprietyId, year, models, userId, proprietyEntities);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
    }

    private List<CultureDeclaration> ListProprietyDeclarationsForYear(Guid proprietyId, string year)
    {
        return _repository
                .Query()
                .Where(e => e.ProprietyId == proprietyId && e.Year == year)
                .ToList();
    }

    private void UpdateMany(Guid proprietyId, string year, List<CultureDeclarationInsertUpdateManyViewModel> models, Guid? userId, List<CultureDeclaration> proprietyEntities)
    {
        List<CultureDeclaration> entitiesToInsert;
        List<CultureDeclaration> entitiesToDelete;
        List<CultureDeclaration> entitiesToUpdate;

        entitiesToInsert = models
                            .Where(e => !proprietyEntities.Any(h => h.CultureId == e.CultureId && h.Month == e.Month))
                            .Select(e => ConvertToEntity(e, proprietyId, year, userId))
                            .ToList();

        entitiesToDelete = proprietyEntities
                            .Where(e => !models.Any(h => h.CultureId == e.CultureId && h.Month == e.Month))
                            .ToList();

        entitiesToUpdate = proprietyEntities
                            .Where(e => models.Any(h => h.CultureId == e.CultureId && h.Month == e.Month))
                            .ToList();

        entitiesToUpdate.ForEach(e =>
        {
            var model = models.First(h => h.CultureId == e.CultureId && h.Month == e.Month);
            UpdateEntity(e, model);
        });

        _repository.InsertMany(entitiesToInsert);
        _repository.DeleteMany(entitiesToDelete);
        _repository.UpdateMany(entitiesToUpdate);
    }

    private void ThrowExceptionIfProprietyDoesnExists(Guid proprietyId)
    {
        if (!_proprietyServices.Exists(proprietyId))
            throw new NotFoundException("Propriety not found.");
    }

    public void Delete(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("CultureDeclaration not found.");

        _repository.Delete(entity);
    }
        
        
    private void ValidateModel(CultureDeclarationInsertUpdateViewModel model)
    {
        ThrowExceptionIfProprietyDoesnExists(model.ProprietyId);
        ThrowExceptionIfYearIsInvalid(model.Year);
        ThrowExceptionIfModelIsInvalid(model);
    }

    private static void ThrowExceptionIfYearIsInvalid(string year)
    {
        if (string.IsNullOrEmpty(year))
            throw new BadRequestException("Year is required.");
    }

    private void ThrowExceptionIfModelIsInvalid(CultureDeclarationViewModelBase model)
    {
        var messages = new List<string>();

        if (!_cultureTypeServices.Exists(model.CultureId))
            messages.Add("CultureType not found.");

        var total = (model.MaleCount + model.FemaleCount);
        if (model.Count != 0 && total != 0 && model.Count != total)
            messages.Add("The sum of males and females does not correspond to the total informed.");

        if (model.Month == Month.Null)
            messages.Add("Month is required.");
        
        if (messages.Any())
            throw new BadRequestException(messages);
    }
    
    private static List<CultureDeclarationInsertUpdateManyViewModel> NormalizeListWithoutDuplications(List<CultureDeclarationInsertUpdateManyViewModel> models)
    {
        var groups = models.GroupBy(e => new { e.CultureId, e.Month });

        if (groups.All(e => e.Count() == 1))
            return models;

        return groups.Select(e => new CultureDeclarationInsertUpdateManyViewModel()
        {
            CultureId = e.First().CultureId,
            Month = e.First().Month,
            MaleCount = e.Select(e => e.MaleCount).DefaultIfEmpty(0).Sum(),
            FemaleCount = e.Select(e => e.FemaleCount).DefaultIfEmpty(0).Sum(),
            Count = e.Select(e => e.Count).DefaultIfEmpty(0).Sum(),
            Area = e.Select(e => e.Area).DefaultIfEmpty(0).Sum(),
        }).ToList();
    }
    
    private static CultureDeclaration ConvertToEntity(CultureDeclarationInsertUpdateViewModel model, Guid? userId = null)
    {
        return new()
        {
            MaleCount = model.MaleCount,
            FemaleCount = model.FemaleCount,
            Count = model.Count,
            
            UserId = userId,            
            CultureId = model.CultureId,
            ProprietyId = model.ProprietyId,

            Area = model.Area,
            
            Month = model.Month,
            Year = model.Year,
        };
    }

    private static CultureDeclaration ConvertToEntity(CultureDeclarationInsertUpdateManyViewModel model, Guid proprietyId, string year, Guid? userId = null)
    {
        return new()
        {
            MaleCount = model.MaleCount,
            FemaleCount = model.FemaleCount,
            Count = model.Count,
            
            UserId = userId,
            CultureId = model.CultureId,
            ProprietyId = proprietyId,

            Area = model.Area,
            
            Month = model.Month,
            Year = year,
        };
    }

    private static void UpdateEntity(CultureDeclaration entity, CultureDeclarationViewModelBase model)
    {
        entity.MaleCount = model.MaleCount;
        entity.FemaleCount = model.FemaleCount;
        entity.Count = model.Count;
        entity.Area = model.Area;        
    }
            
    private static Expression<Func<CultureDeclaration, CultureDeclarationViewModel>> ViewModelConverter()
    {
        return x => new CultureDeclarationViewModel()
        {
            Id = x.Id,
            CreatedAt = x.CreatedAt,
            
            CultureName = x.Culture.Name,
            Type = x.Culture.Type,
            
            Month = x.Month,
            Year = x.Year,

            MaleCount = x.MaleCount,
            FemaleCount = x.FemaleCount,
            Count = x.Count,
            
            UserId = x.UserId,
            CultureId = x.CultureId,
            ProprietyId = x.ProprietyId,

            Area = x.Area,
            
            IsChecked = x.Culture.IsChecked,
            IsDefault = x.Culture.IsDefault,
        };
    }

    private static IQueryable<CultureDeclaration> Filter(IQueryable<CultureDeclaration> query, CultureDeclarationParams @params)
    {
        query = query
                .WhereIf(@params.CultureName, x => x.Culture.Name.Contains(@params.CultureName))
                .WhereIf(@params.Type, x => x.Culture.Type == @params.Type)
                .WhereIf(@params.MaleCount, x => x.MaleCount == @params.MaleCount)
                .WhereIf(@params.FemaleCount, x => x.FemaleCount == @params.FemaleCount)
                .WhereIf(@params.Count, x => x.Count == @params.Count.Value)
                .WhereIf(@params.Area, x => x.Area == @params.Area.Value)
                .WhereIf(@params.ProprietyId, x => x.ProprietyId == @params.ProprietyId)
                .WhereIf(@params.Month, x => x.Month == @params.Month)
                .WhereIf(@params.Year, x => x.Year == @params.Year);

        query = query
                .OrderBy(e => e.Year)
                .ThenBy(e => e.Month);
        
        return query;
    }
}