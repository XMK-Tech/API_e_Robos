using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class PersonRepository : GenericRepository<PersonBase>, IPersonRepository
    {
        public PersonRepository(Context con) : base(con)
        {
        }
    }
}
