using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers
{
  [Route("api/v1/messages")]
  [ApiController]
  public class MessageController : ControllerBase
  {
    private readonly MessageServices _services;
    private readonly MessageTemplateServices _messageTemplateServices;
    public MessageController(MessageServices services, MessageTemplateServices messageTemplateServices)
    {
      _services = services;
      _messageTemplateServices = messageTemplateServices;
    }
    [HttpGet]
    public ActionResult<Result<List<MessageViewModel>>> Get([FromQuery] MessageListParams model, [FromQuery] Metadata metadata)
    {
      try
      {
        List<MessageViewModel> content = _services.List(model, metadata);

        if (!_services.Valid)
          return BadRequest(new Result<WithOutContent>(400, _services.ValidationMessages));

        return Ok(new Result<List<MessageViewModel>>(200, content));
      }
      catch (Exception ex)
      {
        return BadRequest(new Result<WithOutContent>(500, ex));
      }
    }

    [HttpPost]
    public ActionResult<Result<WithOutContent>> Post([FromBody] MessageInsertUpdateViewModel model)
    {
      try
      {
        _services.Insert(model);

        if (!_services.Valid)
          return BadRequest(new Result<WithOutContent>(400, _services.ValidationMessages));

        return Ok(new Result<WithOutContent>(201));
      }
      catch (Exception ex)
      {
        return BadRequest(new Result<WithOutContent>(500, ex));
      }
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<Result<WithOutContent>> Put([FromBody] MessageInsertUpdateViewModel model, Guid id)
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
    
    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
      try
      {
        _services.Delete(id);

        if (!_services.Valid)
          return BadRequest(new Result<WithOutContent>(400, _services.ValidationMessages));

        return Ok(new Result<WithOutContent>(200));
      }
      catch (Exception ex)
      {
        return BadRequest(new Result<WithOutContent>(500, ex));
      }
    }

    [HttpGet]
    [Route("send/{id}")]
    public ActionResult<Result<WithOutContent>> Send(Guid id)
    {
      try
      {
        _services.Dispacher(id);

        if (!_services.Valid)
          return BadRequest(new Result<WithOutContent>(400, _services.ValidationMessages));

        return Ok(new Result<WithOutContent>(200));
      }
      catch (Exception ex)
      {
        return BadRequest(new Result<WithOutContent>(500, ex));
      }
    }
    
    [HttpPost]
    [Route("template")]
    public ActionResult<Result<string>> Send(MessageTemplateInsertUpdateViewModel model)
    {
      try
      {
        var content = _messageTemplateServices.InsertMessegaQueue(model).ToString();

        if (!_services.Valid)
          return BadRequest(new Result<WithOutContent>(400, _services.ValidationMessages));

        return Ok(new Result<string>(200, content));
      }
      catch (Exception ex)
      {
        return BadRequest(new Result<WithOutContent>(500, ex));
      }
    }
  }
}
