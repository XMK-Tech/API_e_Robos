using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class ServiceTypeServices
{
    private readonly IServiceTypeRepository _repository;
    private readonly IServiceTypeDescriptionRepository _descriptionRepository;
    private readonly IJuridicalPersonServiceTypeDescriptionRepository _relationRepository;

    public ServiceTypeServices(IServiceTypeRepository repository, IServiceTypeDescriptionRepository descriptionRepository, IJuridicalPersonServiceTypeDescriptionRepository relationRepository)
    {
        _repository = repository;
        _descriptionRepository = descriptionRepository;
        _relationRepository = relationRepository;
    }

    public IEnumerable<ServiceTypeViewModel> View(Metadata meta)
    {
        var query = GetAll().OrderBy(e => e.Name);
        return _repository
                .ExecuteQuery(query, meta)
                .Select(ConvertToViewModel)
                .ToList();
    }

    public IEnumerable<ServiceTypeViewModel> ViewByJuridicalPersonId(Guid id, Metadata meta)
    {
        return GetRelations(id, meta);
    }

    public ServiceTypeViewModel View(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, "ServiceType");

        return ConvertToViewModel(entity);
    }

    public ServiceTypeViewModel Insert(ServiceTypeInsertUpdateViewModel model)
    {
        ValidateModel(model);
        var entity = ConvertToEntity(model);

        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    public ServiceTypeViewModel Update(ServiceTypeInsertUpdateViewModel model, Guid id)
    {
        ValidateModel(model);

        var entity = Get(id);
        ThrowIfNull(entity, "ServiceType");

        _descriptionRepository.DeleteMany(entity.Descriptions.ToList());

        ConvertToEntity(model, entity);

        _descriptionRepository.InsertMany(entity.Descriptions.ToList());
        _repository.Update(entity);

        return ConvertToViewModel(entity);
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity, "ServiceType");

        _descriptionRepository.DeleteMany(entity.Descriptions.ToList());
        _repository.Delete(entity);
    }

    public void InsertRelations(Guid juridicalPersonId, IEnumerable<Guid> descriptions)
    {
        var toAdd = new List<JuridicalPersonServiceTypeDescription>();

        foreach(var item in descriptions)
            if (DescriptionExist(item))
                toAdd.Add(new JuridicalPersonServiceTypeDescription(item, juridicalPersonId));    

        if (toAdd.Any())
            _relationRepository.InsertMany(toAdd);
    }

    public void DeleteRelations(Guid juridicalPersonId)
    {
        var toDelete = _relationRepository
                        .Query()
                        .Where(e => e.JuridicalPersonId == juridicalPersonId)
                        .ToList();

        if(toDelete.Any())
            _relationRepository.DeleteMany(toDelete);
    }

    public List<ServiceTypeViewModel> GetRelations(Guid juridicalPersonId, Metadata meta = null)
    {
        var query = _relationRepository
                        .Query()
                        .Include(e => e.ServiceTypeDescription)
                        .Where(e => e.JuridicalPersonId == juridicalPersonId)
                        .Select(e => e.ServiceTypeDescription);

        var descriptions = (meta == null) ? query.ToList() : _descriptionRepository.ExecuteQuery(query, meta).ToList();

        var filterIds = descriptions
                        .Select(e => e.Id)
                        .ToList();

        var typeIds = descriptions
                        .Select(e => e.ServiceTypeId)
                        .Distinct()
                        .ToList();

        var types = GetManyByIds(typeIds);
        types.ForEach(e => DescriptionFilter(e, filterIds));

        return types.Select(ConvertToViewModel).ToList();
    }

    public bool DescriptionExist(Guid id)
    {
        return _descriptionRepository.Query().Where(e => e.Id == id).Any();
    }

    private static void DescriptionFilter(ServiceType type, IEnumerable<Guid> lookingFor)
    {
        type.Descriptions = type.Descriptions.Where(e => lookingFor.Contains(e.Id)).ToList();
    }

    private static void ValidateModel(ServiceTypeInsertUpdateViewModel model)
    {
        var messages = new List<string>();

        if (string.IsNullOrEmpty(model.Name))
            messages.Add("Name is required.");

        foreach(var description in model.Descriptions)
        {
            if (string.IsNullOrEmpty(description.Description))
                messages.Add("Description(in a description) is required.");

            if (!description.ISSAnnualValue.HasValue && !description.ISSRate.HasValue)
                messages.Add("At least one of the properties(ISSAnnualValue & ISSRate) is required.");

            if (description.ISSAnnualValue.HasValue)
                if (description.ISSAnnualValue < 0)
                    messages.Add($"ISSAnnualValue({description.ISSAnnualValue}) cannot be less than zero");

            if (description.ISSRate.HasValue)
                if (description.ISSRate < 0 || description.ISSRate > 100)
                    messages.Add($"ISSRate({description.ISSRate}) must be in the range from 0 to 100.");
        }

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }

    private List<ServiceType> GetManyByIds(IEnumerable<Guid> ids)
    {
        return GetAll()
                .Where(e => ids.Contains(e.Id))
                .ToList();
    }

    private ServiceType Get(Guid id)
    {
        return GetAll()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private IQueryable<ServiceType> GetAll()
    {
        return _repository
                .Query()
                .Include(e => e.Descriptions);
    }

    private static ServiceType ConvertToEntity(ServiceTypeInsertUpdateViewModel model, ServiceType entity = null)
    {
        if (entity == null)
            entity = new ServiceType();

        entity.Name = model.Name;
        entity.Code = model.Code;
        entity.Descriptions = model.Descriptions.Select(e => new ServiceTypeDescription(e.Description, e.ISSRate, e.ISSAnnualValue, entity.Id, e.Code)).ToList();

        return entity;
    }

    private static ServiceTypeViewModel ConvertToViewModel(ServiceType entity)
    {
        return new ServiceTypeViewModel(entity);
    }
}