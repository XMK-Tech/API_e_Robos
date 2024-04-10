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
public class ServiceTypeController : BaseController
{
    private readonly ServiceTypeServices _services;

    public ServiceTypeController(ServiceTypeServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<ServiceTypeViewModel>>> Get([FromQuery] MetadataParams metadataViewModel)
    {
        var meta = metadataViewModel.ViewModelFromEntity();
        var content = _services.View(meta);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<ServiceTypeViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("person/{id}")]
    public ActionResult<Result<IEnumerable<ServiceTypeViewModel>>> GetByJuridicalPerson([FromQuery] MetadataParams metadataViewModel, Guid id)
    {
        var meta = metadataViewModel.ViewModelFromEntity();
        var content = _services.ViewByJuridicalPersonId(id, meta);
        return GetSimpleResult(content, meta);
    }

    [HttpPost]
    public ActionResult<Result<ServiceTypeViewModel>> Post([FromBody] ServiceTypeInsertUpdateViewModel model)
    {
        var content = _services.Insert(model);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}")]
    public ActionResult<Result<ServiceTypeViewModel>> Put(Guid id, [FromBody] ServiceTypeInsertUpdateViewModel model)
    {
        var content = _services.Update(model, id);
        return GetSimpleResult(content);
    }

    [HttpDelete("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}
