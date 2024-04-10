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
    [Route("api/v1/statuses")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly StatusServices _services;

        public StatusController(StatusServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<Result<List<StatusViewModel>>> Get([FromQuery] StatusParams model, [FromQuery] MetadataParams metadataViewModel)
        {
            Metadata metadata = metadataViewModel.ViewModelFromEntity();
            List<StatusViewModel> content = _services.List(model, metadata);
            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(404, _services.ValidationMessages));

            return Ok(new Result<List<StatusViewModel>>(200, content, metadata));

        }
    }
}
