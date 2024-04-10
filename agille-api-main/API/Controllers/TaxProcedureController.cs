using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TaxProcedureController : BaseController
{
    private readonly ITaxProcedureServices _services;

    public TaxProcedureController(ITaxProcedureServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<TaxProcedureViewModel>>> GetAll([FromQuery] MetadataParams metadataViewModel, [FromQuery] TaxProcedureParams @params)
    {
        var meta = metadataViewModel.ViewModelFromEntity();
        var content = _services.GetAll(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<TaxProcedureViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("dashboard")]
    public ActionResult<Result<TaxProcedureDashboard>> Dashboard()
    {
        var content = _services.Dashboard();
        return GetSimpleResult(content);
    }

    [HttpPost]
    public ActionResult<Result<TaxProcedureViewModel>> Post([FromBody] TaxProcedureInsertUpdateViewModelViewModel model)
    {
        var content = _services.Insert(model);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}")]
    public ActionResult<Result<TaxProcedureViewModel>> Put([FromBody] TaxProcedureInsertUpdateViewModelViewModel model, Guid id)
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

    [HttpGet("report")]
    public async Task<ActionResult<Result<byte[]>>> Report([FromQuery] TaxProcedureReportModel model)
    {
        byte[] content = await _services.Print(model);
        return File(content, "application/pdf");
    }

    [HttpGet("log-report")]
    public async Task<ActionResult<Result<byte[]>>> LogReport([FromQuery] TaxProcedureReportLogModel model)
    {
        byte[] content = await _services.PrintLog(model);
        return File(content, "application/pdf");
    }
}