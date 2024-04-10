using AgilleApi.API.ControllersResult.Base;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.API.ControllersResult;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Services.Commom;
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
public class VerificationController : BaseController
{
    private readonly IVerificationServices _services;
    private readonly IVerificationCalculateServices _verificationCalculateServices;

    public VerificationController(IVerificationServices services,
        IVerificationCalculateServices verificationCalculateServices)
    {
        _services = services;
        _verificationCalculateServices = verificationCalculateServices;
    }

    [HttpGet("{id}")]
    [EnforcePermission("agiprev-pasep-verification-read")]
    public ActionResult<Result<VerificationViewModel>> Get(Guid Id)
    {
        var content = _services.View(Id);
        return GetSimpleResult(content);
    }

    [HttpGet]
    [EnforcePermission("agiprev-pasep-verification-read")]
    public ActionResult<Result<IEnumerable<VerificationViewModel>>> Get([FromQuery] Metadata meta, [FromQuery] VerificationParams @params)
    {
        var content = _verificationCalculateServices.List(meta, @params);
        return GetSimpleResult(content, meta);
    }

    [HttpGet("totalizer")]
    public ActionResult<Result<FilterSumViewModel>> GetSum([FromQuery] VerificationParams @params)
    {
        var content = _services.GetFilterSum(@params);
        return GetSimpleResult(content);
    }

    [HttpGet("calculation-log/{year}")]
    public ActionResult<Result<CalculationUrlViewModel>> GetCalculationUrl(string year)
    {
        var url = year switch
        {
            "2018" => "https://storage.googleapis.com/download/storage/v1/b/agille/o/c0cd200a-a10f-404c-98af-cc4f744541f6.pdf?generation=1686230593174530&alt=media",
            "2019" => "https://storage.googleapis.com/download/storage/v1/b/agille/o/1f4e4247-172d-4663-850b-dbe6734c9a3c.pdf?generation=1686230574219883&alt=media",
            "2020" => "https://storage.googleapis.com/download/storage/v1/b/agille/o/563b0058-ba8b-4bfd-8ee7-8a69ae96de9b.pdf?generation=1686230553444201&alt=media",
            "2021" => "https://storage.googleapis.com/download/storage/v1/b/agille/o/223653d7-9e6f-49e0-915f-a0817bf6b9f3.pdf?generation=1686230519291793&alt=media",
            "2022" => "https://storage.googleapis.com/download/storage/v1/b/agille/o/65d8c86d-d3fc-4c06-aa24-0724714b7fcd.pdf?generation=1686230469380430&alt=media",
            "2023" => "https://storage.googleapis.com/download/storage/v1/b/agille/o/41ece35e-8ebc-44fe-9169-67f0433ac434.pdf?generation=1686835792418566&alt=media",
            _ => ""
        };

        var content = new CalculationUrlViewModel()
        {
            Url = url
        };

        return GetSimpleResult(content);
    }
}
