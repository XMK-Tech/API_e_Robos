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

public class CollectionServices : ICollectionServices
{
    private readonly ICollectionRepository _repository;
    private readonly ICollectionAttachmentRepository _attachmentRepository;
    private readonly IAttachmentServices _attachmentServices;
    private readonly IReportServices _reportServices;
    private readonly ILogosServices _logosServices;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IAgiprevCrawlerServices _agiprevCrawlerServices;

    public CollectionServices(
        ICollectionRepository repository,
        ICollectionAttachmentRepository attachmentRepository,
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

    public IQueryable<Collection> GetQueryForCompetence(string year, string month)
    {
        return _repository
                    .Query()
                    .Where(collection => collection.Reference.Year.ToString() == year)
                    .Where(collection => collection.Reference.Month.ToString() == month)
                    .Where(collection => collection.IsFromMainEntity);
    }

    public IEnumerable<CollectionViewModel> List(Metadata meta, CollectionParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, meta, @params);

        return _repository
                .ExecuteGenericQuery(query, meta, ViewModelConverter());
    }
    public ReportResponseViewModel GeneratePDFReport(Metadata meta, CollectionParams @params)
    {
        var tableData = GenerateHeadersAndBody(meta, @params);

        tableData.Title = "RECOLHIMENTOS";

        var entity = _entitiesServices.View();
        tableData.Image = _logosServices.GetUrlLogoInBase64(entity.EntityImage);
        tableData.EntityName = entity.Name;
        tableData.EntityDocument = entity.Document;

        return _reportServices.GeneratePDFReport(tableData);
    }
    public ReportResponseViewModel GenerateCSVReport(Metadata meta, CollectionParams @params)
    {
        var tableData = GenerateHeadersAndBody(meta, @params);
        return _reportServices.GenerateCSVReport(tableData.Headers, tableData.Objects.ToList());
    }
    private ReportViewModel GenerateHeadersAndBody(Metadata meta, CollectionParams @params)
    {
        var query = _repository.Query()
            .Where(e => e.IsFromMainEntity);
        var list = Filter(query, meta, @params).ToList();

        var queryDynamic = list.Select(e => new
        {
            Reference = e.Reference.ToString("MM/yyyy"),
            Payday = e.Payday.ToString("dd/MM/yyyy"),
            SelicValue = e.SelicValue.FormatValue(),
            PasepValue = e.PasepValue.FormatValue(),
        } as dynamic);

        var headers = new string[]
        {
            "Competencia",
            "Pagamento",
            "Valor Principal",
            "Valor Total Recolhimento PASEP",
        };

        var referencesDates = list.OrderBy(e => e.Reference).Select(e => e.Reference).ToList();
        var totalRecords = list.Count;
        var totalPasepValue = list.Select(x => x.PasepValue).Sum().FormatValue();
        var totalSelicValue = list.Select(x => x.SelicValue).Sum().FormatValue();

        var fieldAlignments = new List<string>()
        {
            "center", "center", "right", "right"
        };
        
        return new ReportViewModel()
        {
            TotalRecords = totalRecords,
            CollectionTotals = new(totalPasepValue, totalSelicValue),
            FieldAlignments = fieldAlignments,

            Headers = headers,
            Objects = queryDynamic.ToList(),

            StartingReference = referencesDates.FirstOrDefault(),
            EndingReference = referencesDates.LastOrDefault()
        };
    }

    public CollectionViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("Collection not found.");

        return entity;
    }

    public FilterSumViewModel GetFilterSum(CollectionParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, null, @params);

        return new()
        {
            Sum = query.Select(e => e.PasepValue).Sum(),
            Count = query.Count()
        };
    }

    public void ImportFromCrawler(AgiprevImportParams @params)
    {
        var models = _agiprevCrawlerServices.Import<CollectionInsertUpdateViewModel>(@params.Reference);

        models.ForEach(item =>
        {
            var payday = item.Payday;
            item.Reference = new DateTime(payday.Year, payday.Month, 1);
        });

        var entities = models.Select(e => ConvertToEntity(e)).ToList();
        _repository.InsertMany(entities);
    }

    public void AttachFile(Guid collectionId, CollectionAttachmentInsertUpdateViewModel model)
    {
        ThrowExceptionIfAttachmentNotFound(model.AttachmentId);
        ThrowExceptionIfCollectionNotFound(collectionId);
        ThrowExceptionIfCollectionHasThisAttachment(collectionId, model.AttachmentId);

        var entity = new CollectionAttachment(model.Type, model.Description, model.AttachmentId, collectionId);
        _attachmentRepository.Insert(entity);
    }

    public void Insert(CollectionInsertUpdateViewModel viewModel)
    {
        ValueValidation(viewModel);
        var entity = ConvertToEntity(viewModel);
        _repository.Insert(entity);
    }

    private static void ValueValidation(CollectionInsertUpdateViewModel viewModel)
    {
        if (viewModel.PasepValue < 0)
            throw new ConflictException("O valor do Pasep não pode ser menor que 0");
        if (viewModel.SelicValue < 0)
            throw new ConflictException("Valor da Selic não pode ser menor que 0");
    }

    public void Update(CollectionInsertUpdateViewModel viewModel, Guid id)
    {
        ValueValidation(viewModel);
        var entity = _repository.GetById(id);
        if (entity == null)
            throw new NotFoundException("Collection not found.");

        entity = ConvertToEntity(viewModel, entity: entity);
        _repository.Update(entity);
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

    private void ThrowExceptionIfCollectionNotFound(Guid collectionId)
    {
        if (!Exists(collectionId))
            throw new NotFoundException("Collection not found.");
    }

    private bool Exists(Guid? collectionId)
    {
        return _repository
                .Query()
                .Any(e => e.Id == collectionId);
    }

    private void ThrowExceptionIfCollectionHasThisAttachment(Guid collectionId, Guid attachmentId)
    {
        var exists = _attachmentRepository
                        .Query()
                        .Any(e => e.CollectionId == collectionId && e.AttachmentId == attachmentId);

        if (exists)
            throw new BadRequestException("This file is already attached to this collection.");
    }

    private static Expression<Func<Collection, CollectionViewModel>> ViewModelConverter()
    {
        return collection => new CollectionViewModel()
        {
            Id = collection.Id,
            CreatedAt = collection.CreatedAt,
            PasepValue = collection.PasepValue,
            SelicValue = collection.SelicValue,
            Reference = collection.Reference,
            Payday = collection.Payday,
            RelatedEntityId = collection.RelatedEntityId,
            IsFromMainEntity = collection.IsFromMainEntity,

            Attachments = collection.Attachments.Select(annex => new CollectionAttachmentViewModel()
            {
                Type = annex.Type,
                Description = annex.Description,
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

    private static Collection ConvertToEntity(CollectionInsertUpdateViewModel model, Collection entity = null)
    {
        if (entity == null)
            entity = new Collection(pasepValue: model.PasepValue, selicValue: model.SelicValue, reference: model.Reference, payday: model.Payday, isFromMainEntity: model.IsFromMainEntity, relatedEntityId: model.RelatedEntityId)
            {
                CrawlerFileId = model.CrawlerFileId,
            };
        else
            entity.Update(pasepValue: model.PasepValue, selicValue: model.SelicValue, reference: model.Reference, payday: model.Payday, isFromMainEntity: model.IsFromMainEntity, relatedEntityId: model.RelatedEntityId);
        return entity;
    }

    private static IQueryable<Collection> Filter(IQueryable<Collection> query, Metadata meta, CollectionParams @params)
    {
        query = query
                .WhereInRange(@params.MinPasepValue, @params.MaxPasepValue, collection => collection.PasepValue)
                .WhereInRange(@params.MinSelicValue, @params.MaxSelicValue, collection => collection.SelicValue)
                .WhereIf(@params.Reference, collection => collection.Reference == @params.Reference)
                .WhereIf(@params.Year, collection => collection.Reference.Year.ToString() == @params.Year)
                .WhereIf(@params.Payday, collection => collection.Payday == @params.Payday)
                //.WhereIf(@params.CityConfig, collection => collection.PasepValue.ToString().ToLower().StartsWith(@params.CityConfig.ToLower()))
                .WhereIf(@params.IsFromMainEntity != null, collection => collection.IsFromMainEntity == @params.IsFromMainEntity);

        if (meta == null)
            return query;

        Expression<Func<Collection, object>> orderBy = meta.SortColumn.ToLower()
                switch
        {
            "pasepvalue" => x => x.PasepValue,
            "selicvalue" => x => x.SelicValue,
            "reference" => x => x.Reference,
            "payday" => x => x.Payday,
            _ => x => x.CreatedAt,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdAt";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }

}