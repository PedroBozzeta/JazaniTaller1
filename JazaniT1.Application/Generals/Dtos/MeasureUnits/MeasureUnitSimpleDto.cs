namespace JazaniT1.Application.Generals.Dtos.MeasureUnits
{
    public class MeasureUnitSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string? Description { get; set; }
        public string Symbol { get; set; } = default;
    }
}
