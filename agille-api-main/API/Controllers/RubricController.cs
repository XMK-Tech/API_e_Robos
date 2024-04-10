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
public class RubricController : BaseController
{
    private readonly IRubricServices _services;

    public RubricController(IRubricServices services)
    {
        _services = services;
    }

    [HttpGet]
    [EnforcePermission("agiprev-pasep-rubric-read")]
    public ActionResult<Result<IEnumerable<RubricViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] RubricParams @params)
    {
        var content = _services.List(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("accounts/{rubricId}")]
    public ActionResult<Result<IEnumerable<RubricAccountViewModel>>> Get(Guid rubricId, [FromQuery] Metadata meta)
    {
        var content = _services.ListAccounts(rubricId, meta);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    [EnforcePermission("agiprev-pasep-rubric-read")]
    public ActionResult<Result<RubricViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost]
    [EnforcePermission("agiprev-pasep-rubric-add")]
    public ActionResult<Result<WithOutContent>> Post([FromBody] RubricInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    [EnforcePermission("agiprev-pasep-rubric-edit")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] RubricInsertUpdateViewModel model)
    {
        _services.Update(id, model);
        return GetSimpleResult();
    }
    [HttpDelete("{id}")]
    [EnforcePermission("agiprev-pasep-rubric-delete")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
    [HttpDelete("accounts/{rubricAccountId}")]
    [EnforcePermission("agiprev-pasep-rubric-delete")]
    public ActionResult<Result<WithOutContent>> DeleteAccount(Guid rubricAccountId)
    {
        _services.DeleteAccount(rubricAccountId);
        return GetSimpleResult();
    }
}