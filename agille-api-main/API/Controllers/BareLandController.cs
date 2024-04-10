using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class BareLandController : BaseController
{
    private readonly IBareLandValueServices _services;

    public BareLandController(IBareLandValueServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<BareLandValuesViewModel>> Get([FromQuery] string year)
    {
        var content = _services.GetByYear(year);
        return GetSimpleResult(content);
    }

    [HttpPut]
    public ActionResult<Result<BareLandValuesViewModel>> Put([FromQuery] string year, [FromBody] BareLandValuesViewModel model)
    {
        var content = _services.UpSert(model, year);
        return GetSimpleResult(content);
    }    
}