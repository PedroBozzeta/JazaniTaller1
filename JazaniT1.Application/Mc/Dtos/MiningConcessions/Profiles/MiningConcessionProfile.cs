using AutoMapper;
using JazaniT1.Application.Mc.Dtos.MiningConcessions;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Mc.Dtos.MiningConcessions.Profiles
{
    public class MiningConcessionProfile : Profile
    {
        public MiningConcessionProfile()
        {
            CreateMap<MiningConcession, MiningConcessionDto>();
            CreateMap<MiningConcessionDto, MiningConcessionSaveDto>().ReverseMap();
            CreateMap<MiningConcessionSaveDto, MiningConcession>();
            CreateMap<MiningConcession, MiningConcessionSimpleDto>();

        }

    }
}
