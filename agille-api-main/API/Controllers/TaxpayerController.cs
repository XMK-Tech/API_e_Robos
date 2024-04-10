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
public class TaxpayerController : BaseController
{
    private readonly TaxpayerServices _services;

    public TaxpayerController(TaxpayerServices taxpayerServices)
    {
        _services = taxpayerServices;
    }

    [HttpGet("{TaxpayerId}")]
    public ActionResult<Result<IEnumerable<TaxpayerViewModel>>> Get(Guid TaxpayerId)
    {
        var content = _services.View(TaxpayerId);
        return GetSimpleResult(content);
    }

    [HttpPost]
    public ActionResult<Result<TaxpayerViewModel>> Post([FromBody] InsertTaxpayerViewModel model)
    {
        var content = _services.Insert(model);
        return GetSimpleResult(content);
    }

    [HttpDelete]
    public ActionResult<Result<WithOutContent>> Delete([FromBody] InsertTaxpayerViewModel model)
    {
        _services.Delete(model);
        return GetSimpleResult();
    }
}