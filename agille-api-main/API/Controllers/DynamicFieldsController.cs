using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/dynamic-fields-options")]
[ApiController]
public class DynamicFieldsController : ControllerBase
{
    private readonly DynamicFieldsServices _services;

    public DynamicFieldsController(DynamicFieldsServices services)
    {
        _services = services;
    }
    
    [HttpGet]
    public ActionResult<Result<List<FieldViewModelResult>>> Get()
    {
        List<FieldViewModelResult> content = _services.List();
        if (!_services.Valid)
            return Ok(new Result<WithOutContent>(_services.StatusCode, _services.ValidationMessages));
        return Ok(new Result<List<FieldViewModelResult>>(200, content));
    }
}