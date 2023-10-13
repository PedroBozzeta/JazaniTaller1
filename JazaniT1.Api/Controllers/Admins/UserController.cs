using JazaniT1.Application.Admins.Dtos.Users;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<Results<BadRequest,CreatedAtRoute<UserDto>>> Post([FromBody] UserSaveDto userSaveDto)
        {
            UserDto user = await _userService.CreateAsync(userSaveDto);
            return TypedResults.CreatedAtRoute(user);
        }
    }
}
