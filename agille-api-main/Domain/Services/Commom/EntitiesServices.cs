using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System.Collections.Generic;

namespace AgilleApi.Domain.Services.Commom;

public class EntitiesServices : IEntitiesServices
{
    private readonly IEntitiesRepository _repository;
    private readonly ITenantServices _tenantServices;
    private readonly IImageLoaderServices _imageLoaderServices;

    private EntitiesViewModel Content = null;

    public EntitiesServices(
        IEntitiesRepository entitiesRepository, 
        ITenantServices tenantServices, 
        IImageLoaderServices imageLoaderServices)
    {
        _repository = entitiesRepository;
        _tenantServices = tenantServices;
        _imageLoaderServices = imageLoaderServices;
    }

    public EntitiesViewModel View()
    {
        if (Content != null)
            return Content;

        var entity = Find();
        ThrowIfNull(entity);

        Content = ConvertToViewModel(entity);
        
        return Content;
    }

    public void Patch(EntitiesViewModel model)
    {
        var entity = Find();
        ThrowIfNull(entity);

        var id = _tenantServices.GetId();

        UpdateEntity(model, entity);
        _repository.Update(entity, id);
    }

    public string GetBase64Image()
    {
        var url = View().EntityImage;
        return _imageLoaderServices.ConvertToBase64(url);
    }

    public string GetCityName()
    {
        return View().Address.CityName;
    }

    public List<string> GetAgiprevDocuments()
    {
        var entity = View();
        return entity?.Agiprev?.Documents ?? new();
    }

    private Entities.Entities Find()
    {
        var id = _tenantServices.GetId();
        return _repository.Get(id);
    }

    public decimal GetAliquot()
    {
        var entity = View();
        return entity?.ITR?.Aliquot ?? 0;
    }

    private static void UpdateEntity(EntitiesViewModel model, Entities.Entities entity)
    {
        entity.Name = entity.Name.Patch(model.Name);
        entity.Document = entity.Document.Patch(model.Document);
        entity.EntityImage = entity.EntityImage.Patch(model.EntityImage);

        if (model.Address != null && model.Address.CityId.HasValue)
            if (entity.Address != null)
                entity.Address.Patch(model.Address);
            else
                entity.Address = new(model.Address);

        entity.Content.Patch(model.ITR, model.ISS, model.DTE, model.Agiprev, model.DemoMode);
    }

    private static EntitiesViewModel ConvertToViewModel(Entities.Entities entity)
    {
        return new EntitiesViewModel(entity.Content?.ISS, entity.Content?.ITR, entity.Content?.DTE, entity.Address, entity.Content?.Agiprev)
        {
            Name = entity.Name,
            EntityImage = entity.EntityImage,
            Document = entity.Document,
            DemoMode = entity.Content?.DemoMode,
        };
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");    
    }
}