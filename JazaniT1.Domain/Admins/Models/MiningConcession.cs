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
        public bool State { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
