using JazaniT1.Application.Generals.Dtos.LevelEducations;

namespace JazaniT1.Application.Generals.Services
{
    public interface ILevelEducationService
    {
        Task<IReadOnlyList<LevelEducationDto>> FindAllAsync();
        Task<LevelEducationDto?> FindByIdAsync(int id);
        Task<LevelEducationDto?> CreateAsync(LevelEducationSaveDto levelEducationSaveDto);
        Task<LevelEducationDto?> EditAsync(int id, LevelEducationSaveDto levelEducationSaveDto);
        Task<LevelEducationDto?> DisabledAsync(int id);
    }
}