using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class LevelEducationRepository : ILevelEducationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LevelEducationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<LevelEducation>> FindAllAsync()
        {
            return await _dbContext.LevelEducations.ToListAsync();
        }

        public async Task<LevelEducation?> FindByIdAsync(int id)
        {
            return await _dbContext.LevelEducations
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LevelEducation?> SaveAsync(LevelEducation levelEducation)
        {
            EntityState state = _dbContext.Entry(levelEducation).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.LevelEducations.Add(levelEducation),
                EntityState.Modified => _dbContext.LevelEducations.Update(levelEducation)
            };

            await _dbContext.SaveChangesAsync();

            return levelEducation;
        }
    }
}
