using AutoMapper;
using JazaniT1.Domain.Admins.Models;
namespace JazaniT1.Application.Admins.Dtos.LevelEducations.Mappers
{
    public class LevelEducationMapper : Profile
    {
        public LevelEducationMapper()
        {
            CreateMap<LevelEducation, LevelEducationDto>();
        }
    }
}
