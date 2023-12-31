﻿using JazaniT1.Api.Exceptions;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts;
using JazaniT1.Application.Mc.Services;
using JazaniT1.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentConceptController : ControllerBase
    {
        private readonly IInvestmentConceptService _investmentConceptService;
        public InvestmentConceptController(IInvestmentConceptService investmentConceptService)
        {
            _investmentConceptService = investmentConceptService;
        }
        // GET: api/<InvestmentConcept>
        [HttpGet]
        public async Task<IEnumerable<InvestmentConceptDto>> Get()
        {
            return await _investmentConceptService.FindAllAsync();
        }

        // GET api/<InvestmentConcept>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Get(int id)
        {
            var response = await _investmentConceptService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<InvestmentConcept>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentConceptDto>>> Post([FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            var response= await _investmentConceptService.CreateAsync(investmentConceptSaveDto);
            return  TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<InvestmentConcept>/5
        [HttpPut("{id}")]
        public async Task<InvestmentConceptDto> Put(int id, [FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            return await _investmentConceptService.EditAsync(id, investmentConceptSaveDto);
        }

        // DELETE api/<InvestmentConcept>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentConceptDto> Delete(int id)
        {
            return await _investmentConceptService.DisabledAsync(id);
        }
        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<InvestmentConceptDto>> PaginatedSearch([FromQuery] RequestPagination<InvestmentConceptDto> request)
        {
            return await _investmentConceptService.PaginatedSearch(request);
        }
    }
}
