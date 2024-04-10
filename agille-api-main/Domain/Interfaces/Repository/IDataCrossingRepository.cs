using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Interfaces.Repository
{
    public interface IDataCrossingRepository : IGenericRepository<DataCrossing>
    {
        void ExecuteAllPeding();
    }
}
