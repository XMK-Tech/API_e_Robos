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
public class RelatedEntityController : BaseController
{
    private readonly IRelatedEntityServices _services;

    public RelatedEntityController(IRelatedEntityServices services)
    {
        _services = services;
    }

    [HttpGet]
    [EnforcePermission("agiprev-pasep-relatedentity-read")]
    public ActionResult<Result<IEnumerable<RelatedEntityViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] RelatedEntityParams @params)
    {
        var content = _services.List(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    [EnforcePermission("agiprev-pasep-relatedentity-read")]
    public ActionResult<Result<RelatedEntityViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost]
    [EnforcePermission("agiprev-pasep-relatedentity-add")]
    public ActionResult<Result<WithOutContent>> Post([FromBody] RelatedEntityInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    [EnforcePermission("agiprev-pasep-relatedentity-edit")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] RelatedEntityInsertUpdateViewModel model)
    {
        _services.Update(id, model);
        return GetSimpleResult();
    }

    [HttpDelete("{id}")]
    [EnforcePermission("agiprev-pasep-relatedentity-delete")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}