using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CountryController : BaseController
{
    private readonly AddressServices _addressServices;

    public CountryController(AddressServices addressServices)
    {
        _addressServices = addressServices;
    }

    [HttpGet]
    public ActionResult<Result<List<CountryListViewModel>>> Get(
        Guid id, string name = null, string sortColumn = null, 
        string sortDirection = null, int offset = 0, int limit = 0)
    {
        var model = new CountryListViewModel();
        var metadata = new Metadata();

        if (id != Guid.Empty)
            model.Id = id;
        if (name != null)
            model.Name = name;
        if (sortColumn != null)
            metadata.SortColumn = sortColumn;
        if (sortDirection != null)
            metadata.SortDirection = sortDirection;
        if (offset != 0)
            metadata.Offset = offset;
        if (limit != 0)
            metadata.Limit = limit;

        var content = _addressServices.ListCountries(model, metadata);
        return GetSimpleResult(content, metadata);
    }
}