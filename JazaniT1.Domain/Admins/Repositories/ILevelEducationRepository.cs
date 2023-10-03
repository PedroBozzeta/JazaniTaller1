using Jazani.Domain.Admins.Models;
using System;

namespace Jazani.Domain.Admins.Repositories
{
    //Definiendo el contrato de la Interfaz
    public interface IOfficeRepository
    {
        Task<IReadOnlyList<LevelEducation>> FindAllAsync();
        Task<LevelEducation?> FindByIdAsync(int id);
        Task<LevelEducation?> SaveAsync(LevelEducation levelEducation);
    }
}
