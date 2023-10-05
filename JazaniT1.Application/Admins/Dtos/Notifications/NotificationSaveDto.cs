namespace JazaniT1.Application.Admins.Dtos.Notifications
{
    public class NotificationSaveDto
    {
        public string Name { get; set; } = default;
        public string? Description { get; set; }
        public int NotificationActionId { get; set; }
    }
}
