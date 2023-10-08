using JazaniT1.Application.Admins.Dtos.Holders;

namespace JazaniT1.Application.Admins.Services
{
    public interface IHolderService
    {
        Task<IReadOnlyList<HolderDto>> FindAllAsync();
        Task<HolderDto?> FindByIdAsync(int id);
    }
}
