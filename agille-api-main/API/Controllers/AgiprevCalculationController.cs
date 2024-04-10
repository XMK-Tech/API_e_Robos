using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class AgiprevCalculationController : BaseController
{
    private readonly IAgiprevCalculationServices _services;
    private readonly IAgiprevCalculationMonthServices _servicesMonth;

    public AgiprevCalculationController(IAgiprevCalculationServices services, IAgiprevCalculationMonthServices servicesMonth)
    {
        _services = services;
        _servicesMonth = servicesMonth;
    }

    [HttpGet("{year}")]
    public ActionResult<Result<byte[]>> Get(string year)
    {
        var content = _services.Calculate(year);
        return File(content.Content, content.ContentType, content.Title);
    }
    [HttpGet("{year}/{month}")]
    public ActionResult<Result<byte[]>> Get(string year, int month)
    {
        var content = _servicesMonth.Calculate(year, month);
        return File(content.Content, content.ContentType, content.Title);
    }
}