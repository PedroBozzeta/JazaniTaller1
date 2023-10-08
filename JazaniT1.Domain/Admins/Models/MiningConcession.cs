using System.ComponentModel.DataAnnotations;

namespace JazaniT1.Domain.Admins.Models
{
    public class MiningConcession
    {
        public int Id { get; set; }

        [MaxLength(11)]
        public string Code { get; set; } = default;
        public string? Name { get; set; } = default;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int MineralTypeId { get; set; } = 1;
        public int OriginId { get; set; } = 1;
        public int TypeId { get; set; } = 1;
        public int SituationId { get; set; } = 1;
        public int MiningUnitId { get; set; } = 1;
        public int ConditionId { get; set; } = 1;
        public int StateManagementId { get; set; } = 1;
        public bool State { get; set; }
        public bool IsSincronized { get; set; } 
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
