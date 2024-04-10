using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        private readonly Context _con;

        public EmailRepository(Context con) : base(con)
        {
            _con = con;
        }
    }
}
