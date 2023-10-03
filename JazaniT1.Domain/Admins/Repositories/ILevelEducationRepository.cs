using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Domain.Admins.Repositories
{
    //Definiendo el contrato de la Interfaz
    public interface ILevelEducationRepository
    {
        Task<IReadOnlyList<LevelEducation>> FindAllAsync();
        Task<LevelEducation?> FindByIdAsync(int id);
        Task<LevelEducation?> SaveAsync(LevelEducation levelEducation);
    }
}
