using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class AgiprevCalculationMonthServices : IAgiprevCalculationMonthServices
{
    private readonly IPDFGenerator _pdfServices;
    private readonly IFPMLaunchServices _fPMLaunchServices;
    private readonly IRevenueServices _revenueServices;
    private readonly ILogosServices _logosServices;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IRubricServices _rubricServices;
    private readonly IExpenseServices _expenseServices;

    public AgiprevCalculationMonthServices(
        IPDFGenerator pdfServices,
        IFPMLaunchServices fPMLaunchServices,
        IRevenueServices revenueServices,
        ILogosServices logosServices,
        IEntitiesServices entitiesServices,
        IRubricServices rubricServices,
        IExpenseServices expenseServices)
    {
        _pdfServices = pdfServices;
        _fPMLaunchServices = fPMLaunchServices;
        _revenueServices = revenueServices;
        _logosServices = logosServices;
        _entitiesServices = entitiesServices;
        _rubricServices = rubricServices;
        _expenseServices = expenseServices;
    }

    public ReportResponseViewModel Calculate(string year, int month)
    {
        var stringMonth = month.ToString();
        var revenuesQuery = _revenueServices.GetQueryForCompetence(year, stringMonth);
        var accountsQuery = _rubricServices.GetQueryForYear(year);
        var expenseQuery = _expenseServices.GetQueryForCompetence(year, stringMonth);

        var pASEPWithholdingsAtSource = CalculatePasepWithholdingsAtSource(year, stringMonth);
        var currentRevenue = CalculateCurrentRevenue(revenuesQuery);
        var capitalTransfers = CalculateCapitalTransfers(revenuesQuery);
        var agreementTransfers = CalculateAgreementTransfers(accountsQuery, revenuesQuery);
        var transfersToOtherEntities = CalculateTransfersToOtherEntities(expenseQuery);


        var entity = GetEntity();
        var img = _logosServices.GetUrlLogoInBase64(entity?.EntityImage);
        var entityName = entity?.Name;
        var entityDocument = entity?.Document;

        var reportData = new AgiprevCalculationMonthViewModel()
        {
            Year = year,
            Month = (Month)month,
            PasepWithholdingsAtSource = pASEPWithholdingsAtSource,
            CurrentRevenue = currentRevenue,
            CapitalTransfers = capitalTransfers,
            AgreementTransfers = agreementTransfers,
            TransfersToOtherEntities = transfersToOtherEntities,
            LogoBase64 = img,
            EntityName = entityName,
            EntityDocument = entityDocument,
        };

        var bytes = _pdfServices.Generate(reportData, "PasepMonth").Result;
        stringMonth = month > 9 ? $"0{month}" : month.ToString();
        return new()
        {
            Title = $"PASEP-EXERCICIO_DE_{year}_{stringMonth}.pdf",
            ContentType = "application/pdf",
            Content = bytes
        };
    }

    private List<PasapMonthBase> CalculatePasepWithholdingsAtSource(string year, string month)
    {
        var fPMLaunchQuery = _fPMLaunchServices.GetQueryForCompetence(year, month);
        var pasapMonthList = fPMLaunchQuery
            .Select(x =>
                new PasapMonthBase(x.Description, x.Collected))
            .ToList();
        List<PasapMonthBase> pasepWithholdingsAtSource = new();
        foreach (var pasapMonth in pasapMonthList)
        {
            if (!pasepWithholdingsAtSource.Any(x => x.Title[..3] == pasapMonth.Title[..3] && x.Value == pasapMonth.Value))
            {
                var item = pasepWithholdingsAtSource.FirstOrDefault(x => x.Title[..3] == pasapMonth.Title[..3]);
                if (item != null)
                    item.Value += pasapMonth.Value;
                else
                    pasepWithholdingsAtSource.Add(pasapMonth);
            }
        }
        pasepWithholdingsAtSource = pasepWithholdingsAtSource.OrderByDescending(x => x.Value).ToList();
        return pasepWithholdingsAtSource;
    }

    private static decimal CalculateCapitalTransfers(IQueryable<Revenue> revenuesQuery)
    {
        return SumRevenueStartsWith(revenuesQuery, "424");
    }
    private static List<PasapMonthBase> CalculateCurrentRevenue(IQueryable<Revenue> revenuesQuery)
    {
        var results = new List<PasapMonthBase>()
        {
            new PasapMonthBase("1100000000000000000 - Receita Tributárias", SumRevenueStartsWith4(revenuesQuery, "11")),
            new PasapMonthBase("1200000000000000000 - Receita de Contribuições", SumRevenueStartsWith4(revenuesQuery, "12")),
            new PasapMonthBase("1300000000000000000 - Receita Patrimonial", SumRevenueStartsWith4(revenuesQuery, "13")),
            new PasapMonthBase("1400000000000000000 - Receita Agropecuária", SumRevenueStartsWith4(revenuesQuery, "14")),
            new PasapMonthBase("1500000000000000000 - Receita Industrial", SumRevenueStartsWith4(revenuesQuery, "15")),
            new PasapMonthBase("1600000000000000000 - Receita de Serviços", SumRevenueStartsWith4(revenuesQuery, "16")),
            new PasapMonthBase("1700000000000000000 - Transferências Correntes", SumRevenueStartsWith4(revenuesQuery, "17")),
            new PasapMonthBase("1900000000000000000 - Outras Receitas correntes", SumRevenueStartsWith4(revenuesQuery, "19")),
        };
        return results;
    }

    private static decimal CalculateAgreementTransfers(
        IQueryable<RubricAccount> accountsQuery,
        IQueryable<Revenue> revenuesQuery)
    {
        var accounts = accountsQuery
            .Where(x => x.Classifications == "Dedução")
            .Where(x => x.Account.StartsWith("41724") || x.Account.StartsWith("4224"))
            .Select(x => x.Account)
            .ToList();

        var sumRevenues = revenuesQuery
                        .ToList()
                        .Where(e => accounts.Any(f => e.Account.Contains(f)))
                        .Sum(e => e.EffectedValue);

        return sumRevenues;
    }
    private static decimal CalculateTransfersToOtherEntities(IQueryable<Expense> expenseQuery)
    {
        var sumExpenses = expenseQuery
                        .Where(e => e.Type == ExpenseType.Extra || e.Type == ExpenseType.Budgetary)
                        .Sum(e => e.Value);
        return sumExpenses;
    }

    private static decimal SumRevenueStartsWith4(IQueryable<Revenue> revenuesQuery, string startsWith)
    {
        var revenueStartWith4 = SumRevenueStartsWith(revenuesQuery, $"4{startsWith}");
        var revenueStartWith9 = SumRevenueStartsWith(revenuesQuery, $"9{startsWith}");

        decimal result;
        if (revenueStartWith9 < 0)
            result = revenueStartWith4 + revenueStartWith9;
        else
            result = revenueStartWith4 - revenueStartWith9;
        return result;
    }
    private static decimal SumRevenueStartsWith(IQueryable<Revenue> revenuesQuery, string startsWith)
    {
        return revenuesQuery
                .Where(e => e.Account.StartsWith(startsWith))
                .Sum(rev => rev.EffectedValue);
    }

    private EntitiesViewModel GetEntity()
    {
        EntitiesViewModel entity = null;
        try
        {
            entity = _entitiesServices.View();
            return entity;
        }
        catch
        {
            return entity;
        }
    }
}
