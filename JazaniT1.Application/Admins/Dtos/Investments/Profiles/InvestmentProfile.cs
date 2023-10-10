using AutoMapper;
using Jazani.Application.Mc.Dtos.Investments;
using JazaniT1.Core.Paginations;
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

            CreateMap<Investment, InvestmentFilterDto>().ReverseMap();
            CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
            CreateMap<RequestPagination<Investment>, RequestPagination<InvestmentFilterDto>>().ReverseMap();
        }
    }
}
