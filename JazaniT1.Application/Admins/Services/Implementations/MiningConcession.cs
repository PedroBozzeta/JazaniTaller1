using AutoMapper;
using JazaniT1.Application.Admins.Dtos.MiningConcessions;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miningConcessionRepository;
        private readonly IMapper _mapper;

        public MiningConcessionService(IMiningConcessionRepository miningConcessionRepository, IMapper mapper)
        {
            _miningConcessionRepository = miningConcessionRepository;
            _mapper = mapper;
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
            MiningConcession miningConcession= await _miningConcessionRepository.FindByIdAsync(id);
            miningConcession.State = false;
            MiningConcession miningConcessionSaved = await _miningConcessionRepository.SaveAsync(miningConcession);
            return _mapper.Map<MiningConcessionDto>(miningConcessionSaved);
        }

        public async Task<MiningConcessionDto?> EditAsync(int id, MiningConcessionSaveDto miningConcessiontSaveDto)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
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
            return _mapper.Map<MiningConcessionDto?>(miningConcession);
        }
    }
}
