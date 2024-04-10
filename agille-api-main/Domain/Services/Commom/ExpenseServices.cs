using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AgilleApi.Domain.Services.Commom;

public class ExpenseServices : IExpenseServices
{
    private readonly IExpenseRepository _repository;
    private readonly IExpenseAttachmentRepository _attachmentRepository;
    private readonly IAttachmentServices _attachmentServices;
    private readonly IReportServices _reportServices;
    private readonly ILogosServices _logosServices;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IAgiprevCrawlerServices _agiprevCrawlerServices;

    public ExpenseServices(
        IExpenseRepository repository,
        IExpenseAttachmentRepository attachmentRepository,
        IAttachmentServices attachmentServices,
        IReportServices reportServices,
        ILogosServices logosServices,
        IEntitiesServices entitiesServices,
        IAgiprevCrawlerServices agiprevCrawlerServices)
    {
        _repository = repository;
        _attachmentRepository = attachmentRepository;
        _attachmentServices = attachmentServices;
        _reportServices = reportServices;
        _logosServices = logosServices;
        _entitiesServices = entitiesServices;
        _agiprevCrawlerServices = agiprevCrawlerServices;
    }

    public IEnumerable<ExpenseViewModel> List(Metadata meta, ExpenseParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, meta, @params);

        return _repository
                .ExecuteGenericQuery(query, meta, ViewModelConverter());
    }
    
    public ReportResponseViewModel GeneratePDFReport(Metadata meta, ExpenseParams @params)
    {
        var tableData = GenerateHeadersAndBody(meta, @params);

        tableData.Title = "DESPESAS";

        var entity = _entitiesServices.View();
        tableData.Image = _logosServices.GetUrlLogoInBase64(entity.EntityImage);
        tableData.EntityName = entity.Name;
        tableData.EntityDocument = entity.Document;

        return _reportServices.GeneratePDFReport(tableData);
    }
    
    public ReportResponseViewModel GenerateCSVReport(Metadata meta, ExpenseParams @params)
    {
        var tableData = GenerateHeadersAndBody(meta, @params);
        return _reportServices.GenerateCSVReport(tableData.Headers, tableData.Objects.ToList());
    }
    
    private ReportViewModel GenerateHeadersAndBody(Metadata meta, ExpenseParams @params)
    {
        var query = _repository.Query()
            .Where(e => e.IsFromMainEntity);
        var list = Filter(query, meta, @params).ToList();

        var queryDynamic = list.Select(e => new
        {
            e.Index,
            e.Description,
            Reference = e.Reference.ToString("MM/yyyy"),
            Value = e.Value.FormatValue(),
        } as dynamic);

        var headers = new string[]
        {
            "Index",
            "Descricao",
            "Competencia",
            "Total",
        };

        var referencesDates = list.OrderBy(e => e.Reference).Select(e => e.Reference).ToList();
        var totalRecords = list.Count;
        var total = list.Select(x => x.Value).Sum().FormatValue();
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
            EndingReference = referencesDates.LastOrDefault()
        };
    }

    public ExpenseViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("Expense not found.");

        return entity;
    }

    public FilterSumViewModel GetFilterSum(ExpenseParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, null, @params);

        return new()
        {
            Sum = query.Select(e => e.Value).Sum(),
            Count = query.Count()
        };
    }

    public IQueryable<Expense> GetQueryForYear(string year)
    {
        return _repository
                .Query()
                .Where(expense => expense.Reference.Year.ToString() == year)
                .Where(expense => expense.IsFromMainEntity);
    }
    
    public IQueryable<Expense> GetQueryForCompetence(string year, string month)
    {
        return GetQueryForYear(year)
                .Where(expense => expense.Reference.Month.ToString() == month);
    }

    public void ImportFromCrawler(AgiprevImportParams @params)
    {
        var models = _agiprevCrawlerServices.Import<ExpenseInsertUpdateViewModel>(@params.Reference);

        NormalizeImportedEntitiesReference(@params.Reference, models);

        var entities = models.Select(ConvertToEntity).ToList();
        _repository.InsertMany(entities);
    }

    private static void NormalizeImportedEntitiesReference(DateTime expectedReference, List<ExpenseInsertUpdateViewModel> models)
    {
        var newReference = new DateTime(expectedReference.Year, expectedReference.Month, 1);

        models.ForEach(item =>
        {
            var currentReference = item.Reference;
            item.PaymentDate = currentReference;
            
            if (currentReference.Year != expectedReference.Year || currentReference.Month != expectedReference.Month)
                item.Reference = newReference;
        });
    }

    public void Insert(ExpenseInsertUpdateViewModel model)
    {
        ThrowExceptionIfModelIsInvalid(model);

        var entity = ConvertToEntity(model);
        _repository.Insert(entity);
    }

    public void Update(Guid id, ExpenseInsertUpdateViewModel model)
    {
        ThrowExceptionIfModelIsInvalid(model, id);

        var entity = _repository.GetById(id);
        if (entity == null)
            throw new NotFoundException("Expense not found.");

        UpdateEntity(model, entity);
        _repository.Update(entity);
    }

    private void ThrowExceptionIfModelIsInvalid(ExpenseInsertUpdateViewModel model, Guid? expenseId = null)
    {
        var messages = new List<string>();

        if (model.Value < 0)
            messages.Add("Value must be greater than zero.");

        if (string.IsNullOrEmpty(model.Year))
            messages.Add("Year is required.");

        if (!IndexIsAvailable(model.Index, expenseId))
            messages.Add("Index unavailable.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    public void AttachFile(Guid expenseId, ExpenseAttachmentInsertUpdateViewModel model)
    {
        ThrowExceptionIfAttachmentNotFound(model.AttachmentId);
        ThrowExceptionIfExpenseNotFound(expenseId);
        ThrowExceptionIfExpenseHasThisAttachment(expenseId, model.AttachmentId);

        var entity = new ExpenseAttachment()
        {
            Favored = model.Favored,
            Document = model.Document,
            Contract = model.Contract,
            Validity = model.Validity,
            Description = model.Description,
            Type = model.Type,
            AttachmentId = model.AttachmentId,
            ExpenseId = expenseId
        };
        _attachmentRepository.Insert(entity);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }

    private void ThrowExceptionIfAttachmentNotFound(Guid attachmentId)
    {
        if (!_attachmentServices.Exists(attachmentId))
            throw new NotFoundException("Attachment not found.");
    }

    private void ThrowExceptionIfExpenseNotFound(Guid expenseId)
    {
        if (!Exists(expenseId))
            throw new NotFoundException("Expense not found.");
    }

    private bool Exists(Guid? expenseId)
    {
        return _repository
                .Query()
                .Any(expense => expense.Id == expenseId);
    }

    private bool IndexIsAvailable(int index, Guid? ignoringId = null)
    {
        return !_repository
                .Query()
                .WhereIf(ignoringId, expense => expense.Id != ignoringId)
                .Any(expense => expense.Index == index);
    }

    private void ThrowExceptionIfExpenseHasThisAttachment(Guid expenseId, Guid attachmentId)
    {
        var exists = _attachmentRepository
                        .Query()
                        .Any(e => e.ExpenseId == expenseId && e.AttachmentId == attachmentId);

        if (exists)
            throw new BadRequestException("This file is already attached to this expense.");
    }

    private static Expression<Func<Expense, ExpenseViewModel>> ViewModelConverter()
    {
        return expense => new ExpenseViewModel()
        {
            Id = expense.Id,
            CreatedAt = expense.CreatedAt,
            Year = expense.Year,
            PASEP = expense.PASEP,
            Index = expense.Index,
            Value = expense.Value,

            Reference = expense.Reference,
            PaymentDate = expense.PaymentDate,
            
            Description = expense.Description,
            Type = expense.Type,

            Attachments = expense.Attachments.Select(annex => new ExpenseAttachmentViewModel()
            {
                Favored = annex.Favored,
                Document = annex.Document,
                Contract = annex.Contract,
                Validity = annex.Validity,
                Description = annex.Description,

                Type = annex.Type,
                CreatedAt = annex.CreatedAt,

                Attachment = new AttachmentViewModel()
                {
                    Id = annex.Attachment.Id,
                    Url = annex.Attachment.Url,
                    ExternalId = annex.Attachment.ExternalId,
                    DisplayName = annex.Attachment.DisplayName,
                    Type = annex.Attachment.Type,
                    Owner = annex.Attachment.Owner,
                    OwnerId = annex.Attachment.OwnerId
                }
            })
        };
    }

    private static IQueryable<Expense> Filter(IQueryable<Expense> query, Metadata meta, ExpenseParams @params)
    {
        query = query
                .WhereIf(@params.Type, expense => expense.Type == @params.Type)
                .WhereIf(@params.Year, expense => expense.Year.Contains(@params.Year))
                .WhereIf(@params.Effort, expense => expense.PASEP.Contains(@params.Effort))
                .WhereIf(@params.Creditor, expense => expense.Description.Contains(@params.Creditor))
                .WhereIf(@params.Reference, expense => expense.Reference == @params.Reference)
                .WhereIf(@params.Competence, expense => expense.Reference.Year == @params.Competence.Value.Year
                                                     && expense.Reference.Month == @params.Competence.Value.Month)
                .WhereIf(@params.CityConfig, expense => expense.Description.ToLower().StartsWith(@params.CityConfig.ToLower()))
                .WhereInRange(@params.MinValue, @params.MaxValue, expense => expense.Value)
                .WhereIf(@params.IsFromMainEntity != null, expense => expense.IsFromMainEntity == @params.IsFromMainEntity);

        if (meta == null)
            return query;

        Expression<Func<Expense, object>> orderBy = meta.SortColumn.ToLower()
                switch
        {
            "year" => expense => expense.Year,
            "effort" => expense => expense.PASEP,
            "value" => expense => expense.Value,
            "reference" => expense => expense.Reference,
            "creditor" => expense => expense.Description,
            _ => expense => expense.Reference,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "reference";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }

    private static Expense ConvertToEntity(ExpenseInsertUpdateViewModel model)
    {
        var year = model.Reference.Year.ToString();
        return new Expense(year, model.PASEP, model.Index, model.Value, model.Reference, model.Description, model.Type, model.IsFromMainEntity, model.RelatedEntityId)
        {
            CrawlerFileId = model.CrawlerFileId,
            PaymentDate = model.PaymentDate
        };
    }

    private static void UpdateEntity(ExpenseInsertUpdateViewModel model, Expense entity)
    {
        var year = model.Reference.Year.ToString();

        entity.Year = year;
        entity.PASEP = model.PASEP;
        entity.Index = model.Index;
        entity.Value = model.Value;
        entity.Reference = model.Reference;
        entity.Description = model.Description;
        entity.Type = model.Type;
        entity.IsFromMainEntity = model.IsFromMainEntity;
        entity.RelatedEntityId = model.RelatedEntityId;
    }
}