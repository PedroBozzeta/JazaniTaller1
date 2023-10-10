using JazaniT1.Core.Paginations;
namespace JazaniT1.Domain.Cores.Paginations
{
    public interface IPaginator<T>
    {
        Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request);
    }
}
