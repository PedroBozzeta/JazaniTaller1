
namespace JazaniT1.Domain.Admins.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string? Name { get; set; } = default;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public virtual NotificationAction NotificationAction { get; set; }
    }
}
