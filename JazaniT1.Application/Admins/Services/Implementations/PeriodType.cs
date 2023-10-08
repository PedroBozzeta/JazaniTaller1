using AutoMapper;
using JazaniT1.Application.Admins.Dtos.PeriodTypes;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IMapper _mapper;

        public PeriodTypeService(IPeriodTypeRepository periodTypeRepository, IMapper mapper)
        {
            _periodTypeRepository = periodTypeRepository;
            _mapper = mapper;
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
            periodType.State = false;
            PeriodType periodTypeSaved = await _periodTypeRepository.SaveAsync(periodType);
            return _mapper.Map<PeriodTypeDto>(periodTypeSaved);
        }

        public async Task<PeriodTypeDto?> EditAsync(int id, PeriodTypeSaveDto periodTypetSaveDto)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);
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
            return _mapper.Map<PeriodTypeDto>(periodType);
        }
    }
}
