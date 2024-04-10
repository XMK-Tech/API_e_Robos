using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class EntitiesController : BaseController
{
    private readonly IEntitiesServices _services;

    public EntitiesController(IEntitiesServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<EntitiesViewModel>> Get()
    {
        var content = _services.View();
        return GetSimpleResult(content);
    }

    [HttpPatch]
    public ActionResult<Result<WithOutContent>> Patch([FromBody] EntitiesViewModel model)
    {
        _services.Patch(model);
        return GetSimpleResult();
    }
}