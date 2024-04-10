using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers
{
    [Route("api/v1/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileServices _service;

        public ProfileController(ProfileServices service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Result<List<ProfileGetListViewModelResult>>> Get(
            [FromQuery] ProfileViewListParams model,
            [FromQuery] Metadata metadata
            )
        {
            List<ProfileGetListViewModelResult> content = _service.List(model, metadata);
            if (!_service.Valid)
                return BadRequest(new Result<WithOutContent>(404, _service.ValidationMessages));
            return Ok(new Result<List<ProfileGetListViewModelResult>>(200, content, metadata));

        }
        [HttpGet]
        [Route("search")]
        public ActionResult<Result<List<ProfileSearchViewModel>>> Get(
            [FromQuery] ProfileSearchParam model
            )
        {
            List<ProfileSearchViewModel> content = _service.Search(model);
            if (!_service.Valid)
                return BadRequest(new Result<WithOutContent>(404, _service.ValidationMessages));
            return Ok(new Result<List<ProfileSearchViewModel>>(200, content));

        }
        [HttpGet]
        [Route("select")]
        public ActionResult<Result<List<ProfileSearchViewModel>>> Get()
        {
            List<ProfileSearchViewModel> content = _service.Select();
            if (!_service.Valid)
                return BadRequest(new Result<WithOutContent>(404, _service.ValidationMessages));
            return Ok(new Result<List<ProfileSearchViewModel>>(200, content));

        }

        [HttpGet("{id}")]
        public ActionResult<Result<ProfileViewProfileModel>> Get(Guid id)
        {
            ProfileViewProfileModel content = _service.View(id);
            if (!_service.Valid)
            {
                return BadRequest(new Result<WithOutContent>(404, _service.ValidationMessages));
            }
            return Ok(new Result<ProfileViewProfileModel>(200, content));
        }

        [HttpPost]
        public ActionResult<Result<WithOutContent>> Post([FromBody] ProfileIncludeViewModel model)
        {
            if (model.FilledFields())
                return BadRequest(new Result<WithOutContent>(400));

            _service.Include(model);
            if (!_service.Valid)
            {
                return BadRequest(new Result<WithOutContent>(404, _service.ValidationMessages));
            }
            return Ok(new Result<WithOutContent>(201));
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Result<WithOutContent>> Put([FromBody] ProfileIncludeViewModel model, Guid id)
        {
            _service.Update(model, id);
            if (!_service.Valid)
            {
                return BadRequest(new Result<WithOutContent>(404, _service.ValidationMessages));
            }
            return Ok(new Result<WithOutContent>(200));
        }

        [HttpDelete]
        public ActionResult<Result<WithOutContent>> Delete(
                [FromQuery] ProfileExcludeViewModel model
            )
        {
            _service.Delete(model);
            if (!_service.Valid)
            {
                return BadRequest(new Result<WithOutContent>(404, _service.ValidationMessages));
            }
            return Ok(new Result<WithOutContent>(200));
        }
    }
}
