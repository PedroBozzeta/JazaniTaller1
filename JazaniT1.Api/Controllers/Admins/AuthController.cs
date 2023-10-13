using JazaniT1.Api.Exceptions;
using JazaniT1.Application.Admins.Dtos.Users;
using JazaniT1.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<AuthController>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(UserSecurityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<BadRequest,Ok<UserSecurityDto>>> Post([FromBody] UserAuthDto userAuthDto)
        {
            UserSecurityDto userSecurity = await _userService.LoginAsync(userAuthDto);
            return TypedResults.Ok(userSecurity);
        }

    }
}
