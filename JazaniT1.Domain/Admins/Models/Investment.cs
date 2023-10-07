namespace JazaniT1.Domain.Admins.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; } =0;
        public int MiningConcessionId { get; set; }
        public int InvestmentConceptId { get; set; }
        public int InvestmentTypeId { get; set; }
        public int PeriodTypeId { get; set; }
        public int MeasureUnitId { get; set; }
        public int HolderId { get; set; }
        public string? Description { get; set; }
        public int? Year{ get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual Holder Holder { get; set; }
        public virtual InvestmentConcept InvestmentConcept { get; set; }
        public virtual InvestmentType InvestmentType { get; set; }
        public virtual MiningConcession MiningConcession { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }
        public virtual PeriodType PeriodType { get; set; }

    }
}
