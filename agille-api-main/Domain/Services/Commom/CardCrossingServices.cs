using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class CardCrossingServices : ICardCrossingServices
{
    private readonly ICardCrossingReportRepository _repository;
    private readonly JuridicalPersonServices _juridicalPersonServices;
    private readonly TransactionEntryServices _transactionEntryServices;
    private readonly ManualEntryServices _manualEntryServices;
    private readonly CompanyCardRateServices _companyCardRateServices;
    private readonly MiddlewareClient _middleware;
    private readonly ICardDivergencyEntryRepository _cardDivergencyEntryRepository;
    private readonly INotificationServices _notificationServices;
    private readonly ISessionServices _sessionServices;

    public CardCrossingServices(JuridicalPersonServices juridicalPersonServices, TransactionEntryServices transactionEntryServices, ICardCrossingReportRepository reportRepository, CompanyCardRateServices companyCardRateServices, ICardDivergencyEntryRepository cardDivergencyEntryRepository, MiddlewareClient middleware, INotificationServices notificationServices, ManualEntryServices manualEntryServices, ISessionServices sessionServices)
    {
        _juridicalPersonServices = juridicalPersonServices;
        _transactionEntryServices = transactionEntryServices;
        _repository = reportRepository;
        _companyCardRateServices = companyCardRateServices;
        _cardDivergencyEntryRepository = cardDivergencyEntryRepository;
        _middleware = middleware;
        _notificationServices = notificationServices;
        _manualEntryServices = manualEntryServices;
        _sessionServices = sessionServices;
    }

    public IEnumerable<CardCrossingViewModel> ViewAll(Metadata meta)
    {
        var response = _repository
                        .ExecuteQuery(GetAll(), meta)
                        .OrderByDescending(e => e.CreatedAt)
                        .ToList();

        var userIds = response.Select(e => e.RequestedById.Value).ToList();
        var users = _middleware.GetUserInfos(userIds);

        return response.Select(item => ConvertReportToViewModel(item, users)).ToList();
    }

    public CardCrossingViewModel View(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity);

        return ConvertReportToViewModel(entity);
    }

    public SimpleCardCrossingReportViewModel MonthCreate(CardCrossingMonthInsertViewModel model)
    {
        var date = model.Reference;
        return Create(StartOfMonthInDate(date), EndOfMonthInDate(date));
    }
    
    public SimpleCardCrossingReportViewModel IntervalCreate(CardCrossingInsertIntervalViewModel interval)
    {
        if (!IsValidInterval(interval.StartingReference, interval.EndingReference))
            throw new BadRequestException("Invalid interval.");

        var start = interval.StartingReference;
        var end = interval.EndingReference;

        return Create(StartOfMonthInDate(start), EndOfMonthInDate(end));
    }

    private SimpleCardCrossingReportViewModel Create(DateTime startingReference, DateTime endingReference)
    {
        var userId = _sessionServices.GetCurrentSession()?.UserId;
        ThrowIfNull(userId, "Session");

        var report = new CardCrossingReport(startingReference, endingReference, userId);
        _repository.Insert(report);

        var divergencies = new List<CardDivergencyEntry>();

        var registeredOperators = _juridicalPersonServices.GetCardOperators().ToList();
        registeredOperators.ForEach(e => e.Document = e.Document.SanitazeDocument());

        var tradedOperators = _transactionEntryServices.GetOperators(startingReference, endingReference);
        var allOperators = registeredOperators.Select(e => e.Document).Union(tradedOperators).Distinct().ToList();

        var currentReference = startingReference;

        while (currentReference < endingReference)
        {
            allOperators.ForEach(item =>
            {
                var operatorName = registeredOperators.Where(e => e.Document == item).FirstOrDefault()?.Name;

                var response = OperatorDataInsert(item, currentReference, report.Id, operatorName);
                if (response != null)
                    divergencies.Add(response);
            });
            currentReference = currentReference.AddMonths(1);
        }

        if (divergencies.Any())
            _cardDivergencyEntryRepository.InsertMany(divergencies);

        _notificationServices.InsertMany(new NotificationInsertViewModel()
        {
            UserIds = new List<Guid>() { userId.Value },
            Title = "Cruzamento de dados das operadoras realizado com sucesso",
            Message = "Clique para verificar",
            Link = "",
            Priority = NotificationPriority.Normal,
        });

        return ConvertToViewModel(report, divergencies.Count);
    }

    private CardDivergencyEntry OperatorDataInsert(string operatorDocument, DateTime reference, Guid reportId, string operatorName)
    {
        if (string.IsNullOrEmpty(operatorDocument))
            return null;

        var startingReference = StartOfMonthInDate(reference);
        var endingReference = EndOfMonthInDate(reference);

        var transactions = GetTransactions(operatorDocument, startingReference, endingReference);
        if (!transactions.Any())
            return null;

        var amount = (decimal)transactions.Select(e => e.Amount).DefaultIfEmpty(0).Sum().Value;
        var count = transactions.Count();

        var averageRate = (decimal?)_companyCardRateServices.CardOperatorRateAverage(operatorDocument)?.Average ?? 0;

        var amountOnAveragetRate = ((amount / 100) * averageRate);
        var declaredRate = (decimal?)_companyCardRateServices.GetCompanyRateOfOperator(operatorDocument) ?? 0;
        var amountOnDeclaredRate = ((amount / 100) * declaredRate);

        var declaredTransacted = _manualEntryServices.DeclaredValue(operatorDocument, reference);
        var difference = amount - declaredTransacted;

        if (difference == 0)
            return null;

        return new CardDivergencyEntry(difference, operatorDocument, operatorName, reference, declaredTransacted, amount, reportId, count, averageRate, amountOnAveragetRate, declaredRate, amountOnDeclaredRate);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }

    private static DateTime StartOfMonthInDate(DateTime date) => new(date.Year, date.Month, 1);
    private static DateTime EndOfMonthInDate(DateTime date) => new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month), 23, 59, 59);

    private CardCrossingReport Get(Guid id)
    {
        return GetAll()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private IQueryable<CardCrossingReport> GetAll()
    {
        return _repository
                .Query()
                .Include(e => e.Divergencies);
    }

    private IEnumerable<TransactionViewModel> GetTransactions(string operatorDocument, DateTime startingReference, DateTime endingReference)
    {
        return _transactionEntryServices
            .FindByIntervalAndOperatorId(operatorDocument, startingReference, endingReference)
            .Where(e => !e.IsInvalid);
    }

    private static bool IsValidInterval(DateTime startingReference, DateTime endingReference)
    {
        return (startingReference < endingReference);
    }

    private static SimpleCardCrossingReportViewModel ConvertToViewModel(CardCrossingReport entity, int divergencyCount)
    {
        return new(entity.Id, entity.StartingReference, entity.EndingReference, divergencyCount);
    }

    private CardCrossingViewModel ConvertReportToViewModel(CardCrossingReport report, List<UserInfoViewModel> users = null)
    {
        UserInfoViewModel requester = null;

        if (users == null)
            requester = _middleware.GetUserInfos(new List<Guid> { report.RequestedById.Value }).FirstOrDefault();
        else
            requester = users.Where(e => e.UserId == report.RequestedById).FirstOrDefault();

        var divergencies = report.Divergencies.Select(ConvertDivergencyToViewModel).ToList();
        var hasInvalidDivergences = divergencies.Any(e => e.IsInvalid);

        return new(report.Id, divergencies, report.StartingReference, report.EndingReference, requester?.Fullname, hasInvalidDivergences);
    }

    private CardDivergencyEntryViewModel ConvertDivergencyToViewModel(CardDivergencyEntry entry)
    {
        return new(entry);
    }
}