using JazaniT1.Core.Paginations;

namespace JazaniT1.Application.Cores.Services
{
    public interface IPaginatedService<TDto, TDtoFilter>
    {
        Task<ResponsePagination<TDto>> PaginatedSearch(RequestPagination<TDtoFilter> request);
    }
}
