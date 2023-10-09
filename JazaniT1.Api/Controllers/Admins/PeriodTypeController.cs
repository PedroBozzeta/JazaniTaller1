using JazaniT1.Api.Exceptions;
using JazaniT1.Application.Admins.Dtos.PeriodTypes;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodTypeController : ControllerBase

    {
        private readonly IPeriodTypeService _periodTypeService;

        public PeriodTypeController(IPeriodTypeService periodTypeService)
        {
            _periodTypeService = periodTypeService;
        }
        // GET: api/<PeriodTypeController>
        [HttpGet]
        public async Task<IEnumerable<PeriodTypeDto>> Get()
        {
            return await _periodTypeService.FindAllAsync();
        }

        // GET api/<PeriodTypeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<PeriodTypeDto>>> Get(int id)
        {
            var response = await _periodTypeService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<PeriodTypeController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest,CreatedAtRoute<PeriodTypeDto>>> Post([FromBody] PeriodTypeSaveDto periodTypeSaveDto)
        {
            var response = await _periodTypeService.CreateAsync(periodTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<PeriodTypeController>/5
        [HttpPut("{id}")]
        public async Task<PeriodTypeDto> Put(int id, [FromBody] PeriodTypeSaveDto periodTypeSaveDto)
        {
            return await _periodTypeService.EditAsync(id, periodTypeSaveDto);
        }

        // DELETE api/<PeriodTypeController>/5
        [HttpDelete("{id}")]
        public async Task<PeriodTypeDto> Delete(int id)
        {
            return await _periodTypeService.DisabledAsync(id);
        }
    }
}
