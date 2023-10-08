using JazaniT1.Application.Admins.Dtos.MiningConcessions;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Admins.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; } = 0;
        public string? Description { get; set; }
        public MiningConcessionSaveDto MiningConcession{ get; set; }
        public InvestmentConcept InvestmentConcept { get; set; }
        public InvestmentType InvestmentType { get; set; }
        public PeriodType PeriodType { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
        public Holder Holder { get; set; }
        public int? Year { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}