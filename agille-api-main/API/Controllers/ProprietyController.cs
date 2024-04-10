using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Entities;
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
public class ProprietyController : BaseController
{
    private readonly IProprietyServices _services;
    private readonly ICultureDeclarationServices _cultureDeclarationServices;
    private readonly IProprietySecondaryServices _proprietySecondaryServices;

    public ProprietyController(
        IProprietyServices services, 
        ICultureDeclarationServices cultureDeclarationServices, 
        IProprietySecondaryServices proprietySecondaryServices)
    {
        _services = services;
        _cultureDeclarationServices = cultureDeclarationServices;
        _proprietySecondaryServices = proprietySecondaryServices;
    }

    [HttpGet("Select")]
    public ActionResult<Result<IEnumerable<ShortProprietyViewModel>>> Select()
    {
        var content = _services.Select();
        return GetSimpleResult(content);
    }

    [HttpGet("{id}/SelectProprietaries")]
    public ActionResult<Result<IEnumerable<SelectPersonViewModel>>> SelectProprietaries(Guid id)
    {
        var content = _services.SelectProprietaries(id);
        return GetSimpleResult(content);
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<ProprietyViewModel>>> GetAll([FromQuery] MetadataParams metadataViewModel, [FromQuery] ProprietyParams @params)
    {
        var meta = metadataViewModel.ViewModelFromEntity();
        var content = _services.View(meta, @params);

        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<ProprietyViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("dashboard")]
    public ActionResult<Result<ProprietyDashboardViewModel>> Get()
    {
        var content = _services.Dashboard();
        return GetSimpleResult(content);
    }

    [HttpGet("car")]
    public ActionResult<Result<IEnumerable<TaxPayerDeclarationDashBoardViewModel>>> GetCar()
    {
        var content = _services.ViewCARData();
        return GetSimpleResult(content);
    }

    [HttpPost]
    public ActionResult<Result<ProprietyViewModel>> Post([FromBody] ProprietyInsertUpdateViewModel model)
    {
        var content = _services.Insert(model);
        return GetSimpleResult(content);
    }

    [HttpPost("csv")]
    public ActionResult<Result<CsvResponseViewModel>> Post([FromBody] CsvInsertViewModel model)
    {
        var content = _services.InsertCSV(model);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}")]
    public ActionResult<Result<ProprietyViewModel>> Update([FromBody] ProprietyInsertUpdateViewModel model, Guid id)
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

    [HttpPut("{proprietyId}/culture-declarations")]
    public ActionResult<Result<WithOutContent>> PutMany(Guid proprietyId, [FromBody] ProprietyDeclarationsViewModel model)
    {
        _cultureDeclarationServices.UpdateProprietyDeclarations(proprietyId, model.Year, model.Declarations);
        return GetSimpleResult();
    }

    [HttpGet("bareland-report")]
    public ActionResult<Result<byte[]>> BareLandReport([FromQuery] ProprietyAreaReportFilterViewModel model)
    {
        var content = _proprietySecondaryServices.AreaReport(model);
        return FileResult(content);
    }
}