using AgilleApi.Domain.Interfaces.Json;
using System;

namespace AgilleApi.Domain.Interfaces.Repository
{
    public interface IEntitiesRepository
    {
        Entities.Entities Get(Guid id);
        void Update(Entities.Entities entity, Guid id);
    }
}
