namespace JazaniT1.Domain.Admins.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; } =0;
        public string? Description { get; set; }
        public int? Year{ get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual Holder Holders { get; set; }
        public virtual InvestmentConcept InvestmentConcepts { get; set; }
        public virtual InvestmentType InvestmentTypes { get; set; }
        public virtual MiningConcession MiningConcessions { get; set; }
        public virtual PeriodType PeriodTypes { get; set; }

    }
}
