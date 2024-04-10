using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgilleApi.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        List<AddressViewModel> GetAddressByOwner(Guid id);
        string GetStateByCityName(string city);
    }
}
