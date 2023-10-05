using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Infrastructure.Cores.Contexts;
using JazaniT1.Infrastructure.Cores.Persistences;
namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class LevelEducationRepository : CrudRepository<LevelEducation, int>, ILevelEducationRepository
    {
        public LevelEducationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
