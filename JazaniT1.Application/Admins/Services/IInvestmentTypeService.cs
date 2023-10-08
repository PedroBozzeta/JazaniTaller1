using JazaniT1.Application.Admins.Dtos.InvestmentTypes;

namespace JazaniT1.Application.Admins.Services
{
    public interface IInvestmentTypeService
    {
        Task<IReadOnlyList<InvestmentTypeDto>> FindAllAsync();
        Task<InvestmentTypeDto?> FindByIdAsync(int id);
        Task<InvestmentTypeDto?> CreateAsync(InvestmentTypeSaveDto investmentTypeSaveDto);
        Task<InvestmentTypeDto?> EditAsync(int id, InvestmentTypeSaveDto investmentTypeSaveDto);
        Task<InvestmentTypeDto?> DisabledAsync(int id);
    }
}
