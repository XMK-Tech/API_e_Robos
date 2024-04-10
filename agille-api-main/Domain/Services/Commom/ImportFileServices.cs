using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Domain.Services.Commom;

public class ImportFileServices
{
    private readonly IImportFileRepository _repository;
    private readonly AttachmentServices _attachmentServices;
    private readonly TransactionEntryServices _transactionEntryServices;
    private readonly ManualEntryServices _manualEntryServices;
    private readonly INotificationServices _notificationServices;
    private readonly ISessionServices _sessionServices;

    public ImportFileServices(IImportFileRepository repository, TransactionEntryServices transactionEntryServices, AttachmentServices attachmentServices, ManualEntryServices manualEntryServices, INotificationServices notificationServices, ISessionServices sessionServices)
    {
        _repository = repository;
        _transactionEntryServices = transactionEntryServices;
        _attachmentServices = attachmentServices;
        _manualEntryServices = manualEntryServices;
        _notificationServices = notificationServices;
        _sessionServices = sessionServices;
    }


    private ImportFile GetById(Guid id) {
        return _repository.Query()
        .Include(e => e.Attachment)
        .Include(e => e.ManualFile)
        .FirstOrDefault(e => e.Id == id);
    }
    public void UploadManualFile(UploadManualFileViewModel model) {
        var importFile = GetById(model.Id);
        importFile.ManualFileId = model.AttachmentId;
        importFile.Status = ImportStatus.WaitingForValidation;
        //TODO: Add parsing logic
        _repository.Update(importFile);
    }

    public void ApproveFile(Guid id) {
        var importFile = GetById(id);
        importFile.Status = ImportStatus.Done;
        _repository.Update(importFile);
        _manualEntryServices.ProcessFile(importFile);
    }

    public void RejectFile(Guid id, RejectFileViewModel model) {
        var importFile = GetById(id);
        importFile.Status = ImportStatus.RejectedByValidator;
        importFile.RejectReason = model.Reason;
        _repository.Update(importFile);
    }

    public void SetDownloaded(Guid id) {
        var importFile = GetById(id);
        importFile.Status = ImportStatus.Typing;
        _repository.Update(importFile);
    }

    public void ApproveReplacement(Guid id)
    {
        var attachmentId = GetAttachmentId(id);

        if (!attachmentId.HasValue)
            return;

        Insert(new() { AttachmentId = attachmentId.Value }, true);
    }

    public void RejectReplacement(Guid id)
    {
        var entity = _repository
                        .Query()
                        .FirstOrDefault(e => e.Id == id);

        SetStatus(entity, ImportStatus.DeniedForDuplicity);
    }

    public void Insert(ImportFileInsertUpdateViewModel model, bool isReplacement = false)
    {
        ValidateAttachment(model.AttachmentId, isReplacement);

        var status = model.Type == ImportType.Transactions || model.IsSimplified ? ImportStatus.Done : ImportStatus.WaitingForDownload;

        isReplacement = isReplacement || IsReplacement(model.AttachmentId);

        var entity = (isReplacement) ? GetImport(model.AttachmentId) : new(model.Type, status, model.IsSimplified, model.AttachmentId);

        if (entity.IsSimplified) 
            entity.ManualFileId = model.AttachmentId;

        if (isReplacement)
            entity.Status = ImportStatus.ApprovedReplacement;

        using var transaction = _repository.Transaction().BeginTransaction();

        if(!isReplacement)
            _repository.Insert(entity);

        try
        {
            if (entity.Type == ImportType.Transactions)
                _transactionEntryServices.ProcessFile(entity);
            else if (entity.IsSimplified)
                _manualEntryServices.ProcessFile(entity);

            transaction.Commit();
        }
        catch(DuplicateCancellationException ex)
        {
            /**
             * This catch handles the situation where the file contains a competence already inserted in the database, so the import is interrupted 
             *                                      to wait for the user's validation to overwrite the data.
             */
            transaction.Commit();

            _notificationServices.InsertMany(new NotificationInsertViewModel()
            {
                UserIds = new List<Guid>() { _sessionServices.GetCurrentSession().UserId },
                Link = "",
                Message = ex.Message,
                Title = "Importação interrompida",
                Priority = NotificationPriority.High
            });

            throw ex;
        }
        catch
        {
            transaction.Rollback();
            
            _notificationServices.InsertMany(new NotificationInsertViewModel()
            {
                UserIds = new List<Guid>() { _sessionServices.GetCurrentSession().UserId },
                Link = "",
                Message = "Houve um erro na importação do arquivo. Confira o formato enviado e tente novamente.",
                Title = "Falha na importação do arquivo realizada",
                Priority = NotificationPriority.High
            });

            throw new BadRequestException("Houve um erro na importação do arquivo. Confira o formato enviado e tente novamente.");
        }

        _notificationServices.InsertMany(new NotificationInsertViewModel() {
            UserIds = new List<Guid>() { _sessionServices.GetCurrentSession().UserId },
            Link = "auditor/importacao/status-importacao",
            Message = "Clique para verificar",
            Title = "Importação de arquivo realizada com sucesso",
            Priority = NotificationPriority.Normal
        });
    }

    public void SetStatus(ImportFile file, ImportStatus status)
    {
        SetStatus(new List<ImportFile>() { file }, status);
    }

    public void SetStatus(List<ImportFile> files, ImportStatus status)
    {
        if (files == null)
            return;

        files.ForEach(e => e.Status = status);
        _repository.UpdateMany(files);
    }

    private bool IsReplacement(Guid attachmentId)
    {
        return AttachmentQuery(attachmentId, ImportStatus.ApprovedReplacement).Any();
    }

    private Guid? GetAttachmentId(Guid? id)
    {
        return _repository.Query().Where(e => e.Id == id).Select(e => e.AttachmentId).FirstOrDefault();
    }

    private ImportFile GetImport(Guid attachmentId)
    {
        return AttachmentQuery(attachmentId).FirstOrDefault();
    }

    private void ValidateAttachment(Guid attachmentId, bool isReplacement = false)
    {
        var exist = _attachmentServices.Exists(attachmentId);
        if (!exist)
            throw new NotFoundException("Arquivo não encontrado.");

        var usedFile = AttachmentQuery(attachmentId).Where(e => e.Status != ImportStatus.ApprovedReplacement).Any();
        if (usedFile && !isReplacement)
            throw new BadRequestException("Esse arquivo já teve seu processo de importação iniciado.");
    }

    private IQueryable<ImportFile> AttachmentQuery(Guid attachmentId, ImportStatus? status = null)
    {
        return _repository
                    .Query()
                    .Where(e => e.AttachmentId == attachmentId)
                    .WhereIf(status, e => e.Status == status);
    }

    public IEnumerable<ImportFileViewModel> GetAll(Metadata meta, ImportFileParams @params)
    {
        var query = _repository.Query()
                    .Include(i => i.Attachment)
                    .Include(i => i.ManualFile)
                    .WhereIf(@params.Status, e => e.Status == @params.Status)
                    .WhereIf(@params.Type, e => e.Type == @params.Type)
                    .WhereIf(@params.Reason, e => EF.Functions.Collate(e.RejectReason, "SQL_Latin1_General_CP1_CI_AI").Contains(EF.Functions.Collate(@params.Reason, "SQL_Latin1_General_CP1_CI_AI")))
                    .OrderByDescending(e => e.CreatedAt);

        return _repository
            .ExecuteQuery(query,meta)
            .Select(ConvertToViewModel);
    }

    public IEnumerable<ImportFileViewModel> GetAll(Metadata meta, DateTime startDate, DateTime endDate)
    {
        var query = _repository.Query()
                    .Include(i => i.Attachment)
                    .Include(i => i.ManualFile)
                    .Where(e => e.CreatedAt >= startDate && e.CreatedAt <= endDate)
                    .OrderByDescending(e => e.CreatedAt);

        return _repository
            .ExecuteQuery(query,meta)
            .Select(ConvertToViewModel);
    }

    public IEnumerable<ImportEntryViewModel> GetEntries(GetEntriesViewModel model, Metadata meta)
    {
        var query = _repository.Query()
                    .Include(i => i.Attachment)
                    .Include(i => i.TransactionEntries)
                    .Include(i => i.InvoiceEntries)
                    .Where(i => i.TransactionEntries.Any(
                        e => e.ReferenceDate >= model.StartingReference && e.ReferenceDate <= model.EndingReference
                    ) || i.InvoiceEntries.Any(
                        e => e.ReferenceDate >= model.StartingReference && e.ReferenceDate <= model.EndingReference
                    ));
        return _repository
            .ExecuteQuery(query, meta)
            .Select(i => ConvertToEntryViewModel(i, model));

    }

    public ImportsDataViewModel GetImportsCount(GetEntriesViewModel model, Metadata meta)
    {
        if (model.StartingReference > model.EndingReference)
            throw new BadRequestException("A data final não pode ser anterior a data inicial!");

        var entries = GetAll(meta, model.StartingReference, model.EndingReference).OrderBy(e => e.CreatedAt);
        var entriesGroups = entries.GroupBy(e => new { e.CreatedAt.Year, e.CreatedAt.Month });

        List<ImportCountViewModel> groupsData = new List<ImportCountViewModel>();
        foreach (var group in entriesGroups)
        {
            var key = group.Key;
            var monthName = group.FirstOrDefault()?.CreatedAt.ToString(@"MMMM", new CultureInfo("PT-pt"));
            groupsData.Add(new ImportCountViewModel(group.Count(), monthName, key.Year.ToString(), key.Month));
        }

        return new ImportsDataViewModel(model.StartingReference, model.EndingReference, entries.Count(), groupsData);
    }

    private static ImportEntryViewModel ConvertToEntryViewModel(ImportFile i, GetEntriesViewModel model)
    {
        return new ImportEntryViewModel()
        {
            Type = i.Type,
            File = i.Attachment?.DisplayName,
            Total = i.TransactionEntries
            .Where(e => e.ReferenceDate >= model.StartingReference && e.ReferenceDate <= model.EndingReference).Count() + 
            i.InvoiceEntries.Where(e => e.ReferenceDate >= model.StartingReference && e.ReferenceDate <= model.EndingReference).Count()
        };
    }

    private static ImportFileViewModel ConvertToViewModel(ImportFile i)
    {
        return new ImportFileViewModel()
        {
            Attachment = ConvertAttachment(i.Attachment),
            ManualFile = ConvertAttachment(i.ManualFile),
            Id = i.Id,
            Type = i.Type,
            Status = i.Status,
            Reason = i.RejectReason,
            IsSimplified = i.IsSimplified,
            CreatedAt = i.CreatedAt
        };
    }

    private static AttachmentViewModel ConvertAttachment(Attachment attachment)
    {
        return attachment != null ? new AttachmentViewModel()
        {
            DisplayName = attachment.DisplayName,
            Id = attachment.Id,
            Owner = attachment.Owner,
            OwnerId = attachment.OwnerId,
            Type = attachment.Type,
            Url = attachment.Url
        } : null;
    }
}