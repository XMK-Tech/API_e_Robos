using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class AgiprevCalculationServices : IAgiprevCalculationServices
{
    private readonly IExpenseServices _expenseServices;
    private readonly IRevenueServices _revenueServices;
    private readonly IRubricServices _rubricServices;
    private readonly ICollectionServices _collectionServices;
    private readonly IFPMLaunchServices _fPMLaunchServices;
    private readonly IIndexServices _indexServices;
    private readonly IPDFGenerator _pdfServices;
    private readonly ILogosServices _logosServices;
    private readonly IEntitiesServices _entitiesServices;
    private List<IntermediateLinesViewModel> _globalIntermediateLines;

    public AgiprevCalculationServices(
        IExpenseServices expenseServices,
        IRevenueServices revenueServices,
        IRubricServices rubricServices,
        ICollectionServices collectionServices,
        IFPMLaunchServices fPMLaunchServices,
        IIndexServices indexServices,
        IPDFGenerator pdfServices,
        ILogosServices logosServices,
        IEntitiesServices entitiesServices)
    {
        _expenseServices = expenseServices;
        _revenueServices = revenueServices;
        _rubricServices = rubricServices;
        _collectionServices = collectionServices;
        _fPMLaunchServices = fPMLaunchServices;
        _indexServices = indexServices;
        _pdfServices = pdfServices;
        _logosServices = logosServices;
        _entitiesServices = entitiesServices;
        _globalIntermediateLines = new();
    }

    public ReportResponseViewModel Calculate(string year)
    {
        var accountsQuery = _rubricServices.GetQueryForYear(year);
        var expenseYearQuery = _expenseServices.GetQueryForYear(year);
        var revenueYearQuery = _revenueServices.GetQueryForYear(year);
        List<CalculationCompetenceViewModel> competences = new();

        var intermediateLines = GenerateMiddleLinesFromPDF(accountsQuery, expenseYearQuery, revenueYearQuery, year);
        for (int i = 1; i <= 12; i++)
        {
            var currenteCompetence = CalculateForCompetence(year, i, intermediateLines);
            competences.Add(currenteCompetence);
        }

        var entity = GetEntity();
        var img = _logosServices.GetUrlLogoInBase64(entity?.EntityImage);
        var entityName = entity?.Name;
        var entityDocument = entity?.Document;

        var reportData = new AgiprevCalculationViewModel()
        {
            Year = year,
            LogoBase64 = img,
            EntityName = entityName,
            EntityDocument = entityDocument,
            Competences = competences,
            IntermediateLines = intermediateLines
        };

        var bytes = _pdfServices.Generate(reportData, "Pasep", isLandscape: true).Result;
        return new()
        {
            Title = $"PASEP-EXERCICIO_DE_{year}.pdf",
            ContentType = "application/pdf",
            Content = bytes
        };
    }

    private CalculationCompetenceViewModel CalculateForCompetence(
        string year,
        int competence,
        List<IntermediateLinesViewModel> intermediateLines)
    {
        var competenceAsString = competence.ToString();

        var revenuesQuery = _revenueServices.GetQueryForCompetence(year, competenceAsString);
        var accountsQuery = _rubricServices.GetQueryForYear(year);
        var expenseQuery = _expenseServices.GetQueryForCompetence(year, competenceAsString);
        var collectionQuery = _collectionServices.GetQueryForCompetence(year, competenceAsString);
        var fPMLaunchQuery = _fPMLaunchServices.GetQueryForCompetence(year, competenceAsString);

        var currentRevenue = SumRevenueStartsWith(revenuesQuery, startsWith: "41");
        var capitalRevenue = SumRevenueStartsWith(revenuesQuery, startsWith: "42");
        var intraBudgetRevenue = SumRevenueStartsWith(revenuesQuery, startsWith: "47");
        var fundebDeductionAndRefunds = SumRevenueStartsWith(revenuesQuery, startsWith: "9");
        var totalRevenue = currentRevenue + capitalRevenue + intraBudgetRevenue + fundebDeductionAndRefunds;

        var pASEPWithholdingsAtSource = fPMLaunchQuery.Sum(x => x.Collected);
        var amountCollected = SumCollection(collectionQuery);
        var collectionDate = collectionQuery.FirstOrDefault()?.Payday.ToString("dd/MM/yyyy");
        var totalIntermediateLines = CalculateTotalIntermediateLines(intermediateLines, competence);
        var selicRate = _indexServices.GetSelicRate(year, competenceAsString);

        return new()
        {
            Month = competence,

            CurrentRevenue = currentRevenue,
            CapitalRevenue = capitalRevenue,
            IntraBudgetRevenue = intraBudgetRevenue,
            FundebDeductionAndRefunds = fundebDeductionAndRefunds,
            TotalRevenue = totalRevenue,

            PASEPWithholdingsAtSource = pASEPWithholdingsAtSource,
            AmountCollected = amountCollected,
            CollectionDate = collectionDate,
            TotalIntermediateLines = totalIntermediateLines,
            SelicRate = selicRate,
        };
    }
    public List<IntermediateLinesViewModel> GenerateMiddleLinesFromPDF(
        IQueryable<RubricAccount> accountsQuery,
        IQueryable<Expense> expenseYearQuery,
        IQueryable<Revenue> revenueYearQuery,
        string year)
    {
        if (!(_globalIntermediateLines?.Count > 0 && _globalIntermediateLines.First().Year == year))
        {
            //Obter contas Pai que possuem algum valor movimentado como despeça durante o Ano
            var accounts = accountsQuery.Where(x => x.Classifications == "Dedução").Select(x => x.Account).ToList();
            var parentAccounts = ManageAccounts.GetParentAccounts(accounts);
            var parentAccountsWithYearAmounts = new List<ParentAccountViewModel>();
            foreach (var account in parentAccounts)
            {
                decimal sumExpensesYear = 0;
                decimal sumRevenuesYear = SumRevenuesByBeginningOfAccount(accountsQuery, revenueYearQuery, account);
                if (sumRevenuesYear == 0)
                    sumExpensesYear = SumExpensesByBeginningOfAccount(accountsQuery, expenseYearQuery, account);
                if (sumExpensesYear > 0 || sumRevenuesYear > 0)
                {
                    bool isExpense = false;
                    if (sumExpensesYear > 0)
                        isExpense = true;
                    parentAccountsWithYearAmounts.Add(new(account, isExpense));
                }
            }

            if (parentAccountsWithYearAmounts == null || parentAccountsWithYearAmounts.Count == 0)
                return new();

            //Montar uma lista com os dados das linhas intermediarias, usando a lista de 'Contas pai com valores anuais'
            List<IntermediateLinesViewModel> intermediateLines = new();
            foreach (var item in parentAccountsWithYearAmounts)
            {
                IntermediateLinesViewModel intermediateLine = new();
                var account = item.ParentAccount;
                if (!item.IsExpense)
                    account = RemoveDigit4WhenStartingWith4(account);
                intermediateLine.Account = EqualizeTheNumberOfDigitsTo18Digits(account);

                var rubricAccounts = accountsQuery.Where(x => x.Account.StartsWith(item.ParentAccount)).ToList();
                intermediateLine.Title = GetTitleParentAccounts(rubricAccounts, item.ParentAccount).Title;

                List<IntermediateLinesMonthlyValues> competences = new();
                decimal sumOfTheMonth = 0;
                if (item.IsExpense)
                {
                    for (var i = 1; i <= 12; i++)
                    {
                        var expenseMonthQuery = expenseYearQuery.Where(revenue => revenue.Reference.Month.ToString() == i.ToString());
                        sumOfTheMonth = SumExpensesByBeginningOfAccount(accountsQuery, expenseMonthQuery, item.ParentAccount);

                        IntermediateLinesMonthlyValues competence = new(i, sumOfTheMonth);
                        competences.Add(competence);
                    }
                    intermediateLine.Competences = competences;
                }
                else
                {
                    for (var i = 1; i <= 12; i++)
                    {
                        var revenueMonthQuery = revenueYearQuery.Where(revenue => revenue.Reference.Month.ToString() == i.ToString());
                        sumOfTheMonth = SumRevenuesByBeginningOfAccount(accountsQuery, revenueMonthQuery, item.ParentAccount);

                        IntermediateLinesMonthlyValues competence = new(i, sumOfTheMonth);
                        competences.Add(competence);
                    }
                    intermediateLine.Competences = competences;
                }

                intermediateLine.IsExpense = item.IsExpense;
                intermediateLines.Add(intermediateLine);
            }

            //Remover linhas de Despesa (IsExpense = true) e substituir por uma unica linha com a soma das despesas por mês.
            IntermediateLinesViewModel intraBudgetExpense = CalculateIntraBudgetExpenses(expenseYearQuery, year, intermediateLines);
            intermediateLines = intermediateLines.Where(x => !x.IsExpense).ToList();
            intermediateLines.Add(intraBudgetExpense);

            intermediateLines = intermediateLines.OrderBy(x => x.IsExpense).ThenBy(x => x.Account).ToList();

            intermediateLines.ForEach(x => x.Year = year);
            _globalIntermediateLines = intermediateLines;
        }

        return _globalIntermediateLines;
    }

    private static IntermediateLinesViewModel CalculateIntraBudgetExpenses(
        IQueryable<Expense> expenseYearQuery,
        string year,
        List<IntermediateLinesViewModel> intermediateLines)
    {
        var intraBudgetExpense = new IntermediateLinesViewModel("Despesa Intra Orçamentária");
        if (Convert.ToInt32(year) < 2023)
        {
            CalculateIntraBudgetExpensesBefore2023(intermediateLines, intraBudgetExpense);
        }
        else
        {
            CalculateIntraBudgetExpensesAfter2023(expenseYearQuery, intraBudgetExpense);
        }

        return intraBudgetExpense;
    }

    private static void CalculateIntraBudgetExpensesAfter2023(IQueryable<Expense> expenseYearQuery, IntermediateLinesViewModel intraBudgetExpense)
    {
        for (var i = 1; i <= 12; i++)
        {
            var expenseQuery = expenseYearQuery
                .Where(expense => expense.Reference.Month.ToString() == i.ToString());
            var sumOfTheMonth = expenseQuery
                    .Where(e => e.Type == ExpenseType.Extra || e.Type == ExpenseType.Budgetary)
                    .Sum(e => e.Value);

            var competence = new IntermediateLinesMonthlyValues(i, sumOfTheMonth);
            intraBudgetExpense.Competences.Add(competence);
        }
    }

    private static void CalculateIntraBudgetExpensesBefore2023(List<IntermediateLinesViewModel> intermediateLines, IntermediateLinesViewModel intraBudgetExpense)
    {
        var intermediateLinesExpense = intermediateLines.Where(x => x.IsExpense);
        for (var i = 1; i <= 12; i++)
        {
            var sumOfTheMonth = intermediateLinesExpense
                .Select(x => x.Competences.First(c => c.Month == i).SumOfTheMonth)
                .Sum();
            var competence = new IntermediateLinesMonthlyValues(i, sumOfTheMonth);
            intraBudgetExpense.Competences.Add(competence);
        }
    }

    private static string RemoveDigit4WhenStartingWith4(string parentAccount)
    {
        //Remove digit 4 when starting with 4
        if (parentAccount.StartsWith("4"))
            parentAccount = parentAccount[1..];
        return parentAccount;
    }
    private static string EqualizeTheNumberOfDigitsTo18Digits(string parentAccount)
    {
        // Equalize the number of digits in the numbers in the final list
        string numberStr = parentAccount;
        while (numberStr.Length < 18)
        {
            numberStr += "0";
        }
        return numberStr;
    }
    public static RubricAccount GetTitleParentAccounts(List<RubricAccount> rubricAccounts, string parentAccounts)
    {
        var rubricAccount = rubricAccounts.FirstOrDefault(x => x.Account == parentAccounts);
        if (rubricAccount == null && parentAccounts.Length < 22)
        {
            parentAccounts += "0";
            rubricAccount = GetTitleParentAccounts(rubricAccounts, parentAccounts);
        }
        return rubricAccount;
    }
    private static decimal SumExpensesByBeginningOfAccount(
        IQueryable<RubricAccount> accountsQuery,
        IQueryable<Expense> expensesQuery,
        string beginningOfAccount,
        bool ignoreFistAccountNumber = false)
    {
        var accounts = accountsQuery
                        .Where(e => e.Account.StartsWith(beginningOfAccount))
                        .Select(e => e.Account)
                        .ToList();

        if (ignoreFistAccountNumber)
            accounts = accounts.Select(e => e[1..]).ToList();

        var expenses = expensesQuery
                        .ToList()
                        .Where(e => accounts.Any(f => e.Description.ToLower().Contains(f)))
                        .Select(e => e.Value)
                        .ToList();

        var sum = expenses.Sum();
        return (sum != 0 || ignoreFistAccountNumber) ? sum : SumExpensesByBeginningOfAccount(accountsQuery, expensesQuery, beginningOfAccount, true);
    }
    private static decimal SumRevenuesByBeginningOfAccount(
        IQueryable<RubricAccount> accountsQuery,
        IQueryable<Revenue> revenuesQuery,
        string beginningOfAccount,
        bool ignoreFistAccountNumber = false)
    {
        var accounts = accountsQuery
                        .Where(e => e.Account.StartsWith(beginningOfAccount))
                        .Select(e => e.Account)
                        .ToList();

        if (ignoreFistAccountNumber)
            accounts = accounts.Select(e => e[1..]).ToList();

        var expenses = revenuesQuery
                        .ToList()
                        .Where(e => accounts.Any(f => e.Account.ToLower().Contains(f)))
                        .Select(e => e.EffectedValue)
                        .ToList();

        var sum = expenses.Sum();
        return (sum != 0 || ignoreFistAccountNumber) ? sum : SumRevenuesByBeginningOfAccount(accountsQuery, revenuesQuery, beginningOfAccount, true);
    }

    private static decimal SumCollection(IQueryable<Collection> collectionQuery)
    {
        return collectionQuery.Sum(x => x.PasepValue);
    }
    private static decimal CalculateTotalIntermediateLines(List<IntermediateLinesViewModel> intermediateLines, int competence)
    {
        var totalIntermediateLines = intermediateLines
            .SelectMany(x => x.Competences.Where(x => x.Month == competence))
            .Sum(x => x.SumOfTheMonth);
        return totalIntermediateLines;
    }

    private static decimal SumRevenueStartsWith(IQueryable<Revenue> revenuesQuery, string startsWith)
    {
        return revenuesQuery
                .Where(e => e.Account.StartsWith(startsWith))
                .Sum(rev => rev.EffectedValue);
    }
    private static decimal SumExpensesWithFlags(
        IQueryable<RubricAccount> accountsQuery,
        IQueryable<Expense> expensesQuery,
        bool ignoreFistAccountNumber,
        params string[] flags)
    {
        var sanitizedFlags = flags.Select(e => e.ToLower()).ToList();

        var accounts = accountsQuery
                        .Where(e => sanitizedFlags.Contains(e.Title.ToLower()))
                        .Select(e => e.Account)
                        .ToList();

        if (ignoreFistAccountNumber)
            accounts = accounts.Select(e => e[1..]).ToList();

        var expenses = expensesQuery
                        .ToList()
                        .Where(e => accounts.Any(f => e.Description.ToLower().Contains(f)))
                        .Select(e => e.Value)
                        .ToList();

        var sum = expenses.Sum();

        return (sum != 0 || ignoreFistAccountNumber) ? sum : SumExpensesWithFlags(accountsQuery, expensesQuery, true, flags);
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
    public decimal CalculateAmountToArbitrate(string year, string month)
    {
        var competence = Convert.ToInt32(month);
        var competenceAsString = competence.ToString();

        var revenuesQuery = _revenueServices.GetQueryForCompetence(year, competenceAsString);
        var accountsQuery = _rubricServices.GetQueryForYear(year);
        var expenseYearQuery = _expenseServices.GetQueryForYear(year);
        var revenueYearQuery = _revenueServices.GetQueryForYear(year);
        var collectionQuery = _collectionServices.GetQueryForCompetence(year, competenceAsString);

        var intermediateLines = GenerateMiddleLinesFromPDF(accountsQuery, expenseYearQuery, revenueYearQuery, year);
        var totalIntermediateLines = CalculateTotalIntermediateLines(intermediateLines, Convert.ToInt32(competence));

        var currentRevenue = SumRevenueStartsWith(revenuesQuery, startsWith: "41");
        var capitalRevenue = SumRevenueStartsWith(revenuesQuery, startsWith: "42");
        var intraBudgetRevenue = SumRevenueStartsWith(revenuesQuery, startsWith: "47");
        var fundebDeductionAndRefunds = SumRevenueStartsWith(revenuesQuery, startsWith: "9");
        var totalRevenue = currentRevenue + capitalRevenue + intraBudgetRevenue + fundebDeductionAndRefunds;


        var basisForPASEPCalculation = totalRevenue - totalIntermediateLines;

        var pASEPOnePercent = basisForPASEPCalculation * 0.01M;

        var fPMLaunchQuery = _fPMLaunchServices.GetQueryForCompetence(year, competenceAsString);
        var pASEPWithHoldingsAtSource = fPMLaunchQuery.Sum(x => x.Collected);

        var amountToBeCollected = pASEPOnePercent - pASEPWithHoldingsAtSource;

        var amountCollected = SumCollection(collectionQuery);

        return amountCollected - amountToBeCollected;
    }
}