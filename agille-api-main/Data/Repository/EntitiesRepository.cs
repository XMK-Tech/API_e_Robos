using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Json;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Services.Commom;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgilleApi.Data.Repository;

public class EntitiesRepository : IEntitiesRepository
{
    private readonly MiddlewareClient _middlewareServices;
    public EntitiesRepository(MiddlewareClient middlewareServices)
    {
        _middlewareServices = middlewareServices;
    }

    public Entities Get(Guid id)
    {
        var response = _middlewareServices.Get(id);

        if (response == null)
            return null;

        var entity = new Entities(response.Content)
        {
            Name = response.Name,
            Document = response.Document,
            Address = response.Address,
            EntityImage = response.EntityImage,
        };

        return entity;
    }

    public void Update(Entities entity, Guid id)
    {
        _middlewareServices.Update(entity, id);
    }
}
