using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgilleApi.API.Controllers;


[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TaxStageController : BaseController
{
    private readonly ITaxStageServices _services;
    
    public TaxStageController(ITaxStageServices taxStageServices)
    {
        _services = taxStageServices;
    }

    [HttpGet("{id}")]
    public ActionResult<Result<TaxStageViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost("{taxProcedureId}")]
    public ActionResult<Result<WithOutContent>> Post([FromBody] TaxStageInsertUpdateViewModel model, Guid taxProcedureId)
    {
        _services.Insert(taxProcedureId, model);
        return GetSimpleResult();
    }

    [HttpPost("{id}/reply")]
    public ActionResult<Result<WithOutContent>> Post([FromBody] TaxStageReplyInsertViewModel model, Guid id)
    {
        _services.InsertReply(id, model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    public ActionResult<Result<WithOutContent>> Put([FromBody] TaxStageInsertUpdateViewModel model, Guid id)
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

    [HttpPost("forward-term")]
    public async Task<ActionResult<Result<byte[]>>> ForwardTerm([FromBody] TaxStageForwardingTermViewModel model)
    {
        var content = await _services.ForwardTerm(model);
        return File(content, "application/pdf");
    }

    [HttpPost("join-term")]
    public async Task<ActionResult<Result<byte[]>>> JoinTerm([FromBody] TaxStageJoinTermViewModel model)
    {
        var content = await _services.JoinTerm(model);
        return File(content, "application/pdf");
    }

    [HttpPost("ar-term")]
    public async Task<ActionResult<Result<byte[]>>> ARTerm([FromBody] TaxStageARViewModel model)
    {
        var content = await _services.ARTerm(model);
        return File(content, "application/pdf");
    }

    [HttpGet("ar-term/address/{id}")]
    public async Task<ActionResult<Result<TaxStageARViewModel>>> ARAddresses(Guid id)
    {
        var content = await _services.CourierBaseAddress(id);
        return GetSimpleResult(content);
    }
}