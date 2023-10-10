using JazaniT1.Domain.Cores.Models;

namespace JazaniT1.Domain.Admins.Models
{
    public class Investment: CoreModel<int>
    {
        public decimal AmountInvestd { get; set; } =0;
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int MiningConcessionId { get; set; } = 15;
        public int InvestmentTypeId { get; set; } = 1;
        public int CurrencyTypeId { get; set; } = 0;
        public int? PeriodTypeId { get; set; } = null;
        public int? MeasureUnitId { get; set; }
        public int HolderId { get; set; } = 3;
        public int DeclaredTypeId { get; set; } = 0;
        public int? InvestmentConceptId { get; set; }
        public virtual MiningConcession MiningConcession { get; set; }
        public virtual InvestmentType InvestmentType { get; set; }
        public virtual PeriodType PeriodType { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }
        public virtual Holder Holder { get; set; }
        public virtual InvestmentConcept InvestmentConcept { get; set; }

    }
}
