using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AgilleApi.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class NoticeTemplateController : BaseController
{
    private readonly NoticeTemplateServices _services;

    public NoticeTemplateController(NoticeTemplateServices services)
    {
      _services = services;
    }

    [HttpGet]
    public ActionResult<Result<List<NoticeTemplateViewModel>>> Get([FromQuery] Metadata metadata, [FromQuery] NoticeTemplateParams @params)
    {
        var result = _services.GetAll(metadata, @params);
        return GetSimpleResult(result, metadata);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<NoticeTemplateViewModel>> GetById(Guid id)
    {
        var result = _services.View(id);
        return GetSimpleResult(result);
    }

    [HttpGet("{id}/fields")]
    public ActionResult<Result<List<string>>> GetFields(Guid id, [FromQuery] bool allFields = false)
    {
        var result = _services.GetFields(id, allFields);
        return GetSimpleResult(result);
    }

    [HttpPost]
    public ActionResult<Result<NoticeTemplateViewModel>> Post([FromBody] NoticeTemplateInsertUpdateViewModel viewModel)
    {
        var content = _services.Insert(viewModel);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}")]
    public ActionResult<Result<NoticeTemplateViewModel>> Put([FromBody] NoticeTemplateInsertUpdateViewModel viewModel, Guid id)
    {
        var content = _services.Update(viewModel, id);
        return GetSimpleResult(content);
    }

    [HttpDelete("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}