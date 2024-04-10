using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Data.Repository
{
  public class InvoiceEntryRepository : GenericRepository<InvoiceEntry>, IInvoiceEntryRepository
  {
    public InvoiceEntryRepository(Context context) : base(context)
    {
    }
  }
}
