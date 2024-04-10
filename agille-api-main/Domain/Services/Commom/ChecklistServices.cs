using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class ChecklistServices : SessionServices, IChecklistServices
{
    private readonly IChecklistRepository _reporitory;
    private readonly IChecklistAttachmentRepository _attachmentsRepository;

    private readonly AttachmentServices _attachmentServices;
    private readonly NotificationServices _notificationServices;

    public ChecklistServices(IHttpContextAccessor httpContextAccessor, IChecklistRepository reporitory, IChecklistAttachmentRepository attachmentsRepository, AttachmentServices attachmentServices, NotificationServices notificationServices)
        : base(httpContextAccessor)
    {
        _reporitory = reporitory;
        _attachmentsRepository = attachmentsRepository;

        _attachmentServices = attachmentServices;
        _notificationServices = notificationServices;
    }

    public IEnumerable<ChecklistViewModel> View(ChecklistParams @params)
    {
        var query = Filter(Query(), @params);
        return query.Select(ConvertToViewModel);
    }
    
    public ChecklistViewModel Insert(ChecklistInsertUpdateViewModel model)
    {
        var entity = ConvertToEntity(model);
        _reporitory.Insert(entity);

        return ConvertToViewModel(entity);
    }
    
    public void UpdateAttachments(ChecklistInsertUpdateAttachmentsViewModel list, Guid checklistId)
    {
        var attachmentsIds = list.Attachments;
        ValidateAttachments(attachmentsIds);

        var checklist = Get(checklistId);
        ThrowIfNull(checklist, "Checklist não encontrado.");

        var toDelete = checklist.Attachments.ToList();

        var relations = attachmentsIds.Select(id =>
        {
            return new ChecklistAttachment(checklistId, id);
        }).ToList();
        
        _attachmentsRepository.DeleteMany(toDelete);
        _attachmentsRepository.InsertMany(relations);

        checklist.Status = ChecklistStatus.Sent;
        checklist.UserId = GetCurrentSession()?.UserId;
        _reporitory.Update(checklist);
    }
    
    public ChecklistViewModel ChangeStatus(ChecklistUpdateViewModel model, Guid id)
    {
        if (model.Status == ChecklistStatus.Disapproved && string.IsNullOrEmpty(model.Justification))
            throw new BadRequestException("O Campo Justificativa é obrigatório quando os arquivos forem reprovados.");
        
        var entity = Get(id);
        ThrowIfNull(entity, "Checklist não encontrado.");

        entity.Status = model.Status;
        entity.Justification = model.Justification;

        _reporitory.Update(entity);

        if (entity.UserId.HasValue)
            PostNotification(entity.UserId.Value, model.Status, model.Justification);

        return ConvertToViewModel(entity);
    }
    
    private void PostNotification(Guid? userId, ChecklistStatus status, string justification)
    {
        if (!userId.HasValue)
            return;
            
        var statusMessage = status.GetDescription().ToLower();
        var message = status switch
        {
            ChecklistStatus.Approved => $"O checklist foi aprovado.",
            ChecklistStatus.Disapproved => $"O checklist foi reprovado. Justificativa: \"{justification}\"",
            _ => $"Status do checklist atualizado para: {statusMessage}."
        };

        _notificationServices.InsertMany(new NotificationInsertViewModel()
        {
            UserIds = new List<Guid>() { userId.Value },
            Title = $"Análise dos documentos do convênio concluída. Situação: {statusMessage}",
            Message = message,
            Link = "",
            Priority = NotificationPriority.High,
        });
    }

    private void ValidateAttachments(List<Guid> ids)
    {
        var messages = new List<string>();

        ids.ForEach(i =>
        {
            if (!_attachmentServices.Exists(i))
                messages.Add($"Arquivo(Id: {i}) não encontrado.");
        });

        if (messages.Any())
            throw new NotFoundException(messages);
    }

    private IQueryable<Checklist> Query()
    {
        return _reporitory
                .Query()
                .Include(e => e.Attachments)
                .ThenInclude(e => e.Attachment);
    }

    private Checklist Get(Guid? id)
    {
        return Query()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private static Checklist ConvertToEntity(ChecklistInsertUpdateViewModel model)
    {
        var entity = new Checklist();
        ApplyChecklistData(model, entity);
        
        return entity;
    }

    private static void ApplyChecklistData(ChecklistInsertUpdateViewModel model, Checklist entity)
    {
        entity.Status = model.Status;
        entity.Text = model.Text;
    }
    
    private static ChecklistViewModel ConvertToViewModel(Checklist entity)
    {
        return new()
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            LastUpdateAt = (entity.LastUpdateAt != DateTime.MinValue) ? entity.LastUpdateAt : entity.CreatedAt,
            Justification = entity.Justification,
            Text = entity.Text,
            Status = entity.Status,
            Attachments = entity.Attachments?.Select(e => AttachmentServices.ConvertToViewModel(e.Attachment)).ToList()
        };
    }

    private static void ThrowIfNull(object obj, string message)
    {
        if (obj == null)
            throw new NotFoundException(message);
    }

    private static IQueryable<Checklist> Filter(IQueryable<Checklist> query, ChecklistParams @params)
    {
        query = query
                .WhereIf(@params.Document, e => e.Text.ToLower().Contains(@params.Document.ToLower()))
                .WhereIf(@params.Date, e => e.CreatedAt.Date == @params.Date.Value.Date || e.LastUpdateAt.Date == @params.Date.Value.Date)
                .WhereIf(@params.StatusBackoffice, e => e.Status == @params.StatusBackoffice)
                .WhereIf(@params.StatusAuditor == ChecklistAuditorFilter.Done, e => e.Status == ChecklistStatus.Approved)
                .WhereIf(@params.StatusAuditor != null && @params.StatusAuditor == ChecklistAuditorFilter.InProgress, e => e.Status != ChecklistStatus.Approved)
                .OrderByDescending(e => e.CreatedAt);

        return query;
    }
}