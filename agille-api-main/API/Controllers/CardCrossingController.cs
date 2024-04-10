using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
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
public class CardCrossingController : BaseController
{
    private readonly ICardCrossingServices _services;

    public CardCrossingController(ICardCrossingServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<CardCrossingViewModel>>> Get([FromQuery] Metadata meta)
    {
        var content = _services.ViewAll(meta);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<CardCrossingViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost("interval")]
    public ActionResult<Result<SimpleCardCrossingReportViewModel>> Post([FromBody] CardCrossingInsertIntervalViewModel interval)
    {
        var content = _services.IntervalCreate(interval);
        return GetSimpleResult(content);
    }

    [HttpPost("month")]
    public ActionResult<Result<SimpleCardCrossingReportViewModel>> Post([FromBody] CardCrossingMonthInsertViewModel model)
    {
        var content = _services.MonthCreate(model);
        return GetSimpleResult(content);
    }
}