using AgilleApi.Domain.Entities;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Interfaces.Services;

public interface IExpenseServices
{
    void AttachFile(Guid expenseId, ExpenseAttachmentInsertUpdateViewModel model);
    FilterSumViewModel GetFilterSum(ExpenseParams @params);
    IEnumerable<ExpenseViewModel> List(Metadata meta, ExpenseParams @params);
    ExpenseViewModel View(Guid id);
    void Insert(ExpenseInsertUpdateViewModel model);
    void Update(Guid id, ExpenseInsertUpdateViewModel model);
    IQueryable<Expense> GetQueryForYear(string year);
    IQueryable<Expense> GetQueryForCompetence(string year, string month);
    void Delete(Guid id);
    ReportResponseViewModel GeneratePDFReport(Metadata meta, ExpenseParams @params);
    ReportResponseViewModel GenerateCSVReport(Metadata meta, ExpenseParams @params);
    void ImportFromCrawler(AgiprevImportParams @params);
}