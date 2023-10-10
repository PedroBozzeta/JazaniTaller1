using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Cores.JazaniT1.Domain.Cores.Repositories;
using JazaniT1.Domain.Cores.Repositories;

namespace JazaniT1.Domain.Admins.Repositories
{
    public interface IInvestmentRepository: ICrudRepository <Investment,int>,IPaginatedRepository<Investment>
    {
    }
}
