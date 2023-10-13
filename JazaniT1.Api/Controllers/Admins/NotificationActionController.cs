using JazaniT1.Api.Exceptions;
using JazaniT1.Application.Generals.Dtos.NotificationActions;
using JazaniT1.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationActionController : ControllerBase
    {
        private readonly INotificationActionService _notificationActionService;
        public NotificationActionController(INotificationActionService notificationActionService)
        {
            _notificationActionService = notificationActionService;
        }


        // GET: api/<NotificationActionController>
        [HttpGet]
        public async Task<IEnumerable<NotificationActionDto>> Get()
        {
            return await _notificationActionService.FindAllAsync();
        }
        // GET api/<NotificationActionController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationActionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<NotificationActionDto>>> Get(int id)
        {
            var response = await _notificationActionService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<NotificationActionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NotificationActionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest,CreatedAtRoute<NotificationActionDto>>> Post([FromBody] NotificationActionSaveDto notificationActionSaveDto)
        {
            var response = await _notificationActionService.CreateAsync(notificationActionSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<NotificationActionController>/5
        [HttpPut("{id}")]
        public async Task<NotificationActionDto> Put(int id, [FromBody] NotificationActionSaveDto notificationActionSaveDto)
        {
            return await _notificationActionService.EditAsync(id, notificationActionSaveDto);
        }

        // DELETE api/<NotificationActionController>/5
        [HttpDelete("{id}")]
        public async Task<NotificationActionDto> Delete(int id)
        {
            return await _notificationActionService.DisabledAsync(id);
        }
    }
}
