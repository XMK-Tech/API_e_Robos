using AgilleApi.Data.ContextDb;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;

namespace AgilleApi.Data.Repository;

public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
{ 
    public ExpenseRepository(Context _context) : base(_context)
    {
    }
}

public class ExpenseAttachmentRepository : GenericRepository<ExpenseAttachment>, IExpenseAttachmentRepository
{
    public ExpenseAttachmentRepository(Context _context) : base(_context)
    {
    }
}