using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Domain.Services.Commom;

public class TransactionEntryServices : ProcessFileServices<TransactionEntry>
{
    private readonly DataCrossingServices _dataCrossingServices;
    private readonly ICardCrossingReportRepository _cardCrossingReportRepository;

    public TransactionEntryServices(IGenericRepository<TransactionEntry> repository, IImportParser<TransactionEntry> parser, IImportFileReplacementServices importFileServices, IInvalidateDivergenciesServices invalidateDivergenciesServices, DataCrossingServices dataCrossingServices, ICardCrossingReportRepository cardCrossingReportRepository) 
        : base(repository, parser, importFileServices, invalidateDivergenciesServices)
    {
        _dataCrossingServices = dataCrossingServices;
        _cardCrossingReportRepository = cardCrossingReportRepository;
    }

    public IEnumerable<TransactionViewModel> FindByIntervalAndOperatorId(string operatorDocument, DateTime startingReference, DateTime endingReference)
    {
        var result = _repository
                .Query()
                .Include(e => e.ImportFile)
                .Where(e => e.ReferenceDate >= startingReference && e.ReferenceDate <= endingReference)
                .Where(e => e.CardOperatorDocument.Replace(".", "").Replace("/", "").Replace("-", "") == operatorDocument.Replace(".", "").Replace("/", "").Replace("-", ""))
                .Select(ConvertTransactionToViewModel);

        return result;
    }

    public List<string> GetOperators(DateTime startingReference, DateTime endingReference)
    {
        return _repository
                .Query()
                .Where(e => e.ReferenceDate >= startingReference && e.ReferenceDate <= endingReference)
                .Select(e => e.CardOperatorDocument)
                .Distinct()
                .ToList();
    }
    public BaseInterval GetCardCrossInterval(Guid id)
{
    var data = _cardCrossingReportRepository.GetById(id);
    if (data == null)
        return null;

    return new BaseInterval() { StartingReference = data.StartingReference, EndingReference = data.EndingReference };
}
    public IEnumerable<TransactionViewModel> FindTransactions(TransactionParams transactionParams, Metadata metadata)
    {
        var interval = _dataCrossingServices
                        .GetDataCrossInterval(transactionParams.DataCrossId) ??
                         GetCardCrossInterval(transactionParams.DataCrossId);
        
        if (interval == null)
            throw new BadRequestException("O identificador do cruzamento de dados é inválido.");

        var query = _repository
                .Query()
                .Include(e => e.ImportFile)
                .Where(e => e.ReferenceDate >= interval.StartingReference && e.ReferenceDate <= interval.EndingReference)
                .Where(e => e.Document == transactionParams.Document || e.CardOperatorDocument == transactionParams.CardOperatorDocument);

        var result = _repository.ExecuteQuery(query, metadata).Select(ConvertTransactionToViewModel).ToList();

        return result;
    }

    public TransactionsDataViewModel<TransactionsCountVieModel> GetTransactionsCount(BaseInterval model)
    {
        ValidateInterval(model);

        var transactions = GetInterval(model.StartingReference, model.EndingReference).OrderBy(e => e.CreatedAt);
        var transactionGroups = transactions.GroupBy(e => new { e.CreatedAt.Year, e.CreatedAt.Month });

        List<TransactionsCountVieModel> groupsData = new List<TransactionsCountVieModel>();
        foreach (var group in transactionGroups)
        {
            var key = group.Key;
            var monthName = group.FirstOrDefault()?.CreatedAt.ToString(@"MMMM", new CultureInfo("PT-pt"));

            var creditCardCount = group.Where(e => e.TransactionType == Enums.TransactionEntryType.CREDIT).Count();
            var debitCardCount = group.Where(e => e.TransactionType == Enums.TransactionEntryType.DEBIT).Count();

            groupsData.Add(new TransactionsCountVieModel(key.Year.ToString(), key.Month, monthName, creditCardCount, debitCardCount));
        }

        return new TransactionsDataViewModel<TransactionsCountVieModel>(model.StartingReference, model.EndingReference, transactions.Count(), groupsData);
    }

    public decimal ValueTransacted(string document, DateTime? startingReference = null, DateTime? endingReference = null)
    {
        var query = _repository
                     .Query()
                     .Where(e => e.Document == document);

        if (startingReference.HasValue && endingReference.HasValue)
            query = query
                    .Where(e => e.ReferenceDate >= startingReference && e.ReferenceDate <= endingReference);

        return query.Select(e => e.Value).ToList().DefaultIfEmpty(0).Sum();
    }

    public TransactionsDataViewModel<TransactionsTotalViewModel> GetTransactionsTotal(BaseInterval model)
    {
        ValidateInterval(model);

        var transactions = GetInterval(model.StartingReference, model.EndingReference).OrderBy(e => e.CreatedAt);
        var transactionGroups = transactions.GroupBy(e => new { e.CreatedAt.Year, e.CreatedAt.Month });

        List<TransactionsTotalViewModel> groupsData = new List<TransactionsTotalViewModel>();
        foreach (var group in transactionGroups)
        {
            var key = group.Key;
            var monthName = group.FirstOrDefault()?.CreatedAt.ToString(@"MMMM", new CultureInfo("PT-pt"));

            var creditCardTotal = group.Where(e => e.TransactionType == Enums.TransactionEntryType.CREDIT).Sum(e => e.Value);
            var debitCardTotal = group.Where(e => e.TransactionType == Enums.TransactionEntryType.DEBIT).Sum(e => e.Value);

            groupsData.Add(new TransactionsTotalViewModel(key.Year.ToString(), key.Month, monthName, creditCardTotal, debitCardTotal));
        }

        return new TransactionsDataViewModel<TransactionsTotalViewModel>(model.StartingReference, model.EndingReference, transactions.Count(), groupsData);
    }

    private static void ValidateInterval(BaseInterval model)
    {
        if (model.StartingReference > model.EndingReference)
            throw new BadRequestException("A data final não pode ser anterior a data inicial!");
    }

    private IEnumerable<TransactionEntry> GetInterval(DateTime startingReference, DateTime endingReference)
    {
        return _repository.Query()
                .Where(e => e.ReferenceDate >= startingReference && e.ReferenceDate <= endingReference)
                .ToList();
    }

    private static TransactionViewModel ConvertTransactionToViewModel(TransactionEntry transaction)
    {
        var paymentMethod = (transaction.TransactionType == Enums.TransactionEntryType.DEBIT) ? "Débito" : "Crédito";
        var type = "Despesa";

        return new TransactionViewModel(
            transaction.Id,
            type,
            transaction.ReferenceDate,
            "",
            paymentMethod,
            null,
            null,
            (float)transaction.Value,
            transaction.CardOperatorDocument)
        {
            IsInvalid = transaction.IsInvalid,
        };
    }
}