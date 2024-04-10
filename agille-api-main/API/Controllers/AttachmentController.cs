using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly AttachmentServices _services;

        public AttachmentController(AttachmentServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public ActionResult<Result<AttachmentViewModel>> Get(Guid id)
        {
            AttachmentViewModel content = _services.View(id);
            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(_services.StatusCode, _services.ValidationMessages));

            return Ok(new Result<AttachmentViewModel>(200, content));
        }

        [HttpGet]
        public ActionResult<Result<List<AttachmentViewModel>>> Get([FromQuery] AttachmentParams model, [FromQuery] Metadata metadata)
        {

            List<AttachmentViewModel> content = _services.List(model, metadata);

            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(_services.StatusCode, _services.ValidationMessages));

            return Ok(new Result<List<AttachmentViewModel>>(200, content, metadata));
        }

        [HttpPost]
        public ActionResult<Result<AttachmentViewModel>> Post([FromForm] AttachmentInsertUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<WithOutContent>(400, ModelState.Values.Select(x => x.Errors.Select(x => x.ErrorMessage).FirstOrDefault()).ToList()));

            var responseData = _services.Insert(model);

            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(_services.StatusCode, _services.ValidationMessages));

            return Ok(new Result<AttachmentViewModel>(201, responseData));
        }

        [HttpPut("{id}")]
        public ActionResult<Result<AttachmentViewModel>> Put([FromForm] AttachmentInsertUpdateViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Result<WithOutContent>(400, ModelState.Values.Select(x => x.Errors.Select(x => x.ErrorMessage).FirstOrDefault()).ToList()));

            var responseData = _services.Update(model, id);
            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(_services.StatusCode, _services.ValidationMessages));

            return Ok(new Result<AttachmentViewModel>(200, responseData));

        }

        [HttpDelete("{id}")]
        public ActionResult<Result<WithOutContent>> Delete(Guid id)
        {

            _services.Delete(id);

            if (!_services.Valid)
                return BadRequest(new Result<WithOutContent>(_services.StatusCode, _services.ValidationMessages));

            return Ok(new Result<WithOutContent>(200));

        }
    }
}
