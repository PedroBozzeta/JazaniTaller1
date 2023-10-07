using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using JazaniT1.Infrastructure.Cores.Contexts;
using JazaniT1.Infrastructure.Cores.Persistences;

namespace JazaniT1.Infrastructure.Admins.Persistences
{
    public class InvestmentTypeRepository : CrudRepository<InvestmentType,int>,IInvestmentTypeRepository
    {

        public InvestmentTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}