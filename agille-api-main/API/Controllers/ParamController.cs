using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.API.Controllers
{
    [Route("api/v1/params")]
    [ApiController]
    public class ParamController : ControllerBase
    {
        private readonly ParamServices _services;

        public ParamController(ParamServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<Result<List<ParamViewModel>>> Get([FromQuery] ParamViewModel model, [FromQuery] MetadataParams metadataViewModel)
        {
            Metadata metadata = metadataViewModel.ViewModelFromEntity();
            List<ParamViewModel> content = _services.List(model, metadata);
            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(404, _services.ValidationMessages));

            return Ok(new Result<List<ParamViewModel>>(200, content, metadata));

        }
        [HttpPost]
        public ActionResult<Result<WithOutContent>> Post([FromBody] ParamInsertViewModel model)
        {

            _services.Insert(model);
            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(404, _services.ValidationMessages));

            return Ok(new Result<WithOutContent>(201));

        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Result<WithOutContent>> Put([FromBody] ParamInsertViewModel model, Guid id)
        {

            _services.Update(model, id);
            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(404, _services.ValidationMessages));

            return Ok(new Result<WithOutContent>(200));

        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Result<WithOutContent>> Delete(Guid id)
        {
            _services.Delete(id);
            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(404, _services.ValidationMessages));
            return Ok(new Result<WithOutContent>(200));

        }
    }
}
