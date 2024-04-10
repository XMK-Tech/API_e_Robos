using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgilleApi.Domain.Services.Commom;

public class ARServices : IARServices
{
    private readonly IEntitiesServices _entitiesServices;
    private readonly ICourierServices _courierServices;
    private readonly IPersonServices _personServices;
    private readonly ISessionServices _sessionServices;
    private readonly IPDFGenerator _pDFGenerator;
    private readonly IImageLoaderServices _imageLoaderServices;
    private readonly MiddlewareClient _middlewareClient;
    private readonly AttachmentServices _attachmentServices;
    private readonly AddressServices _addressServices;

    public ARServices(IEntitiesServices entitiesServices, ICourierServices courierServices, MiddlewareClient middlewareClient, IPersonServices personServices, ISessionServices sessionServices, IPDFGenerator pDFGenerator, AttachmentServices attachmentServices, IImageLoaderServices imageLoaderServices, AddressServices addressServices)
    {
        _entitiesServices = entitiesServices;
        _courierServices = courierServices;
        _middlewareClient = middlewareClient;
        _personServices = personServices;
        _sessionServices = sessionServices;
        _pDFGenerator = pDFGenerator;
        _attachmentServices = attachmentServices;
        _imageLoaderServices = imageLoaderServices;
        _addressServices = addressServices;
    }

    public async Task<byte[]> GenerateAR(ARViewModel model, Guid subjectId)
    {
        var subject = GetSubject(subjectId);
        var data = ConvertToCourierData(model, subject);
        return await GenerateAR(data);
    }

    public async Task<byte[]> GenerateAR(CourierDataViewModel model)
    {
        return await _courierServices.TryPost(model);
    }

    public async Task<ARViewModel> CourierBaseAddress(Guid subjectId)
    {
        var subject = _personServices.View(subjectId);
        var subjectAddress = subject?.Addresses.FirstOrDefault();

        var entity = _entitiesServices.View();

        PostOfficeConsumer.enderecoERP devolution = null;
        PostOfficeConsumer.enderecoERP recipient = null;

        try
        {
            devolution = await _courierServices.GetAddress(entity?.Address?.Zipcode);
        }
        catch { }

        try
        {
            recipient = await _courierServices.GetAddress(subjectAddress?.Zipcode);
        }
        catch { }

        var entityAddress = entity?.Address;
        return new()
        {
            Recipient = new()
            {
                Number = subjectAddress?.Number,
                Street = SelectField(subjectAddress?.Street, recipient?.end),
                CityName = SelectField(subjectAddress?.CityName, recipient?.cidade),
                StateName = SelectField(subjectAddress?.StateName, recipient?.uf),
                District = recipient?.bairro,
                ZipCode = SelectField(subjectAddress?.Zipcode, recipient?.cep),
                Complement = subjectAddress?.Complement,
                Description = "",
            },
            Devolution = new()
            {
                Number = entityAddress?.Number,
                Street = SelectField(entityAddress?.Street, devolution?.end),
                CityName = SelectField(entityAddress?.CityName, devolution?.cidade),
                StateName = SelectField(devolution?.uf, entityAddress?.StateName),
                District = SelectField(entityAddress?.District, devolution?.bairro),
                ZipCode = SelectField(entityAddress?.Zipcode, devolution?.cep),
                Complement = entityAddress?.Complement,
                Description = "",
            },
            AdditionalInformation = "",
        };
    }

    public async Task<(byte[], string)> JoinTerm(ForwardingTermInsertUpdateViewModel model, Guid subjectId)
    {
        var entity = _entitiesServices.View();
        var subject = GetSubject(subjectId);

        var data = new ForwardingTerm(model)
        {
            SubjectName = subject?.Name,
            SubjectDocument = subject?.Document,

            Auditor = GetAuditorName(),

            Image = _imageLoaderServices.ConvertToBase64(entity.EntityImage),
            EntityName = entity.Name,
            StateInitials = _addressServices.GetStateByCityName(entity.Name),
            
            Type = model.Type,
        };

        var response = await _pDFGenerator.Generate(data, "JoiningTerm");
        var attachment = _attachmentServices.InsertByBytes(response, "Stage-Joining-term", "application/pdf", "TaxStage", subjectId.ToString());

        return (response, attachment.Url);
    }

    private PersonListViewModel GetSubject(Guid? id)
    {
        if (!id.HasValue)
            return null;

        return _personServices.View(id.Value);
    }

    private UserInfoViewModel GetAuditor()
    {
        var session = _sessionServices.GetCurrentSession();
        var userId = session?.UserId;

        if (!userId.HasValue)
            return null;

        return _middlewareClient.GetUserInfos(new() { userId.Value })?.FirstOrDefault();
    }

    private string GetAuditorName()
    {
        return GetAuditor()?.Fullname;
    }

    private static string SelectField(string native, string courier)
    {
        return (string.IsNullOrEmpty(native)) ? courier : native;
    }

    private static CourierDataViewModel ConvertToCourierData(ARViewModel model, PersonListViewModel subject)
    {
        return new()
        {
            AdditionalInformation = model.AdditionalInformation,
            Recipient = model.Recipient,
            Devolution = model.Devolution,
            RecipientInfo = subject,
        };
    }
}