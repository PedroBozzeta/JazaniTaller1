using JazaniT1.Application.Admins.Dtos.LevelEducations;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelEducationController : ControllerBase
    {
        private readonly ILevelEducationService _levelEducationService;
        public LevelEducationController(ILevelEducationService levelEducationService)
        {
            _levelEducationService = levelEducationService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<LevelEducationDto>> Get()
        {
            return await _levelEducationService.FindAllAsync();
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<LevelEducationDto> Get(int id)
        {
            return await _levelEducationService.FindByIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<LevelEducationDto> Post([FromBody] LevelEducationSaveDto levelEducationSaveDto)
        {
            return await _levelEducationService.CreateAsync(levelEducationSaveDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<LevelEducationDto> Put(int id, [FromBody] LevelEducationSaveDto levelEducationSaveDto)
        {
            return await _levelEducationService.EditAsync(id, levelEducationSaveDto);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<LevelEducationDto> Delete(int id)
        {
            return await _levelEducationService.DisabledAsync(id);
        }
    }
}
