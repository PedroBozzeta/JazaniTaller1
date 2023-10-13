using JazaniT1.Application.Soc.Dtos.Holders;

namespace JazaniT1.Application.Soc.Services
{
    public interface IHolderService
    {
        Task<IReadOnlyList<HolderDto>> FindAllAsync();
        Task<HolderDto?> FindByIdAsync(int id);
    }
}
