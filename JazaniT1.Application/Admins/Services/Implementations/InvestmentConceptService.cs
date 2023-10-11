using AutoMapper;
using JazaniT1.Application.Admins.Dtos.InvestmentConcepts;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Core.Paginations;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class InvestmentConceptService : IInvestmentConceptService
    {
        private readonly IInvestmentConceptRepository _investmentConceptRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentConceptService> _logger;

        public InvestmentConceptService(IInvestmentConceptRepository investmentConceptRepository, IMapper mapper, ILogger<InvestmentConceptService> logger)
        {
            _investmentConceptRepository = investmentConceptRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<InvestmentConceptDto?> CreateAsync(InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept investmentConcept = _mapper.Map<InvestmentConcept>(investmentConceptSaveDto);
            investmentConcept.RegistrationDate=DateTime.Now;
            investmentConcept.State = true;
            InvestmentConcept? investmentConceptSaved= await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<InvestmentConceptDto?> DisabledAsync(int id)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            if (investmentConcept == null)
            {
                _logger.LogWarning("Concepto de inversión no encontrado para el id " + id);
                throw InvestmentConceptNotFound(id);
            }
            var rs = investmentConcept.Description;
            investmentConcept.State = false;
            InvestmentConcept? investmentConceptSaved = await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }
        public async Task<InvestmentConceptDto?> EditAsync(int id, InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            if (investmentConcept == null)
            {
                _logger.LogWarning("Concepto de inversión no encontrado para el id " + id);
                throw InvestmentConceptNotFound(id);
            }
            _mapper.Map<InvestmentConceptSaveDto,InvestmentConcept>(investmentConceptSaveDto,investmentConcept);
            InvestmentConcept? investmentConceptSaved = await _investmentConceptRepository.SaveAsync(investmentConcept);
            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentConcept> investmentConcept = await _investmentConceptRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentConceptDto>>(investmentConcept);

        }

        public async Task<InvestmentConceptDto?> FindByIdAsync(int id)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            if (investmentConcept == null)
            {
                _logger.LogWarning("Concepto de inversión no encontrado para el id " + id);
                throw InvestmentConceptNotFound(id);
            }
            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<ResponsePagination<InvestmentConceptDto>> PaginatedSearch(RequestPagination<InvestmentConceptDto> request)
        {
            var entity = _mapper.Map<RequestPagination<InvestmentConcept>>(request);
            var response = await _investmentConceptRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<InvestmentConceptDto>>(response);
        }

        private NotFoundCoreException InvestmentConceptNotFound(int id)
        {
            return new NotFoundCoreException("InvestmentConcept no encontrado para el id " + id);
        }

    }
}
