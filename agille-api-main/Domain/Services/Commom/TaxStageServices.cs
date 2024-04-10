using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Commom;

public class TaxStageServices : ITaxStageServices
{
    private readonly ITaxProcedureRepository _taxProcedureRepository;
    private readonly ITaxStageRepository _repository;
    private readonly ITaxStageAttachmentRepository _stageAttachmentRepository;
    private readonly IPersonServices _personServices;
    private readonly IARServices _aRServices;

    private readonly IPDFGenerator _pdfGenerator;

    private readonly AddressServices _addressServices;
    private readonly AttachmentServices _attachmentServices;
    private readonly MiddlewareClient _middlewareClient;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IImageLoaderServices _imageLoaderServices;
    private readonly ISessionServices _sessionServices;

    public TaxStageServices(
        ITaxStageRepository repository,
        AttachmentServices attachmentServices,
        IPersonServices personServices,
        ITaxProcedureRepository taxProcedureRepository,
        MiddlewareClient middlewareClient,
        IPDFGenerator pdfGenerator,
        IEntitiesServices entitiesServices,
        AddressServices addressServices,
        IImageLoaderServices imageLoaderServices,
        IARServices aRServices,
        ISessionServices sessionServices,
        ITaxStageAttachmentRepository stageAttachmentRepository)
    {
        _repository = repository;
        _attachmentServices = attachmentServices;
        _personServices = personServices;
        _taxProcedureRepository = taxProcedureRepository;
        _middlewareClient = middlewareClient;

        _pdfGenerator = pdfGenerator;
        _entitiesServices = entitiesServices;
        _addressServices = addressServices;
        _imageLoaderServices = imageLoaderServices;
        _aRServices = aRServices;
        _sessionServices = sessionServices;
        _stageAttachmentRepository = stageAttachmentRepository;
    }

    public TaxStageViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Include(e => e.Attachments)
                        .ThenInclude(e => e.Attachment)
                        .Include(e => e.Subject)
                        .Where(e => e.Status != ProcessStatus.Canceled)
                        .Where(e => e.Id == id)
                        .FirstOrDefault();
        ThrowIfNull(entity, "A etapa do procedimento fiscal");

        return ConvertToViewModel(entity);
    }

    public void Insert(Guid procedureId, TaxStageInsertUpdateViewModel model)
    {
        ThrowExceptionIfModelIsInvalid(procedureId, model);

        var entity = ConvertToEntity(model, procedureId);

        _repository.Insert(entity);

        UpdateTaxStageAttachments(entity.Id, model.AttachmentIds);
    }

    public void InsertReply(Guid taxStageId, TaxStageReplyInsertViewModel model)
    {
        ThrowExceptionIfReplyModelIsInvalid(taxStageId, model);

        var userId = _sessionServices.GetUserId();
        var replyTo = Get(taxStageId);

        if (HasAnswer(taxStageId))
            throw new BadRequestException("A etapa informada já possui uma resposta cadastrada no sistema.");

        if (replyTo.ReplyToId.HasValue)
            throw new BadRequestException("Não é possível responder essa etapa, pois ela já é uma resposta a uma terceira etapa.");

        var entity = ConvertToEntity(model, replyTo.TaxProcedureId, taxStageId, userId.Value);

        _repository.Insert(entity);
        SetTaxStageReplyStatus(replyTo, entity.CertificationDate);

        UpdateTaxStageAttachments(entity.Id, model.AttachmentIds);
    }

    private void SetTaxStageReplyStatus(TaxStage stage, DateTime? certificationDate)
    { 
        var limitTime = stage.CutOffDate;
        
        var onTimeForReply = true;
        if (limitTime.HasValue && certificationDate.HasValue)
            onTimeForReply = certificationDate <= limitTime.Value;
       
        stage.Status = (onTimeForReply) ? ProcessStatus.AnsweredOnTime : ProcessStatus.AnsweredAfterExpiration;

        _repository.Update(stage);
    }

    private bool HasAnswer(Guid id)
    {
        return _repository
                .Query()
                .Where(e => e.ReplyToId == id)
                .Any();
    }

    public void Update(Guid id, TaxStageInsertUpdateViewModel model)
    {
        ThrowExceptionIfModelIsInvalid(null, model);

        var entity = _repository
                        .Query()
                        .Where(e => e.Status != ProcessStatus.Canceled)
                        .Where(e => e.Id == id)
                        .FirstOrDefault();
        ThrowIfNull(entity, "A etapa do procedimento fiscal");

        entity.Status = model.Status;
        entity.Number = model.Number;
        entity.CutOffDate = model.CutOffDate;
        entity.CertificationDate = model.CertificationDate;
        entity.ARCode = model.ARCode;
        entity.Type = model.Type;
        entity.FineAmount = model.FineAmount;
        entity.TrackingCode = model.TrackingCode;
        entity.SubjectId = model.SubjectId;

        _repository.Update(entity);

        UpdateTaxStageAttachments(id, model.AttachmentIds);
    }

    public void Delete(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(e => e.Status != ProcessStatus.Canceled)
                        .Where(e => e.Id == id)
                        .FirstOrDefault();
        ThrowIfNull(entity, "A etapa do procedimento fiscal");

        UpdateTaxStageAttachments(id, new());

        _repository.Delete(entity);
    }

    private void UpdateTaxStageAttachments(Guid taxStageId, List<Guid> attachmentsIds)
    {
        attachmentsIds ??= new List<Guid>();
        var currentAttachments = _stageAttachmentRepository
                                    .Query()
                                    .Where(e => e.TaxStageId == taxStageId)
                                    .ToList();

        var attachmentsToRemove = currentAttachments
                                    .Where(e => !attachmentsIds.Contains(e.AttachmentId))
                                    .ToList();

        var attachmentsToAdd = attachmentsIds
                                    .Where(e => !currentAttachments.Any(a => a.AttachmentId == e))
                                    .Select(e => new TaxStageAttachment
                                    {
                                        AttachmentId = e,
                                        TaxStageId = taxStageId
                                    })
                                    .ToList();

        if (attachmentsToRemove.Any())
            _stageAttachmentRepository.DeleteMany(attachmentsToRemove);

        if (attachmentsToAdd.Any())
            _stageAttachmentRepository.InsertMany(attachmentsToAdd);
    }

    public void DeleteMany(List<TaxStage> stages)
    {
        if (stages.Any())
            _repository.DeleteMany(stages);
    }

    public async Task<byte[]> ForwardTerm(TaxStageForwardingTermViewModel model)
    {
        if (!ProcedureExist(model.TaxProcedureId))
            throw new NotFoundException("Procedimento fiscal não encontrado.");

        var stage = GetLastWithSubject(model.TaxProcedureId);
        if (stage == null)
            throw new BadRequestException("Nenhuma etapa válida(com sujeito passivo) foi encontrada para a geração do termo de encaminhamento.");

        var subject = stage.Subject;
        if (subject == null)
            throw new BadRequestException("A última etapa cadastrada não possui um sujeito passivo.");

        var userId = _sessionServices.GetUserId();
        var entity = Getentity();

        var data = new ForwardingTermNoticeModel(model)
        {
            SubjectName = subject?.Name,
            SubjectDocument = subject?.Document,
            ProprietyCib = stage?.TaxProcedure?.Propriety?.CibNumber,

            Auditor = GetUserName(userId),
            DocumentNumber = stage?.Number,
            ProcessNumber = stage?.TaxProcedure?.ProcessNumber,

            Image = _imageLoaderServices.ConvertToBase64(entity.EntityImage),
            EntityName = entity.Name,
            StateInitials = _addressServices.GetStateByCityName(entity.Name)
        };

        var response = await _pdfGenerator.Generate(data, "ForwardingTerm");
        var attachment = _attachmentServices.InsertByBytes(response, "Forward-term", "application/pdf", "TaxProcedure", model.TaxProcedureId.ToString());

        if (attachment != null)
        {
            stage.ForwardTermUrl = attachment.Url;
            _repository.Update(stage);
        }

        return response;
    }

    public async Task<byte[]> JoinTerm(TaxStageJoinTermViewModel model)
    {
        if (!StageExist(model.TaxStageId))
            throw new NotFoundException("Etapa do procedimento fiscal não encontrada(ou está deletada).");

        var stage = Get(model.TaxStageId);
        var subject = stage.Subject;

        if (subject == null)
            throw new BadRequestException("Essa etapa não possui um sujeito passivo vínculado. Logo, não é possível emitir o Termo de Juntada.");

        var userId = _sessionServices.GetUserId();
        var entity = Getentity();

        var data = new ForwardingTermNoticeModel(model)
        {
            SubjectName = subject?.Name,
            SubjectDocument = subject?.Document,
            ProprietyCib = stage?.TaxProcedure?.Propriety?.CibNumber,

            Auditor = GetUserName(userId),
            DocumentNumber = stage?.Number,
            ProcessNumber = stage?.TaxProcedure?.ProcessNumber,

            Image = _imageLoaderServices.ConvertToBase64(entity.EntityImage),
            EntityName = entity.Name,
            StateInitials = _addressServices.GetStateByCityName(entity.Name),

            Type = stage.Type,
        };

        var response = await _pdfGenerator.Generate(data, "JoiningTerm");
        var attachment = _attachmentServices.InsertByBytes(response, "Stage-Joining-term", "application/pdf", "TaxStage", stage.Id.ToString());

        if (attachment != null)
        {
            stage.JoiningTermUrl = attachment.Url;
            _repository.Update(stage);
        }

        return response;
    }

    public async Task<byte[]> ARTerm(TaxStageARViewModel model)
    {
        var stage = Get(model.TaxStageId);
        ThrowIfNull(stage, "A etapa do procedimento fiscal");

        var body = new CourierDataViewModel()
        {
            AdditionalInformation = model.AdditionalInformation,
            Recipient = model.Recipient,
            Devolution = model.Devolution,
            RecipientInfo = _personServices.View(stage.SubjectId.Value)
        };

        byte[] response = await _aRServices.GenerateAR(body);
        var attachment = _attachmentServices.InsertByBytes(response, "Stage-AR-term", "application/pdf", "TaxStage", stage.Id.ToString());

        if (attachment != null)
        {
            stage.ARTermUrl = attachment.Url;
            _repository.Update(stage);
        }

        return response;
    }

    public async Task<TaxStageARViewModel> CourierBaseAddress(Guid taxStageId)
    {
        var stage = Get(taxStageId);
        ThrowIfNull(stage, "A etapa do procedimento fiscal");

        TaxStageARViewModel response = TaxStageARViewModel.FromArViewModel(
            await _aRServices.CourierBaseAddress(stage.SubjectId.Value),
            taxStageId
        );
        return response;
    }

    private EntitiesViewModel Getentity()
    {
        return _entitiesServices.View();
    }

    private string GetUserName(Guid? userId)
    {
        if (!userId.HasValue)
            return null;

        var user = _middlewareClient.GetUserInfos(new List<Guid>() { userId.Value }).FirstOrDefault();
        return user?.Fullname;
    }

    private bool ProcedureExist(Guid? procedureId)
    {
        return _taxProcedureRepository.Query().Where(e => e.Id == procedureId).Any();
    }

    private bool StageExist(Guid stageId)
    {
        return _repository
                .Query()
                .Where(e => e.Status != ProcessStatus.Canceled)
                .Where(e => e.Id == stageId)
                .Any();
    }

    private TaxStage Get(Guid id)
    {
        return _repository
                .Query()
                .Include(e => e.TaxProcedure)
                .ThenInclude(e => e.Propriety)
                .Include(e => e.Subject)
                .ThenInclude(e => e.Addresses)
                .ThenInclude(e => e.Address)
                .ThenInclude(e => e.City)
                .ThenInclude(e => e.State)
                .Where(e => e.Status != ProcessStatus.Canceled)
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private TaxStage GetLastWithSubject(Guid procedureId)
    {
        return _repository
                .Query()
                .Include(e => e.Subject)
                .Include(e => e.TaxProcedure)
                .ThenInclude(e => e.Propriety)
                .Where(e => e.TaxProcedureId == procedureId)
                .Where(e => e.Status != ProcessStatus.Canceled)
                .OrderByDescending(e => e.CreatedAt)
                .FirstOrDefault();
    }

    private static TaxStage ConvertToEntity(TaxStageInsertUpdateViewModel model, Guid procedureId)
    {
        return new(model.CertificationDate, model.CutOffDate, model.ARCode, model.Number, model.Type, model.Status, procedureId, model.SubjectId, model.FineAmount, model.TrackingCode);
    }

    private static TaxStage ConvertToEntity(TaxStageReplyInsertViewModel model, Guid procedureId, Guid TaxStageId, Guid answeredById)
    {
        return new()
        {
            TaxProcedureId = procedureId,
            CertificationDate = model.CertificationDate,
            Type = model.Type,
            Status = model.Status,
            ReplyToId = TaxStageId,
            AnsweredById = answeredById,
        };
    }

    public TaxStageViewModel ConvertToViewModel(TaxStage entity, ref Dictionary<Guid?, string> answers)
    {
        var userId = entity.AnsweredById;
        if (userId.HasValue && !answers.ContainsKey(userId))
        {
            var user = _middlewareClient.GetUserInfos(new List<Guid>() { userId.Value })?.FirstOrDefault();
            answers.Add(userId, user.Fullname);
        }

        var answeredByName = (userId.HasValue && answers.ContainsKey(userId)) ? answers[userId] : null;

        var subjectName = entity?.Subject?.Name;

        return new(entity.Id, entity.CertificationDate, entity.CutOffDate, entity.ARCode, entity.Number, entity.Type, entity.Status, entity.FineAmount, entity.TrackingCode, entity.SubjectId, subjectName, entity.CreatedAt)
        {
            ForwardTermUrl = entity?.ForwardTermUrl,
            JoiningTermUrl = entity?.JoiningTermUrl,

            AnsweredById = entity.AnsweredById,
            AnsweredByName = answeredByName,
            ReplyTo = entity.ReplyToId,

            Attachments = entity
                            .Attachments?
                            .Select(annex => AttachmentServices.ConvertToViewModel(annex.Attachment))
                            .ToList(),
        };
    }

    public TaxStageViewModel ConvertToViewModel(TaxStage entity)
    {
        string answeredByName = "";
        if (entity.AnsweredById.HasValue)
        {
            var user = _middlewareClient.GetUserInfos(new List<Guid>() { entity.AnsweredById.Value })?.FirstOrDefault();
            answeredByName = user.Fullname;
        }

        var subjectName = entity?.Subject?.Name;
        return new(entity.Id, entity.CertificationDate, entity.CutOffDate, entity.ARCode, entity.Number, entity.Type, entity.Status, entity.FineAmount, entity.TrackingCode, entity.SubjectId, subjectName, entity.CreatedAt)
        {
            ForwardTermUrl = entity?.ForwardTermUrl,
            JoiningTermUrl = entity?.JoiningTermUrl,

            AnsweredById = entity.AnsweredById,
            AnsweredByName = answeredByName,
            ReplyTo = entity.ReplyToId,

            Attachments = entity
                            .Attachments?
                            .Select(annex => AttachmentServices.ConvertToViewModel(annex.Attachment))
                            .ToList(),
        };
    }

    public List<TaxStageViewModel> ConvertToViewModel(IEnumerable<TaxStage> entities)
    {
        if (entities == null || !entities.Any())
            return new();

        var dict = new Dictionary<Guid?, string>();
        return entities.Select(e => ConvertToViewModel(e, ref dict)).ToList();
    }

    private static void ThrowIfNull(object entity, string message = "entidade")
    {
        if (entity == null)
            throw new NotFoundException($"{message} não foi encontrada(ou está cancelada).");
    }

    private void ThrowExceptionIfReplyModelIsInvalid(Guid taxStageId, TaxStageReplyInsertViewModel model)
    {
        var messages = new List<string>();

        ThrowExceptionIfAttachmentNotFound(model.AttachmentIds);

        if (!StageExist(taxStageId))
            messages.Add("A etapa do procedimento fiscal não foi encontrada.");

        if (messages.Any())
            throw new NotFoundException(messages);

        var attachments = model.AttachmentIds ?? new();
        if (!attachments.Any())
            messages.Add("Pelo menos um arquivo é necessário para responder uma etapa.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private void ThrowExceptionIfModelIsInvalid(Guid? procedureId, TaxStageInsertUpdateViewModel model)
    {
        var messages = new List<string>();

        ThrowExceptionIfAttachmentNotFound(model.AttachmentIds);

        if (!ProcedureExist(procedureId) && procedureId.HasValue)
            messages.Add("Procedimento fiscal não encontrado.");

        if (!_personServices.Exists(model.SubjectId))
            messages.Add("Sujeito passivo não encontrado");

        if (messages.Any())
            throw new NotFoundException(messages);

        if (model.FineAmount.HasValue && model.FineAmount < 0)
            messages.Add("O Valor da multa não pode ser menor que zero.");

        if (!model.FineAmount.HasValue && model.Type != TaxStageType.Notice)
            messages.Add($"O valor da multa é um campo obrigatório para o tipo: {model.Type.GetDescription()}");

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private void ThrowExceptionIfAttachmentNotFound(List<Guid> attachments)
    {
        if (attachments == null)
            return;

        attachments.ForEach(id =>
        {
            if (!_attachmentServices.Exists(id))
                throw new NotFoundException("Arquivo não encontrado.");
        });
    }
}