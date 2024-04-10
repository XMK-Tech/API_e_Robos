using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.Interfaces.Repository;

public interface IExpenseRepository : IGenericRepository<Expense>
{ }

public interface IExpenseAttachmentRepository : IGenericRepository<ExpenseAttachment>
{ }