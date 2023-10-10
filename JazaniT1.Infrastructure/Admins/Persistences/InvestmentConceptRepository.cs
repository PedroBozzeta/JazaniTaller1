using JazaniT1.Core.Paginations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Domain.Cores.Paginations;
using JazaniT1.Infrastructure.Cores.Contexts;
using JazaniT1.Infrastructure.Cores.Persistences;

namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class InvestmentConceptRepository : CrudRepository<InvestmentConcept, int>, IInvestmentConceptRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPaginator<InvestmentConcept> _paginator;
        public InvestmentConceptRepository(ApplicationDbContext dbContext, IPaginator<InvestmentConcept> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
        }

        public async Task<ResponsePagination<InvestmentConcept>> PaginatedSearch(RequestPagination<InvestmentConcept> request)
        {
            var filter = request.Filter;
            var query = _dbContext.Set<InvestmentConcept>().AsQueryable();

            if(filter is not null)
            {
                query = query.Where(x => string.IsNullOrWhiteSpace(filter.Name) || x.Name.ToUpper().Contains(filter.Name.ToUpper())
                );
            }

            query = query.OrderByDescending(x => x.Id);

            return await _paginator.Paginate(query, request);
        }
    }
}