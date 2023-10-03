using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class MeasureUnitRepository : IMeasureUnitRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MeasureUnitRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<MeasureUnit>> FindAllAsync()
        {
            return await _dbContext.MeasureUnits.ToListAsync();
        }

        public async Task<MeasureUnit?> FindByIdAsync(int id)
        {
            return await _dbContext.MeasureUnits
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MeasureUnit?> SaveAsync(MeasureUnit measureUnit)
        {
            EntityState state = _dbContext.Entry(measureUnit).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.MeasureUnits.Add(measureUnit),
                EntityState.Modified => _dbContext.MeasureUnits.Update(measureUnit)
            };

            await _dbContext.SaveChangesAsync();

            return measureUnit;
        }
    }
}
