using AutoMapper;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Application.Generals.Dtos.MeasureUnits;
using JazaniT1.Application.Generals.Services;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts;
using JazaniT1.Core.Paginations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniT1.Application.Generals.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;
        public MeasureUnitService(IMeasureUnitRepository measureUnitRepository, IMapper mapper, ILogger<MeasureUnitService> logger)
        {
            _measureUnitRepository = measureUnitRepository;

            _mapper = mapper;

            _logger = logger;
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
            if (measureUnit == null)
            {
                _logger.LogWarning("Unidad de medida no encontrado para el id " + id);
                throw MeasureUnitNotFound(id);
            }

            measureUnit.State = false;

            MeasureUnit measureUnitSaved = await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnitSaved);
        }

        public async Task<MeasureUnitDto?> EditAsync(int id, MeasureUnitSaveDto measureUnitSaveDto)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);
            if (measureUnit == null)
            {
                _logger.LogWarning("Unidad de medida no encontrado para el id " + id);
                throw MeasureUnitNotFound(id);
            }

            _mapper.Map(measureUnitSaveDto, measureUnit);
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
            if (measureUnit == null)
            {
                _logger.LogWarning("Unidad de medida no encontrado para el id " + id);
                throw MeasureUnitNotFound(id);
            }

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<ResponsePagination<MeasureUnitDto>> PaginatedSearch(RequestPagination<MeasureUnitDto> request)
        {
            var entity = _mapper.Map<RequestPagination<MeasureUnit>>(request);
            var response = await _measureUnitRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<MeasureUnitDto>>(response);
        }

        private NotFoundCoreException MeasureUnitNotFound(int id)
        {
            return new NotFoundCoreException("Unidad de medida no encontrado para el id " + id);
        }
    }
}
