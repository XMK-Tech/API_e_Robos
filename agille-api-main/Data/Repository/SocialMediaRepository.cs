using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository
{
    public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
    {
        private readonly Context _con;

        public SocialMediaRepository(Context con) : base(con)
        {
            _con = con;
        }
    }
}
