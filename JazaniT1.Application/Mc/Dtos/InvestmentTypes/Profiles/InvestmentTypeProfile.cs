using AutoMapper;
using JazaniT1.Application.Mc.Dtos.InvestmentTypes;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Mc.Dtos.InvestmentTypes.Profiles
{
    public class InvestmentTypeProfile : Profile
    {
        public InvestmentTypeProfile()
        {
            CreateMap<InvestmentType, InvestmentTypeDto>();
            CreateMap<InvestmentTypeDto, InvestmentTypeSaveDto>().ReverseMap();
            CreateMap<InvestmentTypeSaveDto, InvestmentType>();
            CreateMap<InvestmentType, InvestmentTypeSimpleDto>();
        }
    }
}
