using System.ComponentModel.DataAnnotations;

namespace JazaniT1.Application.Admins.Dtos.MiningConcessions
{
    public class MiningConcessionSaveDto
    {
        [MaxLength(11)]
        public string Code { get; set; } = default;
        public string? Name { get; set; } = default;
        public string? Description { get; set; }
    }
}
