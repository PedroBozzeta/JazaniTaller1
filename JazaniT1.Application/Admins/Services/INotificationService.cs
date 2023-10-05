using JazaniT1.Application.Admins.Dtos.Notifications;

namespace JazaniT1.Application.Admins.Services
{
    public interface INotificationService
    {
        Task<IReadOnlyList<NotificationDto>> FindAllAsync();
        Task<NotificationDto?> FindByIdAsync(int id);
        Task<NotificationDto?> CreateAsync(NotificationSaveDto notificationSaveDto);
        Task<NotificationDto?> EditAsync(int id, NotificationSaveDto notificationSaveDto);
        Task<NotificationDto?> DisabledAsync(int id);
    }
}
