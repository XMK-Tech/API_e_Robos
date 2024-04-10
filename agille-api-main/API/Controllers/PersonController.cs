using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TelLink.API.Implemantation.Services;

namespace AgilleApi.API.Controllers;

[Route("api/v1/persons")]
[ApiController]
[Authorize]
public class PersonController : BaseController
{
    private readonly IPersonServices _services;
    private readonly IPersonImportServices _importServices;

    public PersonController(IPersonServices services, IPersonImportServices importServices)
    {
        _services = services;
        _importServices = importServices;
    }

    [HttpGet]
    [EnforcePermission("agiprev-pasep-person-read")]
    public ActionResult<Result<IEnumerable<PersonListViewModel>>> Get([FromQuery] PersonParams model, [FromQuery] MetadataParams metaparams)
    {
        var metadata = metaparams.ViewModelFromEntity();
        IEnumerable<PersonListViewModel> content = _services.List(model, metadata);
        return GetSimpleResult(content, metadata);
    }

    [HttpGet("{id}")]
    [EnforcePermission("agiprev-pasep-person-read")]
    public ActionResult<Result<PersonListViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("Select")]
    public ActionResult<Result<IEnumerable<SelectPersonViewModel>>> GetSelect()
    {
        IEnumerable<SelectPersonViewModel> content = _services.Select();
        return GetSimpleResult(content);
    }

    [HttpPost("csv")]
    public ActionResult<Result<CsvResponseViewModel>> Post([FromBody] CsvInsertViewModel model)
    {
        var content = _importServices.InsertCSV(model);
        return GetSimpleResult(content);
    }

    [HttpPut("users")]
    public ActionResult<Result<WithOutContent>> PutUsers()
    {
        _services.CreateAllUsers();
        return GetSimpleResult();
    }

    [HttpPut("user/{id}")]
    public ActionResult<Result<WithOutContent>> PutUsers(Guid id)
    {
        _services.CreateUser(id);
        return GetSimpleResult();
    }

    [HttpPut("agiprev/user/{id}")]
    [EnforcePermission("agiprev-pasep-person-add")]
    public ActionResult<Result<SelectPersonViewModel>> PutUsersAgiprev([FromBody] PersonInsertUpdateViewModelAgiPrev model, Guid id)
    {
        var content = _services.CreateUser(model, id);
        return GetResult(_services, content);
    }

    [HttpPost("accreditation")]
    [AllowAnonymous]
    public ActionResult<Result<WithOutContent>> Accreditation([FromBody] PersonViewModelBase model)
    {
        _services.Accreditation(model);
        return GetSimpleResult();
    }

    [HttpPut("accreditation/authorize/{id}")]
    public ActionResult<Result<WithOutContent>> AuthorizeAccreditation(Guid id)
    {
        _services.AuthorizeAccreditation(id);
        return GetSimpleResult();
    }
}