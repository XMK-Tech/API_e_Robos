using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Commom;

public class TaxProcessServices : ITaxProcessServices
{
    private readonly IPDFGenerator _pDFGenerator;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IImageLoaderServices _imageLoaderServices;
    private readonly ISessionServices _sessionServices;
    private readonly MiddlewareClient _middlewareClient;


    public TaxProcessServices(IPDFGenerator pDFGenerator, IEntitiesServices entitiesServices, IImageLoaderServices imageLoaderServices, ISessionServices sessionServices, MiddlewareClient middlewareClient)
    {
        _pDFGenerator = pDFGenerator;
        _entitiesServices = entitiesServices;
        _imageLoaderServices = imageLoaderServices;
        _sessionServices = sessionServices;
        _middlewareClient = middlewareClient;
    }

    public async Task<byte[]> Insert(TaxProcessInsertUpdateViewModel model)
    {
        var printModel = BuildPrintModel(model);
        return await _pDFGenerator.Generate(printModel, "TaxProcess");
    }

    private TaxProcessPrintModel BuildPrintModel(TaxProcessInsertUpdateViewModel model)
    {
        var session = _sessionServices.GetCurrentSession();
        var entity = _entitiesServices.View();
        return new()
        {
            EntityName = entity?.Name,
            Image = _imageLoaderServices.ConvertToBase64(entity?.EntityImage),
            StateInitials = entity?.Address?.StateName,

            Auditor = GetAuditorName(session?.UserId),
        };
    }

    private string GetAuditorName(Guid? userId)
    {
        if (!userId.HasValue)
            return null;

        var user = _middlewareClient.GetUserInfos(new List<Guid>() { userId.Value }).FirstOrDefault();
        return user?.Fullname;
    }
}