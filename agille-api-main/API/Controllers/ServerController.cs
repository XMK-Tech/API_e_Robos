using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServerController : BaseController
    {
        private readonly IServerServices _services;

        public ServerController(IServerServices services)
        {
            _services = services;
        }

        [HttpGet("{personId}")]
        public ActionResult<Result<ServerViewModel>> Get(Guid personId)
        {
            var content = _services.View(personId);
            return GetSimpleResult(content);
        }

        [HttpGet("select-categories")]
        public ActionResult<Result<IEnumerable<ServerSelectViewModel>>> Select()
        {
            var content = _services.SelectCategory();
            return GetSimpleResult(content);
        }

        [HttpPost]
        public ActionResult<Result<ResultCreatePersonAgiprevViewModel>> Post([FromBody] ServerInsertUpdateViewModel model)
        {
            var content = _services.Insert(model);
            return GetSimpleResult(content);
        }

        [HttpPut("{id}")]
        public ActionResult<Result<WithOutContent>> Put([FromBody] ServerInsertUpdateViewModel model, Guid id)
        {
            _services.Update(model, id);
            return GetSimpleResult();
        }
    }
}
