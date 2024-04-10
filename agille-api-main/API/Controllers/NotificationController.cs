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
public class NotificationController : BaseController
{
    private readonly NotificationServices _services;

    public NotificationController(NotificationServices services)
    {
        _services = services;
    }

    [HttpGet("{id}")]
    public ActionResult<Result<NotificationViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<NotificationViewModel>>> Get([FromQuery] Metadata meta)
    {
        var content = _services.SessionView(meta);
        return GetSimpleResult(content, meta);
    }
}