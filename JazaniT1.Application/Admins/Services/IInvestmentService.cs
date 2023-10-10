using Jazani.Application.Cores.Services;
using Jazani.Application.Mc.Dtos.Investments;
using JazaniT1.Application.Admins.Dtos.Investments;
using JazaniT1.Application.Cores.Services;

namespace JazaniT1.Application.Admins.Services
{
    public interface IInvestmentService :IPaginatedService<InvestmentDto,InvestmentFilterDto>, ICrudService<InvestmentDto, InvestmentSaveDto, int>
    {
    }
}
