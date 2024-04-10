using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.ViewModel
{
    public class AgiprevCalculationMonthViewModel
    {
        public string LogoBase64 { get; set; }
        public string EntityName { get; set; }
        public string EntityDocument { get; set; }
        public List<PasapMonthBase> PasepWithholdingsAtSource { get; set; } //RETENÇÕES
        public decimal TotalPasepWithholdingsAtSource { get => PasepWithholdingsAtSource.Sum(x => x.Value); } //IV - TOTAL DAS RETENÇÕES
        public List<PasapMonthBase> CurrentRevenue { get; set; } //Receitas Correntes (Líquida de Deduções)
        public decimal TotalCurrentRevenue { get => CurrentRevenue.Sum(x => x.Value); } //Sub-Total (a)

        //Transferências de Convênio, Contrato de repasse ou instrumento congênere com objeto definido
        public decimal AgreementTransfers { get; set; }
        //Transferências a outras Entidades de Direito Público Interno
        public decimal TransfersToOtherEntities { get; set; }

        public decimal CapitalTransfers { get; set; } //Transferências de Capital
        public decimal TotalRevenue { get => TotalCurrentRevenue + CapitalTransfers; } //TOTAL DA RECEITA
        public decimal TotalRevenueExclusions { get => AgreementTransfers + TransfersToOtherEntities; } //TOTAL DAS EXCLUSÕES DA RECEITA (II)
        public decimal TotalNetIncome { get => TotalRevenue - TotalRevenueExclusions; } //TOTAL RECEITA LÍQUIDA
        public decimal OnePercentTotalNetIncome { get => TotalNetIncome / 100; } //TOTAL RECEITA LÍQUIDA
        public decimal CalculationResult { get => OnePercentTotalNetIncome - TotalPasepWithholdingsAtSource; } //TOTAL RECEITA LÍQUIDA
        public string Year { get; set; }
        public Month Month { get; set; }
    }
    public class PasapMonthBase
    {
        public PasapMonthBase() {}
        public PasapMonthBase(string title, decimal value)
        {
            Title = title;
            Value = value;
        }

        public string Title { get; set; }
        public decimal Value { get; set; }
    }
}
