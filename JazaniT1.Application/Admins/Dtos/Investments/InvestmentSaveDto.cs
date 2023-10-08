namespace JazaniT1.Application.Admins.Dtos.Investments
{
    public class InvestmentSaveDto
    {
        public decimal AmountInvestd { get; set; } = 0;
        public string? Description { get; set; }
        public int MiningConcessionId { get; set; }
        public int? InvestmentConceptId { get; set; }
        public int InvestmentTypeId { get; set; } = 1;
        public int? PeriodTypeId { get; set; } = 1;
        public int? MeasureUnitId { get; set; }
        public int HolderId { get; set; } = 3;
        public int? Year { get; set; }
    }
}
