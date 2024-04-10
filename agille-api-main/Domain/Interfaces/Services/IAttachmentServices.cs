using AgilleApi.Domain.ViewModel;
using System;

namespace AgilleApi.Domain.Interfaces.Services {
    public interface IAttachmentServices
    {
        bool Exists(Guid? id);
        AttachmentViewModel Insert(AttachmentInsertUpdateViewModel viewModel);
        AttachmentViewModel InsertByBytes(byte[] bytes, string fileName, string contentType, string owner, string ownerId);
        AttachmentViewModel View(Guid id);
    }
}