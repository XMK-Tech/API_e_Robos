using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Domain.Services.Utils;
using GoogleApis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom
{
  public class AttachmentServices : Notifications, IAttachmentServices
  {
    private readonly IAttachmentRepository _repository;

    public AttachmentServices(IAttachmentRepository repository)
    {
      _repository = repository;
    }
    public List<AttachmentViewModel> List(AttachmentParams model, Metadata metadata = null)
    {
      try
      {
        if (metadata == null)
          metadata = new Metadata();

        IQueryable<Attachment> query = _repository.Query().AsQueryable();

        Expression<Func<Attachment, Object>> sort = x => x.DisplayName;

        if (String.IsNullOrEmpty(metadata.SortColumn))
        {
          sort = e => e.DisplayName;
          metadata.SortColumn = "Name";
        }

        if (model.Id != Guid.Empty)
          query = query.Where(e => e.Id == model.Id);

        if (!String.IsNullOrEmpty(model.Owner))
          query = query.Where(e => e.Owner.Equals(model.Owner));

        if (!String.IsNullOrEmpty(model.DisplayName))
          query = query.Where(e => e.DisplayName.Equals(model.DisplayName));

        if (!String.IsNullOrEmpty(model.OwnerId))
          query = query.Where(e => e.OwnerId.Equals(model.OwnerId));

        if (!String.IsNullOrEmpty(model.Type))
          query = query.Where(e => e.OwnerId.Equals(model.Type));

        List<AttachmentViewModel> attachmentViewModels = _repository.ExecuteQuery(query, metadata, sort).Select(e => ConvertToViewModel(e)).ToList();

        return attachmentViewModels;
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }

    public AttachmentViewModel InsertByBytes(byte[] bytes, string fileName, string contentType, string owner, string ownerId)
    {
        using var stream = new MemoryStream(bytes);

        var formFile = new FormFile(stream, 0, bytes.Length, fileName, fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = contentType,
        };

        System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
        {
            FileName = formFile.FileName
        };
        formFile.ContentDisposition = cd.ToString();

        return Insert(new AttachmentInsertUpdateViewModel()
        {
            Attachment = formFile,
            Owner = owner,
            OwnerId = ownerId,
        });
    }

    public AttachmentViewModel Insert(AttachmentInsertUpdateViewModel viewModel)
    {
      try
      {
        if (viewModel.Attachment == null)
        {
          ValidationMessages.Add("File not received.");
          return null;
        }

        System.Threading.Tasks.Task<GoogleApis.Models.FileUploaded> fileResponse = GoogleFileManager.UploadFile(viewModel.Attachment, Guid.NewGuid().ToString());

        if (fileResponse?.Result == null)
        {
          ValidationMessages.Add("Fail to upload the file to cloud.");
          return null;
        }

        var entity = ConvertToEntity(viewModel, fileResponse);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
      }
      catch (Exception ex)
      {
        ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
        return null;
      }
    }
    public AttachmentViewModel Update(AttachmentInsertUpdateViewModel viewModel, Guid id)
    {
      try
      {
        Attachment entity = _repository.Query().Where(e => e.Id == id).AsNoTracking().FirstOrDefault();

        if (entity == null)
        {
          ValidationMessages.Add("Attachment id not valid");
          return null;
        }

        System.Threading.Tasks.Task<GoogleApis.Models.FileUploaded> fileResponse = GoogleFileManager.UpdateFile(viewModel.Attachment, entity.DisplayName);

        if (fileResponse.Result == null)
        {
          ValidationMessages.Add("Fail to upload the file to cloud.");
          return null;
        }

        entity = ConvertToEntity(viewModel, fileResponse, entity);
        _repository.Update(entity);

        return ConvertToViewModel(entity);

      }
      catch (Exception ex)
      {
        ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
        return null;
      }
    }
    //Esse metodo só funciona quando só há um arquivo relacionado a um Owner e OwnerId
    public Attachment ViewByOwnerOwnerIdOrUrl(string owner, string ownerId, string url = null)
    {
      try
      {
        Attachment entity = null;
        if (String.IsNullOrEmpty(url))
          entity = _repository.Query().Where(e => e.Owner == owner && e.OwnerId == ownerId).AsNoTracking().FirstOrDefault();
        else
          entity = _repository.Query().Where(e => e.Url == url).AsNoTracking().FirstOrDefault();
        return entity;
      }
      catch (Exception ex)
      {
        ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
        return null;
      }
    }
    public AttachmentViewModel View(Guid id)
    {
      try
      {
        if (!_repository.Exists(id))
        {
          ValidationMessages.Add("None attachment was found ");
          return null;
        }
        return ConvertToViewModel(_repository.GetById(id));
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);

      }
    }
    public void Delete(Guid attachment_id)
    {
      try
      {
        if (!_repository.Exists(attachment_id))
        {
          ValidationMessages.Add("Attachment id not valid");
          return;
        }

        Attachment entity = _repository.Query().Where(e => e.Id == attachment_id).AsNoTracking().FirstOrDefault();
        GoogleFileManager.DeleteFiles(new List<string>() { entity.DisplayName });
        _repository.Delete(entity);
      }
      catch (Exception ex)
      {
        ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }
       
    public bool Exists(Guid? id)
    {
      return _repository.Query().Where(e => e.Id == id).Any();
    }

    public string GetFileType(Guid id)
    {
        return _repository.Query().Where(e => e.Id == id).Select(e => e.Type).FirstOrDefault();
    }

    public static List<AttachmentViewModel> ConvertToViewModel(List<Attachment> models)
    {
      if (models == null)
        return new();
            
      return models.Select(ConvertToViewModel).ToList();
    }

    public static AttachmentViewModel ConvertToViewModel(Attachment model)
    {
      if (model == null)
        return null;

      AttachmentViewModel viewModel = new AttachmentViewModel()
      {
        Id = model.Id,
        Url = model.Url,
        ExternalId = model.ExternalId,
        DisplayName = model.DisplayName,
        Type = model.Type,
        Owner = model.Owner,
        OwnerId = model.OwnerId
      };

      return viewModel;
    }
    private Attachment ConvertToEntity(AttachmentInsertUpdateViewModel viewModel, System.Threading.Tasks.Task<GoogleApis.Models.FileUploaded> fileResponse, Attachment entity = null)
    {
      if (entity == null)
      {
        return new Attachment(fileResponse.Result.FileExtension, fileResponse.Result.FilePath, fileResponse.Result.SelfLinkCloud, fileResponse.Result.FileName, fileResponse.Result.DisplayName, viewModel.Owner, viewModel.OwnerId);
      }
      else
      {
        entity.Type = fileResponse.Result.FileExtension;
        entity.Url = fileResponse.Result.FilePath;
        entity.UrlMetadata = fileResponse.Result.SelfLinkCloud;
        entity.ExternalId = fileResponse.Result.FileName;
        entity.DisplayName = fileResponse.Result.DisplayName;
        entity.Owner = viewModel.Owner;
        entity.OwnerId = viewModel.OwnerId;
      }

      return entity;
    }

  }
}
