using JazaniT1.Application.Generals.Dtos.Notifications;

namespace JazaniT1.Application.Generals.Services
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
