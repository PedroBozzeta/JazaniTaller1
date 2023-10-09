using JazaniT1.Api.Exceptions;
using JazaniT1.Application.Admins.Dtos.LevelEducations;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LevelEducationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<LevelEducationDto>>> Get(int id)
        {
            var response = await _levelEducationService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LevelEducationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest,CreatedAtRoute<LevelEducationDto>>> Post([FromBody] LevelEducationSaveDto levelEducationSaveDto)
        {
            var response = await _levelEducationService.CreateAsync(levelEducationSaveDto);
            return TypedResults.CreatedAtRoute(response);
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
