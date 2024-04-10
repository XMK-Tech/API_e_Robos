using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TelLink.API.Implemantation.Services;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class IndexController : BaseController
{
    private readonly IIndexServices _services;

    public IndexController(IIndexServices services)
    {
        _services = services;
    }

    [HttpGet]
    [EnforcePermission("agiprev-pasep-index-read")]
    public ActionResult<Result<IEnumerable<IndexViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] IndexParams @params)
    {
        var content = _services.List(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    [EnforcePermission("agiprev-pasep-index-read")]
    public ActionResult<Result<IndexViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("last-declarations")]
    [EnforcePermission("agiprev-pasep-index-read")]
    public ActionResult<Result<IEnumerable<IndexViewModel>>> Get([FromQuery] Metadata meta)
    {
        var content = _services.ListLastDeclarations(meta);
        return GetSimpleResult(content, meta);
    }

    [HttpPost]
    [EnforcePermission("agiprev-pasep-index-add")]
    public ActionResult<Result<WithOutContent>> Post([FromBody] IndexViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    [EnforcePermission("agiprev-pasep-index-edit")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] IndexViewModel model)
    {
        _services.Update(id, model);
        return GetSimpleResult();
    }
    [HttpDelete("{id}")]
    [EnforcePermission("agiprev-pasep-index-delete")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}