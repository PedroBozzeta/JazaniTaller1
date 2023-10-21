using JazaniT1.Core.Paginations;
using JazaniT1.Domain.Cores.Paginations;
using Microsoft.EntityFrameworkCore;

namespace JazaniT1.Infrastructure.Cores.Paginations
{
    public class Paginator<T> : IPaginator<T>
    {
        public async Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request)
        {
            var total = await query.CountAsync();
            var pagination = new Pagination(total, request.Page, request.PerPage);


            var sizePerPage = pagination.PerPage;

            var diference = (pagination.To - pagination.From) + 1;

            if (diference < pagination.PerPage) sizePerPage = diference;
            Console.WriteLine("la diferencia es de "+diference);
            var currentPage=pagination.CurrentPage;

            if(currentPage>0 ) currentPage = pagination.CurrentPage-1;

            var queryPagination = query.Skip(currentPage * pagination.PerPage).Take(sizePerPage);
            var data =await queryPagination.ToListAsync();

            return new ResponsePagination<T>(pagination)
            {
                Data = data
            };

        }
    }
}
