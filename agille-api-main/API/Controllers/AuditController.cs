using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class AuditController : BaseController
{
    private readonly IAuditServices _services;

    public AuditController(IAuditServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<byte[]>> Get([FromQuery] AuditParams model)
    {
        var content = _services.ViewLog(model);
        return File(content, "text/csv");
    }
}
