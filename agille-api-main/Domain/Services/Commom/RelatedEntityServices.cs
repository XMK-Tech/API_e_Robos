using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class RelatedEntityServices : IRelatedEntityServices
{
    private readonly IRelatedEntityRepository _repository;
    private readonly AddressServices _addressServices;

    public RelatedEntityServices(IRelatedEntityRepository repository, AddressServices addressServices)
    {
        _repository = repository;
        _addressServices = addressServices;
    }

    public IEnumerable<RelatedEntityViewModel> List(Metadata meta, RelatedEntityParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, meta, @params);

        return _repository
                .ExecuteGenericQuery(query, meta, ViewModelConverter());
    }

    public RelatedEntityViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("RelatedEntity not found.");

        return entity;
    }

    public void Insert(RelatedEntityInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var address = _addressServices.Insert(model.Address);
        var entity = ConvertToEntity(model, address.Id);

        _repository.Insert(entity);
    }

    public void Update(Guid id, RelatedEntityInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var entity = _repository.GetById(id);
        if (entity == null)
            throw new NotFoundException("RelatedEntity not found.");

        UpdateEntity(entity, model);

        _repository.Update(entity);
    }

    public void Delete(Guid id)
    {
        _repository.Delete(id);
    }

    public Guid? FindIdByName(string name)
    {
        return _repository
                .Query()
                .WhereLike(name, entity => entity.Name)
                .FirstOrDefault()?.Id;
    }

    private static void ValidateModel(RelatedEntityInsertUpdateViewModel model)
    {
        var messages = new List<string>();

        if (string.IsNullOrEmpty(model.Name))
            messages.Add("Name is required.");

        if (string.IsNullOrEmpty(model.Document))
            messages.Add("Document is required.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private static RelatedEntity ConvertToEntity(RelatedEntityInsertUpdateViewModel model, Guid addressId)
    {
        return new()
        {
            Name = model.Name,
            Document = model.Document,
            Type = model.Type,
            AddressId = addressId,
            ImageUrl = model.ImageUrl,
        };
    }

    private void UpdateEntity(RelatedEntity entity, RelatedEntityInsertUpdateViewModel model)
    {
        entity.Name = model.Name;
        entity.Document = model.Document;
        entity.Type = model.Type;
        entity.ImageUrl = model.ImageUrl;

        _addressServices.Update(model.Address, entity.AddressId);
    }

    private static Expression<Func<RelatedEntity, RelatedEntityViewModel>> ViewModelConverter()
    {
        return relatedEntity => new RelatedEntityViewModel()
        {
            Id = relatedEntity.Id,
            CreatedAt = relatedEntity.CreatedAt,
            Name = relatedEntity.Name,
            Document = relatedEntity.Document,
            Type = relatedEntity.Type,
            ImageUrl = relatedEntity.ImageUrl,

            Address = new()
            {
                Id = relatedEntity.AddressId,
                Street = relatedEntity.Address.Street,
                Zipcode = relatedEntity.Address.ZipCode,
                Number = relatedEntity.Address.Number,
                Complement = relatedEntity.Address.Complement,
                District = relatedEntity.Address.District,

                StateId = relatedEntity.Address.City.StateId,
                StateName = relatedEntity.Address.City.State.Name,

                CityId = relatedEntity.Address.CityId,
                CityName = relatedEntity.Address.City.Name,

                CountryId = relatedEntity.Address.City.State.CountryId,
                CountryName = relatedEntity.Address.City.State.Country.Name,

                Type = relatedEntity.Address.Type,
                TypeDescription = relatedEntity.Address.Type.GetDescription()
            }
        };
    }

    private static IQueryable<RelatedEntity> Filter(IQueryable<RelatedEntity> query, Metadata meta, RelatedEntityParams @params)
    {
        query = query
                .WhereIf(@params.Name, re => re.Name.Contains(@params.Name))
                .WhereIf(@params.Document, re => re.Document.Contains(@params.Document))
                .WhereIf(@params.Type, re => re.Type == @params.Type)
                .WhereIf(@params.AddressId, re => re.AddressId == @params.AddressId);

        Expression<Func<RelatedEntity, object>> orderBy = meta.SortColumn.ToLower()
                switch
        {
            "name" => re => re.Name,
            "document" => re => re.Document,
            "type" => re => re.Type,
            _ => re => re.CreatedAt,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdAt";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }
}