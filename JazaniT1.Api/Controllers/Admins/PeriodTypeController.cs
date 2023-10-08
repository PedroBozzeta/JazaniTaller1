using JazaniT1.Application.Admins.Dtos.PeriodTypes;
using JazaniT1.Application.Admins.Services;
using JazaniT1.Domain.Admins.Repositories;
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
        public async Task<PeriodTypeDto> Get(int id)
        {
            return await _periodTypeService.FindByIdAsync(id);
        }

        // POST api/<PeriodTypeController>
        [HttpPost]
        public async Task<PeriodTypeDto> Post([FromBody] PeriodTypeSaveDto periodTypeSaveDto)
        {
            return await _periodTypeService.CreateAsync(periodTypeSaveDto);
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
