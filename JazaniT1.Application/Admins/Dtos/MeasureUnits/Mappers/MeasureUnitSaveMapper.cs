using AutoMapper;
using JazaniT1.Domain.Admins.Models;
namespace JazaniT1.Application.Admins.Dtos.MeasureUnits.Mappers
{
    public class MeasureUnitSaveMapper : Profile
    {
        public MeasureUnitSaveMapper()
        {
            CreateMap<MeasureUnit, MeasureUnitSaveDto>().ReverseMap();
        }
    }
}