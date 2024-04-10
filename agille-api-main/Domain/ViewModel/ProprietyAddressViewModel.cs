using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public class ProprietyAddressViewModel
{
    public ProprietyAddressViewModel() { }
    public ProprietyAddressViewModel(ProprietyAddress proprietyAddress) 
    { 
        PostalCode = proprietyAddress.PostalCode;
        Id = proprietyAddress.Id;

        var baseAddress = proprietyAddress.Address;
        if (baseAddress != null)
        {
            Street = baseAddress.Street;
            Number = baseAddress.Number;
            District = baseAddress.District;
            Complement = baseAddress.Complement;
            Zipcode = baseAddress.ZipCode;
            Type = baseAddress.Type;

            var city = baseAddress.City;

            CityId = city?.Id;
            CityName = city?.Name;
            StateId = city?.StateId;
            StateName = city?.State?.Name;
        }
    }

    public Guid Id { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string District { get; set; }
    public string Complement { get; set; }
    public string Zipcode { get; set; }
    public AddressType Type { get; set; }
    public Guid? CityId { get; set; }
    public string CityName { get; set; }
    public Guid? StateId { get; set; }
    public string StateName { get; set; }

    public string PostalCode { get; set; }
}
