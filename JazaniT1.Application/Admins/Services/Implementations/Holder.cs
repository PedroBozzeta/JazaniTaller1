using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Holders;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;

        private readonly IMapper _mapper;
        public HolderService(IHolderRepository holderRepository, IMapper mapper)
        {
            _holderRepository = holderRepository;

            _mapper = mapper;
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> Holders = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(Holders);
        }

        public async Task<HolderDto?> FindByIdAsync(int id)
        {
            Holder? Holder = await _holderRepository.FindByIdAsync(id);

            return _mapper.Map<HolderDto>(Holder);
        }
    }
}