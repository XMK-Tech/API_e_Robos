using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class StateController : BaseController
{
    private readonly AddressServices _addressServices;

    public StateController(AddressServices addressServices)
    {
        _addressServices = addressServices;
    }

    [HttpGet]
    public ActionResult<Result<List<StateListViewModel>>> Get()
    {
        var content = _addressServices.ListStates();
        return GetSimpleResult(content);
    }
}