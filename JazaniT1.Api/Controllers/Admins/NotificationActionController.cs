using JazaniT1.Application.Admins.Dtos.NotificationActions;
using JazaniT1.Application.Admins.Services;
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
        public async Task<NotificationActionDto> Get(int id)
        {
            return await _notificationActionService.FindByIdAsync(id);
        }

        // POST api/<NotificationActionController>
        [HttpPost]
        public async Task<NotificationActionDto> Post([FromBody] NotificationActionSaveDto notificationActionSaveDto)
        {
            return await _notificationActionService.CreateAsync(notificationActionSaveDto);
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
