using AutoMapper;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Application.Generals.Dtos.LevelEducations;
using JazaniT1.Application.Generals.Services;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniT1.Application.Generals.Services.Implementations
{
    public class LevelEducationService : ILevelEducationService
    {
        private readonly ILevelEducationRepository _levelEducationRepository;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public LevelEducationService(ILevelEducationRepository levelEducationRepository, IMapper mapper, ILogger<LevelEducationService> logger)
        {
            _levelEducationRepository = levelEducationRepository;

            _mapper = mapper;

            _logger = logger;
        }

        public async Task<LevelEducationDto> CreateAsync(LevelEducationSaveDto levelEducationSaveDto)
        {
            LevelEducation levelEducation = _mapper.Map<LevelEducation>(levelEducationSaveDto);
            levelEducation.RegistrationDate = DateTime.Now;
            levelEducation.State = true;

            LevelEducation levelEducationSaved = await _levelEducationRepository.SaveAsync(levelEducation);

            return _mapper.Map<LevelEducationDto>(levelEducationSaved);
        }

        public async Task<LevelEducationDto> DisabledAsync(int id)
        {
            LevelEducation levelEducation = await _levelEducationRepository.FindByIdAsync(id);
            if (levelEducation == null)
            {
                _logger.LogWarning("Nivel de educación no encontrado para el id " + id);
                throw LevelEducationNotFound(id);
            }

            levelEducation.State = false;

            LevelEducation levelEducationSaved = await _levelEducationRepository.SaveAsync(levelEducation);

            return _mapper.Map<LevelEducationDto>(levelEducationSaved);
        }

        public async Task<LevelEducationDto?> EditAsync(int id, LevelEducationSaveDto levelEducationSaveDto)
        {
            LevelEducation levelEducation = await _levelEducationRepository.FindByIdAsync(id);
            if (levelEducation == null)
            {
                _logger.LogWarning("Nivel de educación no encontrado para el id " + id);
                throw LevelEducationNotFound(id);
            }

            _mapper.Map(levelEducationSaveDto, levelEducation);
            LevelEducation levelEducationSaved = await _levelEducationRepository.SaveAsync(levelEducation);

            return _mapper.Map<LevelEducationDto>(levelEducationSaved);
        }

        public async Task<IReadOnlyList<LevelEducationDto>> FindAllAsync()
        {
            IReadOnlyList<LevelEducation> levelEducations = await _levelEducationRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<LevelEducationDto>>(levelEducations);
        }

        public async Task<LevelEducationDto?> FindByIdAsync(int id)
        {
            LevelEducation? levelEducation = await _levelEducationRepository.FindByIdAsync(id);
            if (levelEducation == null)
            {
                _logger.LogWarning("Nivel de educación no encontrado para el id " + id);
                throw LevelEducationNotFound(id);
            }

            return _mapper.Map<LevelEducationDto>(levelEducation);
        }
        private NotFoundCoreException LevelEducationNotFound(int id)
        {
            return new NotFoundCoreException("Nivel de educación no encontrado para el id " + id);
        }
    }
}
