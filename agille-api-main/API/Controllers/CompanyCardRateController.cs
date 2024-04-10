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
public class CompanyCardRateController : BaseController
{
    private readonly CompanyCardRateServices _services;

    public CompanyCardRateController(CompanyCardRateServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<CompanyCardRateViewModel>>> Get([FromQuery] Metadata meta)
    {
        var content = _services.View(meta);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<CompanyCardRateViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("operator/{id}")]
    public ActionResult<Result<IEnumerable<CompanyCardRateViewModel>>> GetByCardOperatorId(Guid id, [FromQuery] Metadata meta)
    {
        var content = _services.ViewByCardOperatorId(id, meta);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("operator/{id}/rate-average")]
    public ActionResult<Result<CardOperatorAverageViewModel>> GetRateAverage(Guid id)
    {
        var content = _services.CardOperatorRateAverage(id);
        return GetSimpleResult(content);
    }

    [HttpGet("companies/{id}")]
    public ActionResult<Result<IEnumerable<JuridicalPersonWithOperatorRateViewModel>>> Get(Guid id, [FromQuery] JuridicalPersonParams model, [FromQuery] MetadataParams metadata)
    {
        var meta = metadata.ViewModelFromEntity();
        var content = _services.CompanyList(id, model, meta);
        return GetSimpleResult(content, meta);
    }

    [HttpPost]
    public ActionResult<Result<CompanyCardRateViewModel>> Post([FromBody] CompanyCardRateInsertUpdateViewModel model)
    {
        var content = _services.Insert(model);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}")]
    public ActionResult<Result<CompanyCardRateViewModel>> Put([FromBody] CompanyCardRateInsertUpdateViewModel model,Guid id)
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