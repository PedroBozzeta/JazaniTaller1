using JazaniT1.Application.Admins.Dtos.Holders;
using JazaniT1.Application.Admins.Dtos.InvestmentConcepts;
using JazaniT1.Application.Admins.Dtos.InvestmentTypes;
using JazaniT1.Application.Admins.Dtos.MeasureUnits;
using JazaniT1.Application.Admins.Dtos.MiningConcessions;
using JazaniT1.Application.Admins.Dtos.PeriodTypes;

namespace JazaniT1.Application.Admins.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public MiningConcessionSimpleDto MiningConcession{ get; set; }
        public InvestmentTypeSimpleDto InvestmentType { get; set; }
        public PeriodTypeSimpleDto? PeriodType { get; set; }
        public MeasureUnitSimpleDto? MeasureUnit { get; set; }
        public HolderSimpleDto Holder { get; set; }
        public InvestmentConceptSimpleDto? InvestmentConcept { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}