using AutoMapper;
using JazaniT1.Application.Admins.Dtos.NotificationActions;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class NotificationActionService : INotificationActionService
    {
        private readonly INotificationActionRepository _notificationActionRepository;

        private readonly IMapper _mapper;
        public NotificationActionService(INotificationActionRepository notificationActionRepository, IMapper mapper)
        {
            _notificationActionRepository = notificationActionRepository;

            _mapper = mapper;
        }

        public async Task<NotificationActionDto> CreateAsync(NotificationActionSaveDto notificationActionSaveDto)
        {
            NotificationAction notificationAction = _mapper.Map<NotificationAction>(notificationActionSaveDto);
            notificationAction.RegistrationDate = DateTime.Now;
            notificationAction.State = true;

            NotificationAction notificationActionSaved = await _notificationActionRepository.SaveAsync(notificationAction);

            return _mapper.Map<NotificationActionDto>(notificationActionSaved);
        }

        public async Task<NotificationActionDto> DisabledAsync(int id)
        {
            NotificationAction notificationAction = await _notificationActionRepository.FindByIdAsync(id);
            notificationAction.State = false;

            NotificationAction notificationActionSaved = await _notificationActionRepository.SaveAsync(notificationAction);

            return _mapper.Map<NotificationActionDto>(notificationActionSaved);
        }

        public async Task<NotificationActionDto?> EditAsync(int id, NotificationActionSaveDto notificationActionSaveDto)
        {
            NotificationAction notificationAction = await _notificationActionRepository.FindByIdAsync(id);

            _mapper.Map<NotificationActionSaveDto, NotificationAction>(notificationActionSaveDto, notificationAction);
            NotificationAction notificationActionSaved = await _notificationActionRepository.SaveAsync(notificationAction);

            return _mapper.Map<NotificationActionDto>(notificationActionSaved);
        }

        public async Task<IReadOnlyList<NotificationActionDto>> FindAllAsync()
        {
            IReadOnlyList<NotificationAction> notificationActions = await _notificationActionRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<NotificationActionDto>>(notificationActions);
        }

        public async Task<NotificationActionDto?> FindByIdAsync(int id)
        {
            NotificationAction? notificationAction = await _notificationActionRepository.FindByIdAsync(id);

            return _mapper.Map<NotificationActionDto>(notificationAction);
        }
    }
}
