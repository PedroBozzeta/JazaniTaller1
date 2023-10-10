using Jazani.Application.Cores.Services;
using JazaniT1.Application.Admins.Dtos.Investments;

namespace JazaniT1.Application.Admins.Services
{
    public interface IInvestmentService : ICrudService<InvestmentDto, InvestmentSaveDto, int>
    {
        Task<IReadOnlyList<InvestmentDto>> FindAllAsync();

        Task<InvestmentDto> FindByIdAsync(int id);

        Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSave);

        Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSave);

        Task<InvestmentDto> DisabledAsync(int id);
    }
}
