using System;
using System.Collections.Generic;
using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class ImportFileController : BaseController
{
    private readonly ImportFileServices _services;

    public ImportFileController(ImportFileServices importFileServices)
    {
        _services = importFileServices;
    }

    [HttpPost]
    public ActionResult<Result<WithOutContent>> Insert([FromBody] ImportFileInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPost("approve/{id}")]
    public ActionResult<Result<WithOutContent>> Approve(Guid id)
    {
        _services.ApproveFile(id);
        return GetSimpleResult();
    }

    [HttpPost("download/{id}")]
    public ActionResult<Result<WithOutContent>> Download(Guid id)
    {
        _services.SetDownloaded(id);
        return GetSimpleResult();
    }

    [HttpPost("reject/{id}")]
    public ActionResult<Result<WithOutContent>> Reject([FromRoute] Guid id, [FromBody] RejectFileViewModel model)
    {
        _services.RejectFile(id, model);
        return GetSimpleResult();
    }

    [HttpPost("approve-replacement/{id}")]
    public ActionResult<Result<WithOutContent>> ApproveReplacement(Guid id)
    {
        _services.ApproveReplacement(id);
        return GetSimpleResult();
    }

    [HttpPost("reject-replacement/{id}")]
    public ActionResult<Result<WithOutContent>> RejectReplacement(Guid id)
    {
        _services.RejectReplacement(id);
        return GetSimpleResult();
    }

    [HttpPost("manual-upload")]
    public ActionResult<Result<WithOutContent>> UploadManualFile([FromBody] UploadManualFileViewModel model)
    {
        _services.UploadManualFile(model);
        return GetSimpleResult();
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<ImportFileViewModel>>> GetAll([FromQuery] Metadata meta, [FromQuery] ImportFileParams @params)
    {
        var content = _services.GetAll(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("entries")]
    public ActionResult<Result<IEnumerable<ImportEntryViewModel>>> GetEntries([FromQuery] GetEntriesViewModel model, [FromQuery] Metadata meta) 
    {
        var content = _services.GetEntries(model, meta);
        return GetSimpleResult(content, meta);
    }
    
    [HttpGet("imports-count")]
    public ActionResult<Result<ImportsDataViewModel>> GetIntervalCount([FromBody] GetEntriesViewModel model, [FromQuery] Metadata meta)
    {
        var content = _services.GetImportsCount(model, meta);
        return GetSimpleResult(content, meta);
    }
}