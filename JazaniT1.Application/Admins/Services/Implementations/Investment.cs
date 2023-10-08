using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Investments;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSaveDto)
        {
            Investment investment = _mapper.Map<Investment>(investmentSaveDto);
            investment.RegistrationDate = DateTime.Now;
            investment.State = true;
            Investment investmentSaved = await _investmentRepository.SaveAsync( investment);
            return _mapper.Map<InvestmentDto>(investmentSaved);
        }


        public async Task<InvestmentDto?> DisabledAsync(int id)
        {
            Investment investment =await  _investmentRepository.FindByIdAsync(id);
            investment.State = false;
            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);
            return _mapper.Map<InvestmentDto>(investmentSaved);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);
            _mapper.Map<InvestmentSaveDto,Investment>(investmentSaveDto,investment);
            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);
            return _mapper.Map<InvestmentDto>(investmentSaved);
        }

        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            IReadOnlyList<Investment> investments= await _investmentRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentDto>>(investments);
        }

        public async Task<InvestmentDto?> FindByIdAsync(int id)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);
            return _mapper.Map<InvestmentDto>(investment);
        }
    }
}
