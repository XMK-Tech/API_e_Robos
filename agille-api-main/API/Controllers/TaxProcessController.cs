using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TaxProcessController : BaseController
{
    private readonly ITaxProcessServices _services;

    public TaxProcessController(ITaxProcessServices services)
    {
        _services = services;
    }

    [HttpPost]
    public async Task<ActionResult<Result<byte[]>>> Get([FromBody] TaxProcessInsertUpdateViewModel model)
    {
        var content = await _services.Insert(model);
        return File(content, "application/pdf");
    }
}