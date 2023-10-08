using JazaniT1.Application.Admins.Dtos.PeriodTypes;

namespace JazaniT1.Application.Admins.Services
{
    public interface IPeriodTypeService
    {
        Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync();
        Task<PeriodTypeDto?> FindByIdAsync(int id);
        Task<PeriodTypeDto?> CreateAsync(PeriodTypeSaveDto periodTypeSaveDto);
        Task<PeriodTypeDto?> EditAsync(int id, PeriodTypeSaveDto periodTypetSaveDto);
        Task<PeriodTypeDto?> DisabledAsync(int id);
    }
}
