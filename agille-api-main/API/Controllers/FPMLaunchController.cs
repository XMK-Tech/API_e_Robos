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
public class FPMLaunchController : BaseController
{
    private readonly IFPMLaunchServices _services;

    public FPMLaunchController(IFPMLaunchServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<FPMLaunchViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] FPMLaunchParams @params)
    {
        var content = _services.List(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<FPMLaunchViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost("import-from-crawler")]
    public ActionResult<Result<WithOutContent>> Import([FromBody] AgiprevImportParams @params)
    {
        _services.ImportFromCrawler(@params);
        return GetSimpleResult();
    }
}