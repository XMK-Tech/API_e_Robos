using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly AddressServices _addressServices;

        public CityController(AddressServices addressServices)
        {
            _addressServices = addressServices;
        }

        [HttpGet]
        public ActionResult<Result<List<CityListViewModel>>> Get(Guid id, Guid stateId)
        {
            var content = _addressServices.ListCities(stateId);
            return GetSimpleResult(content);
        }
    }
}
