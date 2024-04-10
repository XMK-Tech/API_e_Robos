using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public abstract class AddressViewModelBase
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Zipcode { get; set; }
    public AddressType Type { get; set; }
    public Guid? CityId { get; set; } 
    public string Owner { get; set; }
    public string OwnerId { get; set; }
    public AddressFunction Function { get; set; }
}


public class AddressParams
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string Complement { get; set; }
    public string Zipcode { get; set; }
    public AddressType Type { get; set; }
    public string CityName { get; set; } //
    public string StateName { get; set; } // 
    public string CountryName { get; set; } //
    public string Owner { get; set; }
    public string OwnerId { get; set; }
}

public class AddressInsertUpdateViewModel : AddressViewModelBase
{ }

public class AddressViewModel : AddressViewModelBase
{
    public AddressViewModel() { }
    public AddressViewModel(Guid id, string street, string number, string complement, string zipcode, AddressType type, Guid cityId, Guid stateId, Guid countryId, string owner, string ownerId, string typeDescription, string cityName, string stateName, string countryName, string district = "", AddressFunction function = AddressFunction.Common)
    {
        Id = id;
        Street = street;
        Number = number;
        Complement = complement;
        Zipcode = zipcode;
        Type = type;
        CityId = cityId;
        StateId = stateId;
        CountryId = countryId;
        Owner = owner;
        OwnerId = ownerId;
        TypeDescription = typeDescription;
        CityName = cityName;
        StateName = stateName;
        CountryName = countryName;
        District = district;
        Function = function;
    }

    public Guid? StateId { get; set; }
    public Guid? CountryId { get; set; }
    public string TypeDescription { get; set; }
    public string CityName { get; set; }
    public string StateName { get; set; }
    public string CountryName { get; set; }
}

public class CountryListViewModel
{
    public CountryListViewModel() { }
    public CountryListViewModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}
public class StateListViewModel
{
    public StateListViewModel(){ }
    public StateListViewModel(Guid id, string name, Guid countryId)
    {
      Id = id;
      Name = name;
      CountryId = countryId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CountryId { get; set; }
}
public class CityListViewModel
{
    public CityListViewModel() { }
    public CityListViewModel(Guid id, string name, Guid stateId)
    {
      Id = id;
      Name = name;
      StateId = stateId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid StateId { get; set; }
}