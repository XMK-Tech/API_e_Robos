using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgilleApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OperatorController : BaseController
    {
        private readonly IOperatorServices _services;

        public OperatorController(IOperatorServices services)
        {
            _services = services;
        }

        [HttpGet("{personId}")]
        public ActionResult<Result<OperatorViewModel>> Get(Guid personId)
        {
            var content = _services.View(personId);
            return GetSimpleResult(content);
        }

        [HttpPost]
        public ActionResult<Result<ResultCreatePersonAgiprevViewModel>> Post([FromBody] PersonInsertUpdateViewModelAgiPrev model)
        {
            var content = _services.Insert(model);
            return GetSimpleResult(content);
        }

        [HttpPut("{id}")]
        public ActionResult<Result<WithOutContent>> Put([FromBody] PersonInsertUpdateViewModelAgiPrev model, Guid id)
        {
            _services.Update(model, id);
            return GetSimpleResult();
        }
    }
}
