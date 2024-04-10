using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TaxPayerDeclarationController : BaseController
{
    private readonly ITaxPayerDeclarationServices _services;

    public TaxPayerDeclarationController(ITaxPayerDeclarationServices services)
    {
        _services = services;
    }

    [HttpGet("list")]
    public ActionResult<Result<IEnumerable<TaxPayerDeclarationViewModel>>> List([FromQuery] Metadata meta, [FromQuery] TaxPayerDeclarationParams @params)
    {
        var content = _services.List(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet]
    public ActionResult<Result<TaxPayerDeclarationViewModel>> Get([FromQuery] TaxPayerDeclarationParams @params)
    {
        var content = _services.GetDeclaration(@params);
        return GetSimpleResult(content);
    }

    [HttpPost("csv")]
    public ActionResult<Result<CsvResponseViewModel>> Post([FromBody] CsvInsertViewModel model)
    {
        var content = _services.Import(model);
        return GetSimpleResult(content);
    }

    [HttpPut]
    public ActionResult<Result<TaxPayerDeclarationViewModel>> Put([FromQuery] TaxPayerDeclarationParams @params, [FromBody] TaxPayerDeclarationViewModel model)
    {
        var content = _services.Upsert(model, @params);
        return GetSimpleResult(content);
    }
}