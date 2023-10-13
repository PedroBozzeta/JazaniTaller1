using JazaniT1.Api.Exceptions;
using JazaniT1.Application.Generals.Dtos.Notifications;
using JazaniT1.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        // GET: api/<NotificationController>
        [HttpGet]
        public async Task<IEnumerable<NotificationDto>> Get()
        {
            return await _notificationService.FindAllAsync();
        }
        // GET api/<NotificationController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<NotificationDto>>> Get(int id)
        {
            var response = await _notificationService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }

        // POST api/<NotificationController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest,CreatedAtRoute<NotificationDto>>> Post([FromBody] NotificationSaveDto notificationSaveDto)
        {
            var response = await _notificationService.CreateAsync(notificationSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public async Task<NotificationDto> Put(int id, [FromBody] NotificationSaveDto notificationSaveDto)
        {
            return await _notificationService.EditAsync(id, notificationSaveDto);
        }

        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public async Task<NotificationDto> Delete(int id)
        {
            return await _notificationService.DisabledAsync(id);
        }
    }
}
