using Jazani.Application.Cores.Services;
using JazaniT1.Application.Cores.Services;
using JazaniT1.Application.Mc.Dtos.Investments;

namespace JazaniT1.Application.Mc.Services
{
    public interface IInvestmentService : IPaginatedService<InvestmentDto, InvestmentFilterDto>, ICrudService<InvestmentDto, InvestmentSaveDto, int>
    {
    }
}
