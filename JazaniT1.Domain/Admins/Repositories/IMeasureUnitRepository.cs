
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Domain.Admins.Repositories
{
    public interface IMeasureUnitRepository
    {
        Task<IReadOnlyList<MeasureUnit>> FindAllAsync();
        Task<MeasureUnit?> FindByIdAsync(int id);
        Task<MeasureUnit?> SaveAsync(MeasureUnit measureUnit);
    }
}
