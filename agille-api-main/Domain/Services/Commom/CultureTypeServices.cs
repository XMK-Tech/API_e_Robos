using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class CultureTypeServices : ICultureTypeServices
{
    private readonly ICultureTypeRepository _repository;
    private readonly ISessionServices _sessionServices;

    public CultureTypeServices(ICultureTypeRepository repository, ISessionServices sessionServices)
    {
        _repository = repository;
        _sessionServices = sessionServices;
    }

    public IEnumerable<CultureTypeViewModel> List(CultureTypeParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, @params);

        return query
                .Select(ViewModelConverter())
                .ToList();
    }
        
    public CultureTypeViewModel View(Guid id)
    {
        var entity = _repository
            .Query()
            .Where(x => x.Id == id)
            .Select(ViewModelConverter())
            .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("CultureType not found.");

        return entity;
    }
        
    public void Insert(CultureTypeInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var userId = _sessionServices.GetUserId();
        var entity = ConvertToEntity(model, userId);
        
        _repository.Insert(entity);
    }
        
    public void Update(Guid id, CultureTypeInsertUpdateViewModel model)
    {
        ValidateModel(model, id);
        
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("CultureType not found.");

        if (entity.IsDefault)
            throw new BadRequestException("Default CultureType cannot be updated.");

        UpdateEntity(entity, model);

        _repository.Update(entity);
    }
        
    public void Delete(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Include(e => e.Declarations)
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("CultureType not found.");

        if (entity.Declarations.Any())
            throw new BadRequestException("CultureType has declarations.");

        if (entity.IsDefault)
            throw new BadRequestException("Default CultureType cannot be deleted.");

        _repository.Delete(entity);
    }
        
    public bool Exists(Guid? id)
    {
        return _repository.Query().Any(e => e.Id == id);
    }
        
    public void UpdateCheckState(List<CultureTypeUpdateCheckStateViewModel> models)
    {
        var entitiesToUpdate = new List<CultureType>();

        models
            .DistinctBy(e => e.CultureId)
            .ToList()
            .ForEach(item =>
            {
                UpdateCultureCheckState(item, entitiesToUpdate);
            });

        _repository.UpdateMany(entitiesToUpdate);
    }

    private void UpdateCultureCheckState(CultureTypeUpdateCheckStateViewModel item, List<CultureType> entitiesToUpdate)
    {
        var entity = Get(item.CultureId);
        if (entity == null || entity.IsDefault)
            return;
        
        entity.IsChecked = item.IsChecked;
        entitiesToUpdate.Add(entity);
    }

    private void ValidateModel(CultureTypeInsertUpdateViewModel model, Guid? id = null)
    {
        var messages = new List<string>();

        if (model.Type == CultureTypeOptions.Null)
            messages.Add("Type is required.");

        if (NameIsUnavailable(model.Name, id))
            messages.Add("Name is not available.");

        if (messages.Any())
            throw new BadRequestException(messages);
    }
    
    private bool NameIsUnavailable(string name, Guid? ignoreId = null)
    {
        return _repository
                .Query()
                .WhereIf(ignoreId, e => e.Id != ignoreId)
                .Any(e => e.Name.ToLower() == name.ToLower());
    }

    private CultureType Get(Guid? id)
    {
        return _repository
                .Query()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private static CultureType ConvertToEntity(CultureTypeInsertUpdateViewModel model, Guid? userId = null)
    {
        return new()
        {
            Name = model.Name,
            UserId = userId,
            Type = model.Type,
            IsChecked = model.IsChecked,
        };
    }

    private static void UpdateEntity(CultureType entity, CultureTypeInsertUpdateViewModel model)
    {
        entity.Name = model.Name;
        entity.Type = model.Type;
        entity.IsChecked = model.IsChecked;
    }
            
    private static Expression<Func<CultureType, CultureTypeViewModel>> ViewModelConverter()
    {
        return x => new CultureTypeViewModel()
        {
            Id = x.Id,
            CreatedAt = x.CreatedAt,
            Name = x.Name,
            UserId = x.UserId,
            Type = x.Type,
            IsDefault = x.IsDefault,
            IsChecked = x.IsChecked,
        };
    }

    private static IQueryable<CultureType> Filter(IQueryable<CultureType> query, CultureTypeParams @params)
    {
        query = query
                .WhereIf(@params.Name, x => x.Name.Contains(@params.Name))
                .WhereIf(@params.Type, x => x.Type == @params.Type)
                .WhereIf(@params.IsDefault, x => x.IsDefault == @params.IsDefault)
                .WhereIf(@params.IsChecked, x => x.IsDefault == @params.IsChecked);
        
        query = query.Sort("asc", e => e.Name);
        
        return query;
    }
}