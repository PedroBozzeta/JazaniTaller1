using JazaniT1.Application.Admins.Dtos.InvestmentConcepts;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using JazaniT1.Api.Exceptions;

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
        public async Task<InvestmentConceptDto> Get(int id)
        {
            return await _investmentConceptService.FindByIdAsync(id);
        }

        // POST api/<InvestmentConcept>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<InvestmentConceptDto> Post([FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            return await _investmentConceptService.CreateAsync(investmentConceptSaveDto);
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
    }
}
