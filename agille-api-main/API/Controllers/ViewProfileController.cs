using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgilleApi.API.Controllers;

[Route("api/v1/my-profile")]
[ApiController]
[Authorize]
public class MyProfileController : BaseController
{
    private readonly MyProfileServices _services;
    
    public MyProfileController(MyProfileServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<Result<PhysicalPersonViewModel>> Get()
    {
        var content = _services.View();
        return GetSimpleResult(content);
    }
}
