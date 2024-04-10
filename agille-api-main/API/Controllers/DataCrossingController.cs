using System;
using System.Collections.Generic;
using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DataCrossingController : BaseController
{
    private readonly DataCrossingServices _services;

    public DataCrossingController(DataCrossingServices DataCrossingServices)
    {
        _services = DataCrossingServices;
    }

    [HttpPost]
    public ActionResult<Result<WithOutContent>> Insert([FromBody] DataCrossingInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<DataCrossingViewModel>>> GetAll([FromQuery] Metadata meta)
    {
        var content = _services.GetAll(meta);       
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}/results")]
    public ActionResult<Result<IEnumerable<DataCrossingEntryViewModel>>> Get([FromRoute] Guid id, [FromQuery] Metadata meta)
    {
        var content = _services.GetEntries(id);        
        return GetSimpleResult(content, meta);
    }

    [HttpGet("divergencys-count")]
    public ActionResult<Result<DivergencysDataViewModel>> GetIntervalCount([FromBody] GetEntriesViewModel model, [FromQuery] Metadata meta)
    {
        var content = _services.GetDivergencyCount(model, meta);
        return GetSimpleResult(content, meta);
    }
}