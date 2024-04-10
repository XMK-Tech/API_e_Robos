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

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class CollectionController : BaseController
{
    private readonly ICollectionServices _services;

    public CollectionController(ICollectionServices services)
    {
        _services = services;
    }

    [HttpGet]
    [EnforcePermission("agiprev-pasep-collection-read")]
    public ActionResult<Result<IEnumerable<CollectionViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] CollectionParams @params)
    {
        var content = _services.List(meta, @params);
        return GetSimpleResult(content, meta);
    }
    [HttpGet("report/PDF")]
    public ActionResult<Result<byte[]>> GeneratePDFReport([FromQuery] Metadata meta, [FromQuery] CollectionParams @params)
    {
        var response = _services.GeneratePDFReport(meta, @params);
        return File(response.Content, response.ContentType, response.Title);
    }
    [HttpGet("report/CSV")]
    public ActionResult<Result<byte[]>> GenerateCSVReport([FromQuery] Metadata meta, [FromQuery] CollectionParams @params)
    {
        var response = _services.GenerateCSVReport(meta, @params);
        return File(response.Content, response.ContentType, response.Title);
    }

    [HttpGet("{id}")]
    [EnforcePermission("agiprev-pasep-collection-read")]
    public ActionResult<Result<CollectionViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("totalizer")]
    public ActionResult<Result<FilterSumViewModel>> GetSum([FromQuery] CollectionParams @params)
    {
        var content = _services.GetFilterSum(@params);
        return GetSimpleResult(content);
    }

    [HttpPut("{id}/attach")]
    public ActionResult<Result<WithOutContent>> AnnexAttachment(Guid id, [FromBody] CollectionAttachmentInsertUpdateViewModel model)
    {
        _services.AttachFile(id, model);
        return GetSimpleResult();
    }

    [HttpPost("import-from-crawler")]
    public ActionResult<Result<WithOutContent>> ImportFromCrawler([FromBody] AgiprevImportParams @params)
    {
        _services.ImportFromCrawler(@params);
        return GetSimpleResult();
    }

    [HttpPost]
    [EnforcePermission("agiprev-pasep-collection-add")]
    public ActionResult<Result<WithOutContent>> Post([FromBody] CollectionInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    [EnforcePermission("agiprev-pasep-collection-edit")]
    public ActionResult<Result<WithOutContent>> Put([FromBody] CollectionInsertUpdateViewModel model, Guid id)
    {
        _services.Update(model, id);
        return GetSimpleResult();
    }

    [HttpDelete("{id}")]
    [EnforcePermission("agiprev-pasep-collection-delete")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}