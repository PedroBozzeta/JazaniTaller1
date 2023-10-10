namespace Jazani.Application.Mc.Dtos.Investments;
public class InvestmentFilterDto
{
    public int? Year { get; set; } = 0;
    public string? Description { get; set; }
    public bool State { get; set; }
}