using AutoMapper;
using JazaniT1.Application.Admins.Dtos.MiningConcessions;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miningConcessionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MiningConcessionService> _logger;

        public MiningConcessionService(IMiningConcessionRepository miningConcessionRepository, IMapper mapper,ILogger<MiningConcessionService> logger)
        {
            _miningConcessionRepository = miningConcessionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MiningConcessionDto?> CreateAsync(MiningConcessionSaveDto miningConcessionSaveDto)
        {
            MiningConcession miningConcession = _mapper.Map<MiningConcession>(miningConcessionSaveDto);
            miningConcession.RegistrationDate=DateTime.Now;
            miningConcession.State = false;
            MiningConcession miningConcessionSaved= await _miningConcessionRepository.SaveAsync(miningConcession);
            return _mapper.Map<MiningConcessionDto>(miningConcessionSaved);
        }

        public async Task<MiningConcessionDto?> DisabledAsync(int id)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            if (miningConcession == null)
            {
                _logger.LogWarning("Concesión minera no encontrada para el id " + id);
                throw MiningConcessionNotFound(id);
            }

            miningConcession.State = false;
            MiningConcession miningConcessionSaved = await _miningConcessionRepository.SaveAsync(miningConcession);
            return _mapper.Map<MiningConcessionDto>(miningConcessionSaved);
        }

        public async Task<MiningConcessionDto?> EditAsync(int id, MiningConcessionSaveDto miningConcessiontSaveDto)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            if (miningConcession == null)
            {
                _logger.LogWarning("Concesión minera no encontrada para el id " + id);
                throw MiningConcessionNotFound(id);
            }

            _mapper.Map<MiningConcessionSaveDto, MiningConcession>(miningConcessiontSaveDto, miningConcession);
            MiningConcession miningConcessionSaved = await _miningConcessionRepository.SaveAsync(miningConcession);
            return _mapper.Map<MiningConcessionDto>(miningConcessionSaved);
        }

        public async Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> miningConcession = await _miningConcessionRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MiningConcessionDto>>(miningConcession);
        }

        public async Task<MiningConcessionDto?> FindByIdAsync(int id)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            if (miningConcession == null)
            {
                _logger.LogWarning("Concesión minera no encontrada para el id " + id);
                throw MiningConcessionNotFound(id);
            }

            return _mapper.Map<MiningConcessionDto?>(miningConcession);
        }
        private NotFoundCoreException MiningConcessionNotFound(int id)
        {
            return new NotFoundCoreException("Concesión minera no encontrado para el id " + id);
        }
    }
}
