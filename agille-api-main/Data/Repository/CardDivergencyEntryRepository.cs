using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class CardDivergencyEntryRepository : GenericRepository<CardDivergencyEntry>, ICardDivergencyEntryRepository
{
    public CardDivergencyEntryRepository(Context _context) : base(_context)
    {
    }
}