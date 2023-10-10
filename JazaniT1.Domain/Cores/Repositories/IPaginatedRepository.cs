using JazaniT1.Core.Paginations;

namespace JazaniT1.Domain.Cores.Repositories
{
    public interface IPaginatedRepository<T> {
        Task<ResponsePagination<T>> PaginatedSearch(RequestPagination<T> request);
     }
}
