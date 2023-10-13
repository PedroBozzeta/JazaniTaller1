using System.ComponentModel.DataAnnotations;

namespace JazaniT1.Application.Generals.Dtos.MeasureUnits
{
    public class MeasureUnitSaveDto
    {
        public string Name { get; set; } = default;

        [MaxLength(5, ErrorMessage = "La longitud máxima de Symbol es de 5 caracteres.")]
        public string Symbol { get; set; } = default;
        public string? Description { get; set; }
    }
}
