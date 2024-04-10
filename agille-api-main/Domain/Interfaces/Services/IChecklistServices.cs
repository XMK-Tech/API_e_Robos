using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IChecklistServices
{
    ChecklistViewModel ChangeStatus(ChecklistUpdateViewModel model, Guid id);
    ChecklistViewModel Insert(ChecklistInsertUpdateViewModel model);
    void UpdateAttachments(ChecklistInsertUpdateAttachmentsViewModel list, Guid checklistId);
    IEnumerable<ChecklistViewModel> View(ChecklistParams @params);
}