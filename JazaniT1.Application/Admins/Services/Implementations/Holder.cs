using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Holders;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;

        private readonly IMapper _mapper;
        
        private readonly ILogger<HolderService> _logger;

        public HolderService(IHolderRepository holderRepository, IMapper mapper, ILogger<HolderService> logger)
        {
            _holderRepository = holderRepository;

            _mapper = mapper;

            _logger = logger;
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> Holders = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(Holders);
        }

        public async Task<HolderDto?> FindByIdAsync(int id)
        {
            Holder? Holder = await _holderRepository.FindByIdAsync(id);
            if (Holder == null) {
                _logger.LogWarning("Holder no encontrado para el id " + id);
                throw HolderNotFound(id); }
            return _mapper.Map<HolderDto>(Holder);
        }
        private NotFoundCoreException HolderNotFound(int id)
        {
            return new NotFoundCoreException("Holder no encontrado para el id " + id);
        }
    }
}