using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class JuridicalPersonRepository : GenericRepository<JuridicalPersonBase>, IJuridicalPersonRepository
    {
        private readonly Context _con;

        public JuridicalPersonRepository(Context con) : base(con)
        {
            _con = con;
        }
    }
}
