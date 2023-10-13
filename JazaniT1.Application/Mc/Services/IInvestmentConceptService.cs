using JazaniT1.Application.Cores.Services;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Mc.Services
{
    public interface IInvestmentConceptService : IPaginatedService<InvestmentConceptDto, InvestmentConceptDto>
    {
        Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync();
        Task<InvestmentConceptDto?> FindByIdAsync(int id);
        Task<InvestmentConceptDto?> CreateAsync(InvestmentConceptSaveDto investmentConceptSaveDto);
        Task<InvestmentConceptDto?> EditAsync(int id, InvestmentConceptSaveDto investmentConceptSaveDto);
        Task<InvestmentConceptDto?> DisabledAsync(int id);
    }
}
