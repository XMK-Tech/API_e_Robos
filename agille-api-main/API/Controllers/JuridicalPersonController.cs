using AgilleApi.API.ControllersResult;
using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Services.Commom;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgilleApi.API.Controllers;

[Route("api/v1/juridical-persons")]
[ApiController]
public class JuridicalPersonController : BaseController
{
    private readonly JuridicalPersonServices _services;
    private readonly TransactionEntryServices _transactionEntryServices;

    public JuridicalPersonController(JuridicalPersonServices services, TransactionEntryServices transactionEntryServices)
    {
        _services = services;
        _transactionEntryServices = transactionEntryServices;
    }

    [HttpGet]
    public ActionResult<Result<List<JuridicalPersonListViewModel>>> Get([FromQuery] JuridicalPersonParams model, [FromQuery] MetadataParams metadataViewModel)
    {
        var metadata = metadataViewModel.ViewModelFromEntity();
        var content = _services.List(model, metadata);
        return GetSimpleResult(content, metadata);
    }

    [HttpGet("{id}")]
    public ActionResult<Result<JuridicalPersonViewModel>> Get(Guid id)
    {
        var content = _services.View(id);
        return GetSimpleResult(content);
    }

    [HttpPost]
    public ActionResult<Result<WithOutContent>> Post([FromBody] JuridicalPersonInsertUpdateViewModel model)
    {
        _services.Insert(model);
        return GetSimpleResult();
    }

    [HttpPut("{id}")]
    public ActionResult<Result<WithOutContent>> Put(Guid id, [FromBody] JuridicalPersonInsertUpdateViewModel model)
    {
        _services.Update(model, id);
        return GetSimpleResult();
    }

    [HttpDelete("{id}")]
    public ActionResult<Result<WithOutContent>> Delete(Guid id)
    {
        _services.Delete(id);
        return GetSimpleResult();
    }

    [HttpGet]
    [Route("transactions")]
    public ActionResult<Result<IEnumerable<TransactionViewModel>>> GetTransactions([FromQuery] TransactionParams transactionParams, [FromQuery] MetadataParams metadataViewModel)
    {
        var metadata = metadataViewModel.ViewModelFromEntity();
        var content = _transactionEntryServices.FindTransactions(transactionParams, metadata);
        return GetSimpleResult(content, metadata);
    }

    [HttpGet]
    [Route("transactions-count")]
    public ActionResult<Result<TransactionsDataViewModel<TransactionsCountVieModel>>> GetTransactionsCount([FromQuery] BaseInterval interval)
    {
        var content = _transactionEntryServices.GetTransactionsCount(interval);
        return GetSimpleResult(content);
    }

    [HttpGet]
    [Route("transactions-total")]
    public ActionResult<Result<TransactionsDataViewModel<TransactionsTotalViewModel>>> GetTransactionsTotal([FromQuery] BaseInterval interval)
    {
        var content = _transactionEntryServices.GetTransactionsTotal(interval);
        return GetSimpleResult(content);
    }
}