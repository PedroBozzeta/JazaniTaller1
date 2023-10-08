using AutoMapper;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Admins.Dtos.PeriodTypes.Profiles
{
    public class PeriodTypeProfile : Profile
    {
        public PeriodTypeProfile()
        {
            CreateMap<PeriodType, PeriodTypeDto>();
            CreateMap<PeriodTypeDto, PeriodTypeSaveDto>().ReverseMap();
            CreateMap<PeriodTypeSaveDto, PeriodType>();
            CreateMap<PeriodType, PeriodTypeSimpleDto>();
        }

    }
}