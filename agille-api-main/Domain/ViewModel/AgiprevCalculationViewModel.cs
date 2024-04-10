using AgilleApi.Domain.Entities;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class AgiprevCalculationViewModel
{
    public string Year { get; set; }
    public string ShortYear { get => Year[2..]; }

    public string LogoBase64 { get; set; }
    public string EntityName { get; set; }
    public string EntityDocument { get; set; }

    public List<CalculationCompetenceViewModel> Competences { get; set; }
    public List<IntermediateLinesViewModel> IntermediateLines { get; set; }
}

public class IntermediateLinesViewModel
{
    public IntermediateLinesViewModel() { }
    public IntermediateLinesViewModel(string title)
    {
        Title = title;
        IsExpense = true;
        Competences = new();
    }

    public string Account { get; set; }
    public string Title { get; set; }
    public bool IsExpense { get; set; } //If false, the account is 'revenue'
    public string Year { get; set; }
    public List<IntermediateLinesMonthlyValues> Competences { get; set; }
}
public class IntermediateLinesMonthlyValues
{
    public IntermediateLinesMonthlyValues() { }
    public IntermediateLinesMonthlyValues(int month, decimal sumOfTheMonth)
    {
        Month = month;
        SumOfTheMonth = sumOfTheMonth;
    }

    public int Month { get; set; }
    public decimal SumOfTheMonth { get; set; }
}
public class CalculationCompetenceViewModel
{
    /**
     * ESSA CLASSE É RESPONSÁVEL POR UMA COLUNA DO PDF(OU SEJA, AS COMPETÊNCIAS JAN/AAAA, FEV/AAAA, MAR/AAAA, ETC).
     * esses comentários estão aqui pra facilitar o processo de compreensão dessa estrutura, já que ela é um pouco complexa.
     * Todavia todos devem ser apagados ao fim do desenvolvimento antes do merge com a develop.
     */

    public int Month { get; set; }

    // CINCO PRIMEIRAS LINHAS DA IMPRESSÃO
    public decimal CurrentRevenue { get; set; } // receita corrente
    public decimal CapitalRevenue { get; set; } // receita capital
    public decimal IntraBudgetRevenue { get; set; } // receita intra-orçamentária
    public decimal FundebDeductionAndRefunds { get; set; } // deduções fundeb e restituições (é negativo)
    public decimal TotalRevenue { get; set; } // Receita Total

    //LINHAS DE TOTAIS E CALCULOS FEITOS APARTE DOS DADOS DE DEDUÇÕES PASEP
    public decimal TotalIntermediateLines { get; set; } //(LINHA INTERNA não vai para o PDF) Total de Linhas Intermediárias
    public decimal SelicRate { get; set; } //(LINHA INTERNA não vai para o PDF) Taxa Selic
    public decimal TotalDeductionsFromTheCalculationBasis { get => TotalSum(); } //Total Deduções da Base de Cálculo
    public decimal BasisForPASEPCalculation { get => CalculateBasisForPASEPCalculation(); } //Base para Cálculo PASEP
    public decimal PASEPOnePercent { get => CalculatePASEPOnePercent(); } //PASEP 1%
    public decimal PASEPWithholdingsAtSource { get; set; } //Retenções PASEP na Fonte
    public decimal AmountToBeCollected { get => CalculateAmountToBeCollected(); } //Valor a Recolher
    public decimal AmountCollected { get; set; } //Valor Recolhido
    public string CollectionDate { get; set; } //Data Recolhimento
    public decimal AmountToArbitrate { get => CalculateAmountToArbitrate(); } //Valor à Arbitrar
    public decimal UpdateSelicToday { get => CalculateUpdateSelicToday(); } //Atualização Selic {Data de Hoje}

    public decimal TotalSum()
    {
        return TotalIntermediateLines;
    }
    public decimal CalculateBasisForPASEPCalculation()
    {
        return TotalRevenue - TotalDeductionsFromTheCalculationBasis;
    }
    public decimal CalculatePASEPOnePercent()
    {
        return BasisForPASEPCalculation * 0.01M;
    }
    public decimal CalculateAmountToBeCollected()
    {
        return PASEPOnePercent - PASEPWithholdingsAtSource;
    }
    private decimal CalculateAmountToArbitrate()
    {
        return AmountCollected - AmountToBeCollected;
    }
    private decimal CalculateUpdateSelicToday()
    {
        return AmountToArbitrate + (AmountToArbitrate * (SelicRate / 100));
    }
}
public class ParentAccountViewModel : IEqualityComparer<ParentAccountViewModel>
{
    public ParentAccountViewModel(string parentAccount, bool isExpense)
    {
        ParentAccount = parentAccount;
        IsExpense = isExpense;
    }

    public string ParentAccount { get; set; }
    public bool IsExpense { get; set; } //If false, the account is 'revenue'

    public bool Equals(ParentAccountViewModel x, ParentAccountViewModel y)
    {
        return x.ParentAccount == y.ParentAccount;
    }

    public int GetHashCode(ParentAccountViewModel obj)
    {
        return obj.ParentAccount.GetHashCode();
    }
}