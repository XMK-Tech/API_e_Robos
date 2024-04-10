using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers
{
  [Route("api/v1/message-templates")]
  [ApiController]
  public class MessageTemplateController : ControllerBase
  {
    private readonly MessageTemplateServices _services;
    public MessageTemplateController(MessageTemplateServices services)
    {
      _services = services;
    }
    [HttpGet]
    public ActionResult<Result<List<MessageTemplateViewModel>>> Get([FromQuery] MessageTemplateListParams model, [FromQuery] Metadata metadata)
    {
      try
      {
        List<MessageTemplateViewModel> content = _services.List(model, metadata);

        if (!_services.Valid)
          return BadRequest(new Result<WithOutContent>(400, _services.ValidationMessages));

        return Ok(new Result<List<MessageTemplateViewModel>>(200, content));
      }
      catch (Exception ex)
      {
        return BadRequest(new Result<WithOutContent>(500, ex));
      }
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<Result<WithOutContent>> Put([FromBody] MessageTemplateUpdateViewModel model, Guid id)
    {
      try
      {
        _services.Update(model, id);

        if (!_services.Valid)
          return BadRequest(new Result<WithOutContent>(400, _services.ValidationMessages));

        return Ok(new Result<WithOutContent>(200));
      }
      catch (Exception ex)
      {
        return BadRequest(new Result<WithOutContent>(500, ex));
      }
    }
  }
}
