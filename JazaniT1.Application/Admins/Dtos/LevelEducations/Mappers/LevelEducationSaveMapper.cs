using AutoMapper;
using JazaniT1.Domain.Admins.Models;
namespace JazaniT1.Application.Admins.Dtos.LevelEducations.Mappers
{
    public class LevelEducationSaveMapper : Profile
    {
        public LevelEducationSaveMapper()
        {
            CreateMap<LevelEducation, LevelEducationSaveDto>().ReverseMap();
        }
    }
}
