using AutoMapper;
using JazaniT1.Application.Admins.Dtos.LevelEducations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class LevelEducationService : ILevelEducationService
    {
        private readonly ILevelEducationRepository _levelEducationRepository;

        private readonly IMapper _mapper;
        public LevelEducationService(ILevelEducationRepository levelEducationRepository, IMapper mapper)
        {
            _levelEducationRepository = levelEducationRepository;

            _mapper = mapper;
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
            levelEducation.State = false;

            LevelEducation levelEducationSaved = await _levelEducationRepository.SaveAsync(levelEducation);

            return _mapper.Map<LevelEducationDto>(levelEducationSaved);
        }

        public async Task<LevelEducationDto?> EditAsync(int id, LevelEducationSaveDto levelEducationSaveDto)
        {
            LevelEducation levelEducation = await _levelEducationRepository.FindByIdAsync(id);

            _mapper.Map<LevelEducationSaveDto, LevelEducation>(levelEducationSaveDto, levelEducation);
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

            return _mapper.Map<LevelEducationDto>(levelEducation);
        }
    }
}
