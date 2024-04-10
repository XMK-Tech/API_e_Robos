using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Commom;

public class TaxProcedureServices : ITaxProcedureServices
{
    private readonly ITaxProcedureRepository _repository;
    private readonly ITaxParamRepository _taxParamRepository;

    private readonly IProprietyServices _proprietyServices;
    private readonly ITaxStageServices _taxStageServices;
    private readonly IEntitiesServices _entitiesServices;
    private readonly ISessionServices _sessionServices;
    private readonly IPDFGenerator _pDFGenerator;
    private readonly IAuditServices _auditServices;
    private readonly MiddlewareClient _middlewareClient;

    public TaxProcedureServices(ITaxProcedureRepository repository, IProprietyServices proprietyServices, ITaxParamRepository taxParamRepository, ITaxStageServices taxStageServices, IEntitiesServices entitiesServices, ISessionServices sessionServices, IPDFGenerator pDFGenerator, MiddlewareClient middlewareClient, IAuditServices auditServices)
    {
        _repository = repository;
        _taxParamRepository = taxParamRepository;

        _proprietyServices = proprietyServices;
        _taxStageServices = taxStageServices;
        _entitiesServices = entitiesServices;
        _sessionServices = sessionServices;
        _pDFGenerator = pDFGenerator;
        _auditServices = auditServices;
        _middlewareClient = middlewareClient;
    }

    public IEnumerable<TaxProcedureViewModel> GetAll(Metadata meta, TaxProcedureParams @params)
    {
        var query = Filter(GetAll(), meta, @params);
        return _repository
                .ExecuteQuery(query, meta)
                .Select(ConvertToViewModel)
                .ToList();
    }

    public TaxProcedureViewModel View(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, "TaxProcedure");

        return ConvertToViewModel(entity);
    }

    public TaxProcedureDashboard Dashboard()
    {
        var now = DateTime.Now;
        var entities = GetLastMonths(now);

        var itens = entities
                    .GroupBy(e => new { e.CreatedAt.Month, e.CreatedAt.Year })
                    .Select(e => new TaxProcedureDashboardItem(e.Count(), e.Key.Year, e.Key.Month))
                    .ToList();

        itens = ValidateDashboardItens(itens, now);

        var sum = itens.Select(e => e.Count).DefaultIfEmpty(0).Sum();
        return new(sum, now, itens);
    }

    public TaxProcedureViewModel Insert(TaxProcedureInsertUpdateViewModelViewModel model)
    {
        ValidateModel(model);

        var propriety = _proprietyServices.View(model.ProprietyId);
        var entity = ConvertToEntity(model, propriety.CibNumber);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    public TaxProcedureViewModel Update(TaxProcedureInsertUpdateViewModelViewModel model, Guid id)
    {
        ValidateModel(model);

        var entity = Get(id);
        ThrowIfNull(entity, "TaxProcedure");
        
        UpdateEntity(model, entity);
        _repository.Update(entity);

        _taxParamRepository.DeleteMany(entity.TaxParams.ToList());
        _taxParamRepository.InsertMany(model.TaxParams.Select(e => new TaxParam(e, entity.Id)).ToList());

        return ConvertToViewModel(Get(entity.Id));
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, "TaxProcedure");

        _taxStageServices.DeleteMany(entity.TaxStages.ToList());

        if (entity.TaxParams.Any())
            _taxParamRepository.DeleteMany(entity.TaxParams.ToList());

        _repository.Delete(entity);
    }

    private void ValidateModel(TaxProcedureInsertUpdateViewModelViewModel model)
    {
        var messages = new List<string>();

        var proprietyIdIsValid = ((_proprietyServices.View(model.ProprietyId)) != null);
        if (!proprietyIdIsValid)
            messages.Add("O Id da propriedade é inválido.");

        if (!model.TaxParams.Any())
            messages.Add("O atributo TaxParams é obrigatório.");

        if (model.IntimationYear == null)
            messages.Add("O atributo IntimationYear é obrigatório.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private IQueryable<TaxProcedure> GetLastMonths(DateTime now)
    {
        var startingReference = now.AddYears(-1).AddMonths(1);
        var endingReference = now;

        return _repository
                .Query()
                .Where(e => e.CreatedAt.Year >= startingReference.Year)
                .Where(e => e.CreatedAt.Year <= endingReference.Year)
                .Where(e => e.CreatedAt.Year != endingReference.Year || e.CreatedAt.Month <= endingReference.Month)
                .Where(e => e.CreatedAt.Year != startingReference.Year || e.CreatedAt.Month >= startingReference.Month);
    }

    public bool Exist(Guid? id)
    {
        return _repository.Query().Where(e => e.Id == id).Any();
    }

    public async Task<byte[]> Print(TaxProcedureReportModel model)
    {
        if (model.StartDate > model.EndDate)
            throw new BadRequestException("O intervalo informado é inválido.");

        model.Image = _entitiesServices.GetBase64Image();
        model.UserName = GetUserName();

        model.Itens = _repository
                        .Query()
                        .Include(x => x.TaxStages)
                        .ThenInclude(x => x.AnsweredByStage)
                        .Where(e => e.CreatedAt >= model.StartDate && e.CreatedAt <= model.EndDate)
                        .Where(e => e.TaxStages.Any())
                        .ToList()
                        .Select(e => new TaxProcedureReportItem(e.TaxStages?.OrderByDescending(x => x.CertificationDate).FirstOrDefault(), e.ProcessNumber))
                        .OrderBy(e => e.ResponseDate)
                        .ToList();
        
        return await _pDFGenerator.Generate(model, "TaxProcedure");
    }

    public async Task<byte[]> PrintLog(TaxProcedureReportLogModel model)
    {
        if (model.StartDate > model.EndDate)
            throw new BadRequestException("O intervalo informado é inválido.");

        model.Image = _entitiesServices.GetBase64Image();
        model.UserName = GetUserName();
        model.Itens = new();
        
        var procedures = _repository
                            .Query()
                            .Include(x => x.TaxStages)
                            .Where(e => e.CreatedAt >= model.StartDate && e.CreatedAt <= model.EndDate)
                            .Select(e => new {e.Id, e.ProcessNumber})
                            .ToList();

        var persons = new Dictionary<Guid?, string>();

        procedures.ForEach(p =>
        {
            var audits = _auditServices.GetEvents(new List<AuditType>() { AuditType.Create, AuditType.Update }, p.Id, null, model.StartDate, model.EndDate);
            var toAdd = new List<TaxProcedureReportLogItem>();

            audits.ForEach(a =>
            {
                if (!persons.ContainsKey(a.UserId))
                {
                    var userName = GetUserName(a.UserId);
                    persons.Add(a.UserId, userName);
                }

                dynamic newValues = JObject.Parse(a.NewValues);
                if (a.Type == AuditType.Create.ToString())
                    toAdd.Add(new TaxProcedureReportLogItem(newValues.ProcessNumber.ToString(), "Novo processo cadastrado", a.CreatedAt, persons[a.UserId]));                     
                else
                {
                    dynamic oldValues = JObject.Parse(a.OldValues);
                    if (ConvertFromJsonStatus(oldValues.Status) != ProcedureStatus.Finished && ConvertFromJsonStatus(newValues.Status) == ProcedureStatus.Finished)
                        toAdd.Add(new TaxProcedureReportLogItem(newValues.ProcessNumber.ToString(), "Procedimento encerrado", a.CreatedAt, persons[a.UserId]));
                }
            });

            if (toAdd.Any())
                model.Itens.AddRange(toAdd);
        });

        model.Itens = model.Itens.OrderBy(e => e.Date).ToList();

        return await _pDFGenerator.Generate(model, "TaxProcedureLog");
    }
    
    private string GetUserName(Guid? id = null)
    {
        var userId = id ?? _sessionServices.GetUserId();

        if (!userId.HasValue)
            return null;

        var user = _middlewareClient.GetUserInfos(new List<Guid>() { userId.Value }).FirstOrDefault();
        return user?.Fullname;
    }
    
    private static ProcedureStatus ConvertFromJsonStatus(dynamic data)
    {
        var str = data.ToString();
        return (ProcedureStatus)int.Parse(str);
    }

    private TaxProcedure Get(Guid id)
    {
        return GetAll()
                .Include(e => e.TaxStages)
                .ThenInclude(e => e.Attachments)
                .ThenInclude(e => e.Attachment)
                .Include(e => e.TaxStages)
                .ThenInclude(e => e.Subject)
                .Where(e => e.Id == id)
                .AsNoTracking()
                .FirstOrDefault();
    }

    private IQueryable<TaxProcedure> GetAll()
    {
        return _repository
                .Query()
                .Include(e => e.Propriety)
                .Include(e => e.Propriety.Contact)
                .Include(e => e.Propriety.Characteristics)
                .Include(e => e.Propriety.Address)
                .ThenInclude(e => e.Address)
                .ThenInclude(e => e.City)
                .Include(e => e.TaxParams);
    }

    private static TaxProcedure ConvertToEntity(TaxProcedureInsertUpdateViewModelViewModel model, string cibNumber)
    {
        var procedure = new TaxProcedure(model.IntimationYear, model.ProcessNumber, cibNumber, model.Status, model.ProprietyId);
        procedure.TaxParams = model.TaxParams.Select(e => new TaxParam(e, procedure.Id)).ToList();

        return procedure;
    }

    private void UpdateEntity(TaxProcedureInsertUpdateViewModelViewModel newData, TaxProcedure entity)
    {
        if (entity == null || newData == null)
            return;

        entity.IntimationYear = newData.IntimationYear;
        entity.ProcessNumber = newData.ProcessNumber;
        entity.Status = newData.Status;
        entity.ProprietyId = newData.ProprietyId;

        var propriety = _proprietyServices.View(entity.ProprietyId);
        entity.CibNumber = propriety?.CibNumber;
    }

    private TaxProcedureViewModel ConvertToViewModel(TaxProcedure entity)
    {
        if (entity == null)
            return null;

        var propriety = entity.Propriety;
        var proprietyViewModel = (propriety == null) ? _proprietyServices.View(entity.ProprietyId) : ProprietyServices.ConvertToViewModel(propriety);

        return new TaxProcedureViewModel()
        {
            Id = entity.Id,
            CibNumber = proprietyViewModel?.CibNumber,
            CreatedAt = entity.CreatedAt,
            IntimationYear = entity.IntimationYear,
            TaxParams = entity.TaxParams.Select(e => e.ParamType).ToList(),
            ProcessNumber = entity.ProcessNumber,
            Status = entity.Status,
            Propriety = proprietyViewModel,
            Stages = _taxStageServices.ConvertToViewModel(entity.TaxStages)
        };
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }

    private static IQueryable<TaxProcedure> Filter(IQueryable<TaxProcedure> query, Metadata metadata = null, TaxProcedureParams @params = null)
    {
        if (@params == null)
            return query;
        
        query = query
            .WhereIf(@params.ParamType.HasValue, e => e.TaxParams.Any(f => f.ParamType == @params.ParamType.Value))
            .WhereIf(@params.Status.HasValue, e => e.Status == @params.Status.Value)
            .WhereIf(@params.IntimationYear, e => e.IntimationYear.Contains(@params.IntimationYear))
            .WhereIf(@params.ProcessNumber, e => e.ProcessNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(@params.ProcessNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
            .WhereIf(@params.CibNumber, e => e.CibNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(@params.CibNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
            .WhereIf(@params.ProprietyName, e => e.Propriety.Name.ToLower().Contains(@params.ProprietyName.ToLower()))
            .WhereIf(@params.CreatedAt, e => e.CreatedAt.Date == @params.CreatedAt.Value.Date);


        string sortColLowercase = metadata.SortColumn.ToLower();
        Expression<Func<TaxProcedure, Object>> filter = sortColLowercase switch
        {
            "cib" => e => e.CibNumber,
            "intimationyear" => e => e.IntimationYear,
            "proprietyname" => e => e.Propriety.Name,
            _ => x => x.CreatedAt
        };

        if (string.IsNullOrEmpty(metadata.SortColumn))
            metadata.SortColumn = "createdat";

        var direction = metadata.SortDirection.ToLower();
        query = (direction == "desc") ? query.OrderByDescending(filter) : query.OrderBy(filter);

        return query;
    }

    private static List<TaxProcedureDashboardItem> ValidateDashboardItens(List<TaxProcedureDashboardItem> itens, DateTime now)
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
}