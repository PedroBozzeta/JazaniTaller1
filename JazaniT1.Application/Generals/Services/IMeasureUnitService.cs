using JazaniT1.Application.Cores.Services;
using JazaniT1.Application.Generals.Dtos.MeasureUnits;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts;

namespace JazaniT1.Application.Generals.Services
{
    public interface IMeasureUnitService : IPaginatedService<MeasureUnitDto, MeasureUnitDto>
    {
        Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync();
        Task<MeasureUnitDto?> FindByIdAsync(int id);
        Task<MeasureUnitDto?> CreateAsync(MeasureUnitSaveDto measureUnitSaveDto);
        Task<MeasureUnitDto?> EditAsync(int id, MeasureUnitSaveDto measureUnitSaveDto);
        Task<MeasureUnitDto?> DisabledAsync(int id);
    }
}
