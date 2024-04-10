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
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AgilleApi.Domain.Services.Commom;

public class AddressServices : Notifications, IAddressService
{
    private readonly IAddressRepository _repository;

    public AddressServices(IAddressRepository repository)
    {
        _repository = repository;
    }

    public List<AddressViewModel> List(AddressParams model, Metadata metadata = null)
    {
        if (metadata == null)
            metadata = new Metadata();

        var query = Filter(model, metadata);
        var entities = _repository.ExecuteQuery(query, metadata);

        return ConvertToViewModel(entities);
    }

    private IQueryable<Address> Filter(AddressParams model, Metadata metadata)
    {
        var query = _repository
                    .Query()
                    .Include(e => e.City)
                    .ThenInclude(e => e.State)
                    .ThenInclude(e => e.Country)
                    .AsQueryable();

        Expression<Func<Address, Object>> sort = e => e.Street;

        if (metadata.SortColumn.ToLower() == "city_name")
            sort = e => e.City.Name;
        if (metadata.SortColumn.ToLower() == "state_name")
            sort = e => e.City.State.Name;
        if (metadata.SortColumn.ToLower() == "country_name")
            sort = e => e.City.State.Country.Name;
        if (metadata.SortColumn.ToLower() == "street")
            sort = e => e.Street;
        if (metadata.SortColumn.ToLower() == "zipcode")
            sort = e => e.ZipCode;

        if (metadata.SortDirection.ToLower() == "asc")
            query = query.OrderBy(sort);
        if (metadata.SortDirection.ToLower() == "desc")
            query = query.OrderByDescending(sort);

        if (model.Street != null)
            query = query.Where(e => e.Street.Contains(model.Street));

        if (model.Zipcode != null)
            query = query.Where(e => e.ZipCode.Contains(model.Zipcode));

        if (model.CityName != null)
            query = query.Where(e => e.City.Name.Contains(model.CityName));

        if (model.CountryName != null)
            query = query.Where(e => e.City.State.Country.Name.Contains(model.CountryName));

        if (model.StateName != null)
            query = query.Where(e => e.City.State.Name.Contains(model.StateName));

        if (model.Complement != null)
            query = query.Where(e => e.Complement.Contains(model.Complement));

        if (model.Owner != null)
            query = query.Where(e => e.Owner.Equals(model.Owner));

        if (model.OwnerId != null)
            query = query.Where(e => e.OwnerId.Equals(model.OwnerId));

        if (model.Type != AddressType.Null)
            query = query.Where(e => e.Type == model.Type);

        if (model.Id != Guid.Empty)
            query = query.Where(e => e.Id == model.Id);

        if (metadata.QuickSearch != null)
            query = query.Where(
                e =>
                e.Street.Contains(metadata.QuickSearch) ||
                e.ZipCode.Contains(metadata.QuickSearch) ||
                e.Complement.Contains(metadata.QuickSearch) ||
                e.City.Name.Contains(metadata.QuickSearch) ||
                e.City.State.Name.Contains(metadata.QuickSearch) ||
                e.City.State.Country.Name.Contains(metadata.QuickSearch));

        return query;
    }
    
    public List<CountryListViewModel> ListCountries(CountryListViewModel model, Metadata metadata)
    {
        var query = _repository.QueryCountries().AsQueryable();
        Expression<Func<Country, Object>> sort = e => e.Name;

        if (metadata.SortDirection.ToLower() == "asc")
            query = query.OrderBy(sort);
        if (metadata.SortDirection.ToLower() == "desc")
            query = query.OrderByDescending(sort);

        if (model.Id != Guid.Empty)
            query = query.Where(e => e.Id == model.Id);
        if (model.Name != null)
            query = query.Where(e => e.Name.Contains(model.Name));

        var countries = _repository.ExecuteCountriesQuery(query, metadata).Select(e => new CountryListViewModel()
        {
            Id = e.Id,
            Name = e.Name
        }).ToList();

        if (countries == null || countries.Count == 0)
            throw new NotFoundException("None countries was found");

        return countries;
    }

    public List<StateListViewModel> ListStates()
    {
        var states = _repository
            .QueryStates()
            .OrderBy(e => e.Name)
            .Select(e => new StateListViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                CountryId = e.CountryId
            }).ToList();

        return states;
    }

    public List<CityListViewModel> ListCities(Guid? stateId)
    {
        var cities = _repository
                        .QueryCities()
                        .Include(e => e.State)
                        .OrderBy(e => e.Name)
                        .Where(e => e.StateId == stateId)
                        .Select(e => new CityListViewModel()
                        {
                            Id = e.Id,
                            Name = e.Name,
                            StateId = e.StateId
                        }).ToList();

        return cities;
    }

    public AddressViewModel View(Guid addressId)
    {
        var address = _repository
                        .Query()
                        .Include(e => e.City)
                        .ThenInclude(e => e.State)
                        .ThenInclude(e => e.Country)
                        .Where(e => e.Id == addressId)
                        .FirstOrDefault();
        ThrowIfNull(address, "Address");

        return ConvertToViewModel(address);
    }

    public AddressViewModel View(string owner, string ownerId)
    {
        var address = _repository
                        .Query()
                        .Include(e => e.City)
                        .ThenInclude(e => e.State)
                        .ThenInclude(e => e.Country)
                        .Where(e => e.Owner.Equals(owner) && e.OwnerId.Equals(ownerId))
                        .FirstOrDefault();

        return ConvertToViewModel(address);
    }

    public AddressViewModel AddressInvoicePreView(string owner, string ownerId)
    {
        var addreses = _repository
                        .Query()
                        .Include(e => e.City)
                        .ThenInclude(e => e.State)
                        .ThenInclude(e => e.Country)
                        .Where(e => e.Owner.Equals(owner) && e.OwnerId.Equals(ownerId))
                        .ToList();

        var address = addreses
                        .Where(x => x.Type == AddressType.Commercial)
                        .FirstOrDefault();

        if (address == null)
            address = addreses.FirstOrDefault();

        return ConvertToViewModel(address);
    }

    public AddressViewModel Insert(AddressInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var entity = ConvertToEntity(model);
        ThrowIfNull(entity);

        _repository.Insert(entity);
        return View(entity.Id);
    }

    public List<Address> Create(List<AddressInsertUpdateViewModel> models)
    {
        return models.Select(Create).Where(e => e != null).ToList();
    }

    public Address Create(AddressInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var entity = ConvertToEntity(model);
        ThrowIfNull(entity);

        return entity;
    }

    public List<AddressViewModel> GetAddressByOwner(Guid id)
    {
        var entities = _repository
                        .Query()
                        .Include(e => e.City)
                        .ThenInclude(e => e.State)
                        .ThenInclude(e => e.Country)
                        .Where(e => e.OwnerId == id.ToString())
                        .ToList();

        return ConvertToViewModel(entities);
    }

    public List<AddressViewModel> Insert(List<AddressInsertUpdateViewModel> models)
    {
        return models.Select(Insert).Where(e => e != null).ToList();
    }

    public AddressViewModel Update(AddressInsertUpdateViewModel model, Guid id)
    {
        ValidateModel(model);

        var address = _repository.GetById(id);
        ThrowIfNull(address, "Address");

        var entity = ConvertToEntity(model, address);
        ThrowIfNull(entity);

        _repository.Update(entity);

        return View(entity.Id);
    }

    public void Update(List<AddressInsertUpdateViewModel> models)
    {
        var messages = new List<string>();

        foreach (var model in models)
        {
            if (model.Type == AddressType.Null)
                messages.Add("Type of address is required field, in form in the address com Zip Code:" + model.Zipcode + ".");
            
            if (model.OwnerId == null)
                messages.Add("OwnerId is required field.");
        }

        if (messages.Any()) 
            throw new BadRequestException(messages);

        var entities = models.Select(e => ConvertToEntity(e)).ToList();
        _repository.InsertMany(entities);
    }

    public AddressViewModel Update(AddressInsertUpdateViewModel model, string owner, string ownerId)
    {
        ValidateModel(model);

        var address = _repository
                        .Query()
                        .Where(e => e.Owner.Equals(owner) && e.OwnerId.Equals(ownerId))
                        .FirstOrDefault();
        ThrowIfNull(address, "Address");

        var entity = ConvertToEntity(model, address);
        ThrowIfNull(entity);

        _repository.Update(entity);

        return View(entity.Id);
    }

    public void Delete(Guid Id)
    {
        if (!_repository.Exists(Id))
            throw new NotFoundException("Address not found!");

        _repository.Delete(Id);
    }

    public void Delete(string owner, string ownerId)
    {
        var address = _repository
                        .Query()
                        .Where(e => e.Owner.Equals(owner) && e.OwnerId.Equals(ownerId))
                        .FirstOrDefault();
        ThrowIfNull(address, "Address");

        _repository.Delete(address);
    }

    public void DeleteMany(List<Guid> addressIds)
    {
        var adresses = _repository
                        .Query()
                        .Where(e => addressIds.Contains(e.Id))
                        .ToList();

        _repository.DeleteMany(adresses);
    }
    
    public void DeleteMany(List<Address> entities)
    {
        if (entities == null)
            return;

        _repository.DeleteMany(entities);
    }

    public bool CityExist(Guid? id)
    {
        return _repository.QueryCities().Where(e => e.Id == id).Any();
    }

    public Guid? GetCityId(string name)
    {
        var city = _repository
                        .QueryCities()
                        .WhereLikeSanitized(name, e => e.Name)
                        .FirstOrDefault();

        return city?.Id;
    }

    public string GetStateByCityName(string city)
    {
        var state = _repository
                        .QueryCities()
                        .Include(e => e.State)
                        .WhereLikeSanitized(city, e => e.Name)
                        .Select(e => e.State)
                        .FirstOrDefault();

        return state?.Name;
    }

    public static List<AddressViewModel> ConvertToViewModel(List<Address> model)
    {
        if (model == null)
            return null;

        return model.Select(ConvertToViewModel).ToList();
    }
    
    public static List<AddressViewModel> ConvertToViewModel(List<AddressPerson> model)
    {
        return model.Select(item => ConvertToViewModel(item.Address)).ToList();
    }

    public static AddressViewModel ConvertToViewModel(Address model)
    {
        if (model == null) 
            return null;

        var viewModel = new AddressViewModel(
            model.Id,
            model.Street,
            model.Number,
            model.Complement,
            model.ZipCode,
            model.Type,
            model.CityId,
            model.City != null ? model.City.StateId : Guid.Empty,
            model.City != null ? (model.City.State != null ? model.City.State.CountryId : Guid.Empty) : Guid.Empty,
            model.Owner,
            model.OwnerId,
            model.Type.GetDescription(),
            model.City != null ? model.City.Name : "",
            model.City != null ? (model.City.State != null ? model.City.State.Name : "") : "",
            model.City != null ? (model.City.State != null ? (model.City.State.Country != null ? model.City.State.Country.Name : "") : "") : "",
            model.District,
            model.Function);

        return viewModel;
    }

    private void ValidateModel(AddressInsertUpdateViewModel model)
    {
        var cityId = model.CityId ?? Guid.Empty;
        if (!_repository.ExistsCity(cityId))
            throw new NotFoundException("City not found!");

        var badMessages = new List<string>();

        if ((model.Zipcode?.Length ?? 0) > 9)
            badMessages.Add("Zipcode inválido.");

        if (model.Type == AddressType.Null)
            badMessages.Add("Address type is required field.");

        if (string.IsNullOrEmpty(model.OwnerId))
            badMessages.Add("OwnerId is required field");

        if (badMessages.Any())
            throw new BadRequestException(badMessages);
    }

    private static Address ConvertToEntity(AddressInsertUpdateViewModel viewModel, Address entity = null)
    {
        if (entity == null)
            entity = new Address(viewModel.Street, viewModel.Number, viewModel.Complement, viewModel.Zipcode, viewModel.Type, (Guid)viewModel.CityId, viewModel.Owner, viewModel.OwnerId, viewModel.District, viewModel.Function);
        else
        {
            entity.Street = viewModel.Street;
            entity.District = viewModel.District;
            entity.Number = viewModel.Number;
            entity.Complement = viewModel.Complement;
            entity.ZipCode = viewModel.Zipcode;
            entity.Type = viewModel.Type;
            entity.CityId = (Guid)viewModel.CityId;
            entity.Owner = viewModel.Owner;
            entity.OwnerId = viewModel.OwnerId;
            entity.Function = viewModel.Function;
        }

        return entity;
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if(entity == null)
            throw new NotFoundException($"{message} not found.");
    }
}