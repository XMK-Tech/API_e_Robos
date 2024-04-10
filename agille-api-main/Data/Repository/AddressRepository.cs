using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Data.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly Context _con;

        public AddressRepository(Context con) : base(con)
        {
            _con = con;
        }

        public bool ExistsCity(Guid id)
        {
            try
            {
                return _con.Cities.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExistsCountry(Guid id)
        {
            try
            {
                return _con.Countries.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExistsState(Guid id)
        {
            try
            {
                return _con.States.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IQueryable<Country> QueryCountries()
        {
            return context.Countries.AsQueryable();
        }
        public IQueryable<City> QueryCities()
        {
            return context.Cities.AsQueryable();
        }
        public IQueryable<State> QueryStates()
        {
            return context.States.AsQueryable();
        }
        public virtual List<City> ExecuteCitiesQuery(IQueryable<City> query, Metadata metadata)
        {
            metadata.DataSize = query.Count();
            query = Pagination<City>.Get(metadata, query);
            return query.ToList();
        }
        public virtual List<State> ExecuteStatesQuery(IQueryable<State> query, Metadata metadata)
        {
            metadata.DataSize = query.Count();
            query = Pagination<State>.Get(metadata, query);
            return query.ToList();
        }
        public virtual List<Country> ExecuteCountriesQuery(IQueryable<Country> query, Metadata metadata)
        {
            metadata.DataSize = query.Count();
            query = Pagination<Country>.Get(metadata, query);
            return query.ToList();
        }
    }
}