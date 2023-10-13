using JazaniT1.Api.Exceptions;
using JazaniT1.Application.Soc.Dtos.Holders;
using JazaniT1.Application.Soc.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Soc
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolderController : ControllerBase
    {
        private readonly IHolderService _holderService;
        public HolderController(IHolderService holderService)
        {
            _holderService = holderService;
        }

        // GET: api/<HolderController>
        [HttpGet]
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.FindAllAsync();
        }
        // GET api/<HolderController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<HolderDto>>> Get(int id)
        {
            var response  = await _holderService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
    }
}
