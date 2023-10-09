using AutoMapper;
using JazaniT1.Application.Admins.Dtos.PeriodTypes;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PeriodTypeService(IPeriodTypeRepository periodTypeRepository, IMapper mapper, ILogger<PeriodTypeService> logger)
        {
            _periodTypeRepository = periodTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PeriodTypeDto?> CreateAsync(PeriodTypeSaveDto periodTypeSaveDto)
        {
            PeriodType periodType = _mapper.Map<PeriodType>(periodTypeSaveDto);
            periodType.RegistrationDate=DateTime.Now;
            periodType.State = true;
            PeriodType periodTypeSaved= await _periodTypeRepository.SaveAsync(periodType);
            return _mapper.Map<PeriodTypeDto?>(periodTypeSaved);
        }

        public async Task<PeriodTypeDto?> DisabledAsync(int id)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);
            if (periodType == null)
            {
                _logger.LogWarning("Tipo de periodo no encontrada para el id " + id);
                throw PeriodTypeNotFound(id);
            }

            periodType.State = false;
            PeriodType periodTypeSaved = await _periodTypeRepository.SaveAsync(periodType);
            return _mapper.Map<PeriodTypeDto>(periodTypeSaved);
        }

        public async Task<PeriodTypeDto?> EditAsync(int id, PeriodTypeSaveDto periodTypetSaveDto)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);
            if (periodType == null)
            {
                _logger.LogWarning("Tipo de periodo no encontrada para el id " + id);
                throw PeriodTypeNotFound(id);
            }

            _mapper.Map<PeriodTypeSaveDto,PeriodType>(periodTypetSaveDto,periodType);
            PeriodType periodTypeSaved = await _periodTypeRepository.SaveAsync(periodType);
            return _mapper.Map<PeriodTypeDto>(periodTypeSaved);
        }

        public async Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PeriodType> periodType=await _periodTypeRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<PeriodTypeDto>>(periodType);
        }

        public async Task<PeriodTypeDto?> FindByIdAsync(int id)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);
            if (periodType == null)
            {
                _logger.LogWarning("Tipo de periodo no encontrada para el id " + id);
                throw PeriodTypeNotFound(id);
            }

            return _mapper.Map<PeriodTypeDto>(periodType);
        }
        private NotFoundCoreException PeriodTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de periodo no encontrado para el id " + id);
        }
    }
}
