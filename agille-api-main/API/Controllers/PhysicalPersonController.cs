using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/physical-persons")]
[ApiController]
public class PhysicalPersonController : BaseController
{
    private readonly PhysicalPersonServices _services;

    public PhysicalPersonController(PhysicalPersonServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<List<PhysicalPersonListViewModel>>> Get([FromQuery] PhysicalPersonParams model, [FromQuery] Metadata metadata)
    {
        var content = _services.List(model, metadata);
        return GetSimpleResult(content, metadata);
    }

    [HttpGet("search")]
    public ActionResult<Result<object>> Get([FromQuery] PhysicalPersonSearch search)
    {
        var content = _services.Search(search);
        return GetSimpleResult(content);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<PhysicalPersonViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost]
    public ActionResult<Result<WithOutContent>> Post([FromBody] PhysicalPersonInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    public ActionResult<Result<WithOutContent>> Put([FromBody] PhysicalPersonInsertUpdateViewModel model, Guid id)
    {
        _services.Update(model, id);
        return GetSimpleResult();

    }

    [HttpDelete("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}