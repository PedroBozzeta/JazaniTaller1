using JazaniT1.Domain.Cores.Models;

namespace JazaniT1.Domain.Admins.Models
{
    public class InvestmentConcept: CoreModel<int> 
    { 
        public string? Name { get; set; } = default;
        public string? Description { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
