using JazaniT1.Application.Admins.Dtos.Holders;
using JazaniT1.Application.Admins.Services;
using JazaniT1.Application.Admins.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
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
        public async Task<HolderDto> Get(int id)
        {
            return await _holderService.FindByIdAsync(id);
        }
    }
}
