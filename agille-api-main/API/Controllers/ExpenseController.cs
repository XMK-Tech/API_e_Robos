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
public class ExpenseController : BaseController
{
    private readonly IExpenseServices _services;

    public ExpenseController(IExpenseServices services)
    {
        _services = services;
    }

    [HttpGet]
    [EnforcePermission("agiprev-pasep-expense-read")]
    public ActionResult<Result<IEnumerable<ExpenseViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] ExpenseParams @params)
    {
        var content = _services.List(meta, @params);
        return GetSimpleResult(content, meta);
    }
    [HttpGet("report/PDF")]
    public ActionResult<Result<byte[]>> GeneratePDFReport([FromQuery] Metadata meta, [FromQuery] ExpenseParams @params)
    {
        var response = _services.GeneratePDFReport(meta, @params);
        return File(response.Content, response.ContentType, response.Title);
    }
    [HttpGet("report/CSV")]
    public ActionResult<Result<byte[]>> GenerateCSVReport([FromQuery] Metadata meta, [FromQuery] ExpenseParams @params)
    {
        var response = _services.GenerateCSVReport(meta, @params);
        return File(response.Content, response.ContentType, response.Title);
    }

    [HttpGet("{id}")]
    [EnforcePermission("agiprev-pasep-expense-read")]
    public ActionResult<Result<ExpenseViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpGet("totalizer")]
    public ActionResult<Result<FilterSumViewModel>> GetSum([FromQuery] ExpenseParams @params)
    {
        var content = _services.GetFilterSum(@params);
        return GetSimpleResult(content);
    }

    [HttpPost("import-from-crawler")]
    public ActionResult<Result<WithOutContent>> Post([FromBody]AgiprevImportParams @params)
    {
        _services.ImportFromCrawler(@params);
        return GetSimpleResult();
    }

    [HttpPost]
    [EnforcePermission("agiprev-pasep-expense-add")]
    public ActionResult<Result<WithOutContent>> Post([FromBody] ExpenseInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    [EnforcePermission("agiprev-pasep-expense-edit")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] ExpenseInsertUpdateViewModel model)
    {
        _services.Update(id, model);
        return GetSimpleResult();
    }

    [HttpPut("{id}/attach")]
    public ActionResult<Result<WithOutContent>> AnnexAttachment(Guid id, [FromBody] ExpenseAttachmentInsertUpdateViewModel model)
    {
        _services.AttachFile(id, model);
        return GetSimpleResult();
    }

    [HttpDelete("{id}")]
    [EnforcePermission("agiprev-pasep-expense-delete")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }
}