using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class CardCrossingReportRepository : GenericRepository<CardCrossingReport>, ICardCrossingReportRepository
{
    public CardCrossingReportRepository(Context _context) : base(_context)
    {
    }
}
