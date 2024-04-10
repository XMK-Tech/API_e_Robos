using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgilleApi.API.Controllers;

public abstract class BaseController : ControllerBase
{
    [NonAction]
    public ActionResult GetResult<T>(INotifications service, T content, Metadata meta = null) where T : class
    {
        if (service.Valid)
            return Ok(Create<T>(service.StatusCode, content, meta));
        return CreateErrorResult(service);
    }

    [NonAction]
    public Result<WithOutContent> GetSimpleResult()
    {
        return GetSimpleResult(new WithOutContent());
    }

    public Result<T> GetSimpleResult<T>(T content, Metadata meta = null) where T : class
    {
        return new Result<T>(200, content, meta);
    }

    [NonAction]
    public ActionResult GetResult(INotifications service)
    {
        if (service.Valid)
            return Ok(Create<WithOutContent>(service.StatusCode, null));
        return CreateErrorResult(service);
    }

    [NonAction]
    public ActionResult<Result<byte[]>> FileResult(ReportResponseViewModel content)
    {
        return File(content.Content, content.ContentType, content.Title);
    }

    private ActionResult CreateErrorResult(INotifications service)
    {
        Result<WithOutContent> value = new Result<WithOutContent>(service.StatusCode);

        if (service.StatusCode == 404)
            return NotFound(value);
        
        if (service.StatusCode == 401)
            return Unauthorized(value);
        
        if (service.StatusCode == 403)
            return Forbid();
        
        return BadRequest(value);
    }

    private static Result<T> Create<T>(int statusCode, T content, Metadata meta = null) where T : class
    {
        return new Result<T>(statusCode, content, meta);
    }
}