using AutoMapper;
using JazaniT1.Application.Generals.Dtos.MeasureUnits;
using JazaniT1.Domain.Admins.Models;
namespace JazaniT1.Application.Generals.Dtos.MeasureUnits.Mappers
{
    public class MeasureUnitMapper : Profile
    {
        public MeasureUnitMapper()
        {
            CreateMap<MeasureUnit, MeasureUnitDto>();
            CreateMap<MeasureUnit, MeasureUnitSimpleDto>();
        }
    }
}
