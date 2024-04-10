using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class JuridicalPersonServiceTypeDescriptionRepository : GenericRepository<JuridicalPersonServiceTypeDescription>, IJuridicalPersonServiceTypeDescriptionRepository
{
    public JuridicalPersonServiceTypeDescriptionRepository(Context _context) : base(_context)
    {
    }
}