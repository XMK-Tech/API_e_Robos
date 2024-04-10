using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Enums;
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
public class UnionTransfersController : BaseController
{
    private readonly IUnionTransfersServices _services;

    public UnionTransfersController(IUnionTransfersServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<IEnumerable<UnionTransfersViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] UnionTransfersParams @params)
    {
        var content = _services.View(@params, meta);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<UnionTransfersViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("dashboard")]
    public ActionResult<Result<UnionTransfersDashboard>> Get()
    {
        var content = _services.Dashboard();
        return GetSimpleResult(content);
    }

    [HttpPost]
    public ActionResult<Result<UnionTransfersViewModel>> Post([FromBody] UnionTransfersInsertUpdateViewModel model)
    {
        var content = _services.Insert(model);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}")]
    public ActionResult<Result<UnionTransfersViewModel>> Put(Guid id, [FromBody] UnionTransfersInsertUpdateViewModel model)
    {
        var content = _services.Update(model, id);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}/status")]
    public ActionResult<Result<WithOutContent>> PutStatus(Guid id, [FromQuery] UnionTransfersStatus status)
    {
        _services.ChangeStatus(status, id);
        return GetSimpleResult();
    }

    [HttpDelete("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }

    [HttpGet("report")]
    public async Task<ActionResult<Result<byte[]>>> Report([FromQuery] UnionTransferReportModel model)
    {
        byte[] content = await _services.Print(model);
        return File(content, "application/pdf");
    }
}