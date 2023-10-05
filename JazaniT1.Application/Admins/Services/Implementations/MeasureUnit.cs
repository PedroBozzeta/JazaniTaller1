using AutoMapper;
using JazaniT1.Application.Admins.Dtos.MeasureUnits;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;

        private readonly IMapper _mapper;
        public MeasureUnitService(IMeasureUnitRepository measureUnitRepository, IMapper mapper)
        {
            _measureUnitRepository = measureUnitRepository;

            _mapper = mapper;
        }

        public async Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto measureUnitSaveDto)
        {
            MeasureUnit measureUnit = _mapper.Map<MeasureUnit>(measureUnitSaveDto);
            measureUnit.RegistrationDate = DateTime.Now;
            measureUnit.State = true;

            MeasureUnit measureUnitSaved = await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnitSaved);
        }

        public async Task<MeasureUnitDto> DisabledAsync(int id)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);
            measureUnit.State = false;

            MeasureUnit measureUnitSaved = await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnitSaved);
        }

        public async Task<MeasureUnitDto?> EditAsync(int id, MeasureUnitSaveDto measureUnitSaveDto)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            _mapper.Map<MeasureUnitSaveDto, MeasureUnit>(measureUnitSaveDto, measureUnit);
            MeasureUnit measureUnitSaved = await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnitSaved);
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync()
        {
            IReadOnlyList<MeasureUnit> measureUnits = await _measureUnitRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MeasureUnitDto>>(measureUnits);
        }

        public async Task<MeasureUnitDto?> FindByIdAsync(int id)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }
    }
}
