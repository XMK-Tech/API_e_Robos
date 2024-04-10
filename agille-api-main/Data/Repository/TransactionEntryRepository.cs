using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Data.Repository
{
  public class TransactionEntryRepository : GenericRepository<TransactionEntry>, ITransactionEntryRepository
  {
    public TransactionEntryRepository(Context context) : base(context)
    {
    }
  }
}
