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
public class CultureDeclarationController : BaseController
{
    private readonly ICultureDeclarationServices _services;

    public CultureDeclarationController(ICultureDeclarationServices services)
    {
        _services = services;
    }
    
    [HttpGet]
    public ActionResult<Result<IEnumerable<CultureDeclarationViewModel>>> Get([FromQuery] CultureDeclarationParams @params)
    {
        var content = _services.List(@params);
        return GetSimpleResult(content);
    }
        
    [HttpGet("{id}")]
    public ActionResult<Result<CultureDeclarationViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }
        
    [HttpPost]
    public ActionResult<Result<WithOutContent>> Post([FromBody] CultureDeclarationInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] CultureDeclarationInsertUpdateViewModel model)
    {
        _services.Update(id, model);
        return GetSimpleResult();
    }

    [HttpDelete("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }

    [HttpGet("report/agriculture")]
    public ActionResult<Result<byte[]>> AgricultureReport([FromQuery] ReportIntervalViewModel model)
    {
        var response = _services.GenerateAgricultureReport(model);
        return File(response.Content, response.ContentType, response.Title);
    }

    [HttpGet("report/animals")]
    public ActionResult<Result<byte[]>> AnimalsReport([FromQuery] ReportIntervalViewModel model)
    {
        var response = _services.GenerateAnimalsReport(model);
        return File(response.Content, response.ContentType, response.Title);
    }

    [HttpGet("report/fish-area")]
    public ActionResult<Result<byte[]>> FishAreaReport([FromQuery] ReportIntervalViewModel model)
    {
        var response = _services.GenerateFishFarmsReport(model);
        return File(response.Content, response.ContentType, response.Title);
    }
}