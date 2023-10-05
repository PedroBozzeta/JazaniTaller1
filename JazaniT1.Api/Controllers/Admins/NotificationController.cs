using JazaniT1.Application.Admins.Dtos.Notifications;
using JazaniT1.Application.Admins.Services;
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
        public async Task<NotificationDto> Get(int id)
        {
            return await _notificationService.FindByIdAsync(id);
        }

        // POST api/<NotificationController>
        [HttpPost]
        public async Task<NotificationDto> Post([FromBody] NotificationSaveDto notificationSaveDto)
        {
            return await _notificationService.CreateAsync(notificationSaveDto);
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
