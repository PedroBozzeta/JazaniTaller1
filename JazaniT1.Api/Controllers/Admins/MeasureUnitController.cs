using JazaniT1.Application.Admins.Dtos.MeasureUnits;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureUnitController : ControllerBase
    {
        private readonly IMeasureUnitService _measureUnitService;
        public MeasureUnitController(IMeasureUnitService measureUnitService)
        {
            _measureUnitService = measureUnitService;
        }


        // GET: api/<MeasureUnitController>
        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            return await _measureUnitService.FindAllAsync();
        }
        // GET api/<MeasureUnitController>/5
        [HttpGet("{id}")]
        public async Task<MeasureUnitDto> Get(int id)
        {
            return await _measureUnitService.FindByIdAsync(id);
        }

        // POST api/<MeasureUnitController>
        [HttpPost]
        public async Task<MeasureUnitDto> Post([FromBody] MeasureUnitSaveDto measureUnitSaveDto)
        {
            return await _measureUnitService.CreateAsync(measureUnitSaveDto);
        }

        // PUT api/<MeasureUnitController>/5
        [HttpPut("{id}")]
        public async Task<MeasureUnitDto> Put(int id, [FromBody] MeasureUnitSaveDto measureUnitSaveDto)
        {
            return await _measureUnitService.EditAsync(id, measureUnitSaveDto);
        }

        // DELETE api/<MeasureUnitController>/5
        [HttpDelete("{id}")]
        public async Task<MeasureUnitDto> Delete(int id)
        {
            return await _measureUnitService.DisabledAsync(id);
        }
    }
}
