using JazaniT1.Application.Admins.Dtos.MeasureUnits;
namespace JazaniT1.Application.Admins.Services
{
    public interface IMeasureUnitService
    {
        Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync();
        Task<MeasureUnitDto?> FindByIdAsync(int id);
        Task<MeasureUnitDto?> CreateAsync(MeasureUnitSaveDto measureUnitSaveDto);
        Task<MeasureUnitDto?> EditAsync(int id, MeasureUnitSaveDto measureUnitSaveDto);
        Task<MeasureUnitDto?> DisabledAsync(int id);
    }
}
