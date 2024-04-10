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
public class CultureTypeController : BaseController
{
    private readonly ICultureTypeServices _services;

    public CultureTypeController(ICultureTypeServices services)
    {
        _services = services;
    }
    
    [HttpGet]
    public ActionResult<Result<IEnumerable<CultureTypeViewModel>>> Get([FromQuery] CultureTypeParams @params)
    {
        var content = _services.List(@params);
        return GetSimpleResult(content);
    }
        
    [HttpGet("{id}")]
    public ActionResult<Result<CultureTypeViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }
        
    [HttpPost]
    public ActionResult<Result<WithOutContent>> Post([FromBody] CultureTypeInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }
        
    [HttpPut("{id}")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] CultureTypeInsertUpdateViewModel model)
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

    [HttpPut("check-state")]
    public ActionResult<Result<WithOutContent>> CheckState([FromBody] List<CultureTypeUpdateCheckStateViewModel> models)
    {
        _services.UpdateCheckState(models);
        return GetSimpleResult();
    }
}