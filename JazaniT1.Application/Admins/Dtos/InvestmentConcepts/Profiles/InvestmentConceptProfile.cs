using JazaniT1.Domain.Admins.Models;
using AutoMapper;
using JazaniT1.Core.Paginations;

namespace JazaniT1.Application.Admins.Dtos.InvestmentConcepts.Profiles
{
    public class InvestmentConceptProfile : Profile
    {
        public InvestmentConceptProfile()
        {
            {
                CreateMap<InvestmentConcept, InvestmentConceptDto>();
                CreateMap<InvestmentConceptDto, InvestmentConceptSaveDto>().ReverseMap();
                CreateMap<InvestmentConceptSaveDto, InvestmentConcept>();
                CreateMap<InvestmentConcept, InvestmentConceptSimpleDto>();

                CreateMap<ResponsePagination<InvestmentConcept>, ResponsePagination<InvestmentConceptDto>>();
                CreateMap<RequestPagination<InvestmentConcept>,RequestPagination<InvestmentConceptDto>>().ReverseMap(); ;
            }
        }
    }
}
