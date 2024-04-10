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
public class ARController : BaseController
{
    private readonly IARServices _services;

    public ARController(IARServices services)
    {
        _services = services;
    }

    [HttpPost("{subjectId}")]
    public async Task<ActionResult<Result<byte[]>>> Post(Guid subjectId, [FromBody] ARViewModel model)
    {
        var content = await _services.GenerateAR(model, subjectId);
        return File(content, "application/pdf");
    }

    [HttpGet("address/{subjectId}")]
    public async Task<ActionResult<Result<ARViewModel>>> ARAddresses(Guid subjectId)
    {
        var content = await _services.CourierBaseAddress(subjectId);
        return GetSimpleResult(content);
    }

    [HttpPost("join-term/{subjectId}")]
    public async Task<ActionResult<Result<byte[]>>> PostJoinTerm(Guid subjectId, [FromBody] ForwardingTermInsertUpdateViewModel model)
    {
        var content = await _services.JoinTerm(model, subjectId);
        return File(content.Item1, "application/pdf");
    }
}