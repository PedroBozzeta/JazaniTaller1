using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Infrastructure.Cores.Contexts;
using JazaniT1.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class UserRepository : CrudRepository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _dbContext.Set<User>()
                .Where(t=>t.Email.ToUpper().Equals(email.ToUpper()))
                .FirstOrDefaultAsync(); 
        }
    }
}
