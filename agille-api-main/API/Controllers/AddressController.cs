using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AddressController : BaseController
{
    private readonly AddressServices _services;

    public AddressController(AddressServices services)
    {
      _services = services;
    }

    [HttpGet]
    public ActionResult<Result<List<AddressViewModel>>> Get([FromQuery] AddressParams model, [FromQuery] Metadata metadata)
    {
        var content = _services.List(model, metadata);
        return GetSimpleResult(content, metadata);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<AddressViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost]
    public ActionResult<Result<AddressViewModel>> Post([FromBody] AddressInsertUpdateViewModel model)
    {
        var content = _services.Insert(model);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}")]
    public ActionResult<Result<AddressViewModel>> Put([FromBody] AddressInsertUpdateViewModel model, Guid id)
    {
        var content = _services.Update(model, id);
        return GetSimpleResult(content);

    }

    [HttpDelete("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}