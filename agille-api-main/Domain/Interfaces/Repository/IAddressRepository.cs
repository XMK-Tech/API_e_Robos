using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Interfaces.Repository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        bool ExistsCity(Guid id);
        bool ExistsState(Guid id);
        bool ExistsCountry(Guid id);
        IQueryable<Country> QueryCountries();
        IQueryable<State> QueryStates();
        IQueryable<City> QueryCities();
        List<City> ExecuteCitiesQuery(IQueryable<City> query, Metadata metadata);
        List<State> ExecuteStatesQuery(IQueryable<State> query, Metadata metadata);
        List<Country> ExecuteCountriesQuery(IQueryable<Country> query, Metadata metadata);
    }
}