using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class ITRDeclarationController : BaseController
{
    private readonly IITRDeclarationServices _services;

    public ITRDeclarationController(IITRDeclarationServices services)
    {
        _services = services;
    }

    [HttpGet("{procedureId}")]
    public ActionResult<Result<ITRDeclarationViewModel>> Get(Guid procedureId)
    {
        var content = _services.GetITRDeclaration(procedureId);
        return GetSimpleResult(content);
    }
}