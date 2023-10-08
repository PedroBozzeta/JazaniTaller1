using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Infrastructure.Cores.Contexts;
using JazaniT1.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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
    }
}