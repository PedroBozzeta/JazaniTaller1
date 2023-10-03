using System.ComponentModel.DataAnnotations;

namespace JazaniT1.Domain.Admins.Models
{
    public class MeasureUnit
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string? Description { get; set; }

        [MaxLength(5)]
        public string Symbol { get; set; } = default;
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
