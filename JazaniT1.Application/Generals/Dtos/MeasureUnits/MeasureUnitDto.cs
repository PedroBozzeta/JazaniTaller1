using System.ComponentModel.DataAnnotations;

namespace JazaniT1.Application.Generals.Dtos.MeasureUnits
{
    public class MeasureUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string? Description { get; set; }

        [MaxLength(5, ErrorMessage = "La longitud máxima de Symbol es de 5 caracteres.")]
        public string Symbol { get; set; } = default;
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
