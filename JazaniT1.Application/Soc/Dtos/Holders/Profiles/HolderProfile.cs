using AutoMapper;
using JazaniT1.Application.Soc.Dtos.Holders;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Soc.Dtos.Holders.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile()
        {
            CreateMap<Holder, HolderDto>();
            CreateMap<HolderDto, HolderSaveDto>().ReverseMap();
            CreateMap<HolderSaveDto, Holder>();
            CreateMap<Holder, HolderSimpleDto>();
        }
    }
}
