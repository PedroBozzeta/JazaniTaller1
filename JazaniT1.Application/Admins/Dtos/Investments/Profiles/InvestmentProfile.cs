using AutoMapper;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Core.Paginations;
namespace JazaniT1.Application.Admins.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>();
            CreateMap<InvestmentDto, InvestmentSaveDto>().ReverseMap();
            CreateMap<InvestmentSaveDto, Investment>();

            CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
            CreateMap<RequestPagination<Investment>,RequestPagination<InvestmentDto>>().ReverseMap();   
        }
    }
}
