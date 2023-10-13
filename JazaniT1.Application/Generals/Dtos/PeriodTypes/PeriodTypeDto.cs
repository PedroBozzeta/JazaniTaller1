namespace JazaniT1.Application.Generals.Dtos.PeriodTypes
{
    public class PeriodTypeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = default;
        public string? Description { get; set; }
        public int Time { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
