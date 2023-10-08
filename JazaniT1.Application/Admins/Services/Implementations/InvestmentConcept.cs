using AutoMapper;
using JazaniT1.Application.Admins.Dtos.InvestmentConcepts;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class InvestmentConceptService : IInvestmentConceptService
    {
        private readonly IInvestmentConceptRepository _investmentConceptRepository;
        private readonly IMapper _mapper;

        public InvestmentConceptService(IInvestmentConceptRepository investmentConceptRepository, IMapper mapper)
        {
            _investmentConceptRepository = investmentConceptRepository;
            _mapper = mapper;
        }
        public async Task<InvestmentConceptDto?> CreateAsync(InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept investmentConcept = _mapper.Map<InvestmentConcept>(investmentConceptSaveDto);
            investmentConcept.RegistrationDate=DateTime.Now;
            investmentConcept.State = true;
            InvestmentConcept investmentConceptSaved= await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<InvestmentConceptDto> DisabledAsync(int id)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            investmentConcept.State = false;
            InvestmentConcept investmentConceptSaved = await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<InvestmentConceptDto?> EditAsync(int id, InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            _mapper.Map<InvestmentConceptSaveDto,InvestmentConcept>(investmentConceptSaveDto,investmentConcept);
            InvestmentConcept investmentConceptSaved = await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentConcept> investmentConcept = await _investmentConceptRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentConceptDto>>(investmentConcept);

        }

        public async Task<InvestmentConceptDto?> FindByIdAsync(int id)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }
    }
}
