using JazaniT1.Core.Paginations;

namespace JazaniT1.Application.Cores.Services
{
    public interface IPaginatedService<TDto>
    {
        Task<ResponsePagination<TDto>> PaginatedSearch(RequestPagination<TDto> request);
    }
}
