using AutoMapper;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Admins.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>();
            CreateMap<InvestmentDto, InvestmentSaveDto>().ReverseMap();
            CreateMap<InvestmentSaveDto, Investment>();
        }
    }
}
