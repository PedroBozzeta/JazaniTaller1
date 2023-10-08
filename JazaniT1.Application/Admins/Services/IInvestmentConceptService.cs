using JazaniT1.Application.Admins.Dtos.InvestmentConcepts;

namespace JazaniT1.Application.Admins.Services
{
    public interface IInvestmentConceptService
    {
        Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync();
        Task<InvestmentConceptDto?> FindByIdAsync(int id);
        Task<InvestmentConceptDto?> CreateAsync(InvestmentConceptSaveDto investmentConceptSaveDto);
        Task<InvestmentConceptDto?> EditAsync(int id, InvestmentConceptSaveDto investmentConceptSaveDto);
        Task<InvestmentConceptDto?> DisabledAsync(int id);
    }
}
