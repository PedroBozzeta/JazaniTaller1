using JazaniT1.Core.Paginations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Domain.Cores.Paginations;
using JazaniT1.Infrastructure.Cores.Contexts;
using JazaniT1.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPaginator<Investment> _paginator;
        public InvestmentRepository(ApplicationDbContext dbContext,IPaginator<Investment> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
        }
        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                .Include(x => x.MiningConcession)
                .Include(x => x.PeriodType)
                .Include(x => x.MeasureUnit)
                .Include(x => x.InvestmentType)
                .Include(x => x.Holder)
                .Include(x => x.InvestmentConcept)
                .AsNoTracking()
                .ToListAsync();
        }
        public override async Task<Investment?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Investment>()
                .Include(x => x.MiningConcession)
                .Include(x => x.PeriodType)
                .Include(x => x.MeasureUnit)
                .Include(x => x.InvestmentType)
                .Include(x => x.Holder)
                .Include(x => x.InvestmentConcept)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            var filter = request.Filter;
            var query = _dbContext.Set<Investment>().AsQueryable();

            if (filter is not null)
            {
                query = query.Where(x =>
                ((filter.Year == null || filter.Year == 0) || x.Year == filter.Year) &&
                (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper())) &&
                ((filter.State == null) || x.State == filter.State)
                );
            }

            query = query.OrderByDescending(x => x.Id)
                .Include(x => x.MiningConcession)
                .Include(x => x.PeriodType)
                .Include(x => x.MeasureUnit)
                .Include(x => x.InvestmentType)
                .Include(x => x.Holder)
                .Include(x => x.InvestmentConcept);

            return await _paginator.Paginate(query, request);
        }
    }
}