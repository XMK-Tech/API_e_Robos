using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class ChecklistController : BaseController
{
    private readonly IChecklistServices _services;

    public ChecklistController(IChecklistServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<ChecklistViewModel>>> Get([FromQuery] ChecklistParams @params)
    {
        var content = _services.View(@params);
        return GetSimpleResult(content);
    }

    [HttpPut("attachments/{id}")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] ChecklistInsertUpdateAttachmentsViewModel model)
    {
        _services.UpdateAttachments(model, id);
        return GetSimpleResult();
    }

    [HttpPut("{id}/status")]
    public ActionResult<Result<WithOutContent>> PutStatus(Guid id, [FromBody] ChecklistUpdateViewModel model)
    {
        _services.ChangeStatus(model, id);
        return GetSimpleResult();
    }
}