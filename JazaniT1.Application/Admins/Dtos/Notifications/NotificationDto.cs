using JazaniT1.Application.Admins.Dtos.NotificationActions;

namespace JazaniT1.Application.Admins.Dtos.Notifications
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string? Description { get; set; }
        public NotificationActionSimpleDto NotificationAction { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
