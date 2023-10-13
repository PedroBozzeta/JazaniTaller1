using JazaniT1.Application.Generals.Dtos.NotificationActions;

namespace JazaniT1.Application.Generals.Services
{
    public interface INotificationActionService
    {
        Task<IReadOnlyList<NotificationActionDto>> FindAllAsync();
        Task<NotificationActionDto?> FindByIdAsync(int id);
        Task<NotificationActionDto?> CreateAsync(NotificationActionSaveDto notificationActionSaveDto);
        Task<NotificationActionDto?> EditAsync(int id, NotificationActionSaveDto notificationActionSaveDto);
        Task<NotificationActionDto?> DisabledAsync(int id);
    }
}
