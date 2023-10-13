using JazaniT1.Application.Generals.Dtos.MeasureUnits;
using JazaniT1.Application.Generals.Dtos.PeriodTypes;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts;
using JazaniT1.Application.Mc.Dtos.InvestmentTypes;
using JazaniT1.Application.Mc.Dtos.MiningConcessions;
using JazaniT1.Application.Soc.Dtos.Holders;

namespace JazaniT1.Application.Mc.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public MiningConcessionSimpleDto MiningConcession { get; set; }
        public InvestmentTypeSimpleDto InvestmentType { get; set; }
        public PeriodTypeSimpleDto? PeriodType { get; set; }
        public MeasureUnitSimpleDto? MeasureUnit { get; set; }
        public HolderSimpleDto Holder { get; set; }
        public InvestmentConceptSimpleDto? InvestmentConcept { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}