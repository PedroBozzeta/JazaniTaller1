using JazaniT1.Application.Admins.Dtos.MiningConcessions;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiningConcessionController : ControllerBase
    {
        private readonly IMiningConcessionService _miningConcessionService;

        public MiningConcessionController(IMiningConcessionService miningConcessionService)
        {
            _miningConcessionService = miningConcessionService;
        }

        // GET: api/<MiningConcessionController>
        [HttpGet]
        public async Task<IEnumerable<MiningConcessionDto>> Get()
        {
            return await _miningConcessionService.FindAllAsync();
        }

        // GET api/<MiningConcessionController>/5
        [HttpGet("{id}")]
        public async Task<MiningConcessionDto> Get(int id)
        {
            return await _miningConcessionService.FindByIdAsync(id);
        }

        // POST api/<MiningConcessionController>
        [HttpPost]
        public async Task<MiningConcessionDto> Post([FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            return await _miningConcessionService.CreateAsync(miningConcessionSaveDto);
        }

        // PUT api/<MiningConcessionController>/5
        [HttpPut("{id}")]
        public async Task<MiningConcessionDto> Put(int id, [FromBody] MiningConcessionSaveDto miningConcessionSaveDto)
        {
            return await _miningConcessionService.EditAsync(id, miningConcessionSaveDto);
        }

        // DELETE api/<MiningConcessionController>/5
        [HttpDelete("{id}")]
        public async Task<MiningConcessionDto> Delete(int id)
        {
            return await _miningConcessionService.DisabledAsync(id);
        }
    }
}
