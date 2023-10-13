using JazaniT1.Application.Mc.Dtos.MiningConcessions;

namespace JazaniT1.Application.Mc.Services
{
    public interface IMiningConcessionService
    {
        Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync();
        Task<MiningConcessionDto?> FindByIdAsync(int id);
        Task<MiningConcessionDto?> CreateAsync(MiningConcessionSaveDto miningConcessionSaveDto);
        Task<MiningConcessionDto?> EditAsync(int id, MiningConcessionSaveDto miningConcessiontSaveDto);
        Task<MiningConcessionDto?> DisabledAsync(int id);
    }
}
