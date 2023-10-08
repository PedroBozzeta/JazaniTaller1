using JazaniT1.Application.Admins.Dtos.Investments;

namespace JazaniT1.Application.Admins.Services
{
    public interface IInvestmentService
    {
        Task<IReadOnlyList<InvestmentDto>> FindAllAsync();
        Task<InvestmentDto?> FindByIdAsync(int id);
        Task<InvestmentDto?> CreateAsync(InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto?> EditAsync(int id, InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto?> DisabledAsync(int id);
    }
}
