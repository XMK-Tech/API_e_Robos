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
public class ProprietyCattleController : BaseController
{
    private readonly IProprietyCattleServices _services;

    public ProprietyCattleController(IProprietyCattleServices services)
    {
        _services = services;
    }

    [HttpGet("{id}")]
    public ActionResult<Result<IEnumerable<ProprietyCattleViewModel>>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPut]
    public ActionResult<Result<WithOutContent>> Put([FromBody] CattleManyViewModel models)
    {
        _services.Upsert(models);
        return GetSimpleResult();
    }
}
