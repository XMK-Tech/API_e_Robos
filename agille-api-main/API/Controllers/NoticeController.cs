using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class NoticeController : BaseController
{
    private readonly NoticeServices _services;

    public NoticeController(NoticeServices noticeServices)
    {
        _services = noticeServices;
    }

    [HttpPost]
    public ActionResult<Result<string>> Post([FromBody] NoticeInsertUpdateViewModel model)
    {
        var result = _services.Insert(model);
        return GetSimpleResult(result);
    }

    [HttpPost("manual")]
    public ActionResult<Result<string>> PostManual([FromBody] NoticeManualInsertUpdateViewModel model)
    {
        var result = _services.ManualInsert(model);
        return GetSimpleResult(result);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<NoticeViewModel>> Get(Guid id)
    {
        var result = _services.View(id);
        return GetSimpleResult(result);
    }

    [HttpPost("preview")]
    public ActionResult<Result<FileContentResult>> Preview([FromBody] TemplatePreviewModel model)
    {
        var result = _services.GetPreview(model.Template);    
        return File(result, "application/pdf");
    }

    [HttpGet]
    public ActionResult<Result<List<NoticeViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] GetNoticeParamsViewModel paramsModel)
    {
        var result = _services.GetAll(paramsModel, meta);
        return GetSimpleResult(result, meta);
    }

    [HttpGet]
    [Route("person-notices")]
    public ActionResult<Result<IEnumerable<NoticeViewModel>>> GetPersonNotices([FromQuery] Metadata meta, [FromQuery] GetNoticeParamsViewModel paramsModel)
    {
        var result = _services.ViewPersonNotices(paramsModel, meta);
        return GetSimpleResult(result);
    }

    [HttpPost]
    [Route("update-view-status")]
    public ActionResult<Result<WithOutContent>> UpdateViewStatus([FromBody] List<UpdateNoticeViewdState> updateNoticeViewdStates)
    {
        _services.UpdateNoticeViewStatus(updateNoticeViewdStates);
        return GetSimpleResult();
    }

    [HttpPut]
    [Route("status")]
    public ActionResult<Result<WithOutContent>> UpdateStatus([FromBody] NoticeUpdateStatusViewModel model)
    {
        _services.UpdateStatus(model);
        return GetSimpleResult();
    }

    [HttpPut]
    [Route("{id}/return-protocol")]
    public ActionResult<Result<WithOutContent>> SetReturnProtocol(Guid id, [FromBody] ReturnProtocolInsertViewModel model)
    {
        _services.SetReturnProtocol(id, model);
        return GetSimpleResult();
    }

    [HttpGet]
    [Route("view-notification/{id}")]
    public ActionResult<Result<CompleteNoticeViewModel>> ViewNotification(Guid id)
    {
        var content = _services.ViewNotification(id);
        return GetSimpleResult(content);
    }

    [HttpPost]
    [Route("set-visible-for-taxpayers/{NoticeId}")]
    public ActionResult<Result<WithOutContent>> SetVisibleForTaxpayers(Guid NoticeId)
    {
        _services.SetNoticeVisibleForTaxpayers(NoticeId);
        return GetSimpleResult();
    }
}