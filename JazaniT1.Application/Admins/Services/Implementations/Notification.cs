using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Notifications;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<NotificationService> _logger;
        public NotificationService(INotificationRepository notificationRepository, IMapper mapper,ILogger<NotificationService> logger)
        {
            _notificationRepository = notificationRepository;

            _mapper = mapper;

            _logger = logger;
        }

        public async Task<NotificationDto> CreateAsync(NotificationSaveDto notificationSaveDto)
        {
            Notification notification = _mapper.Map<Notification>(notificationSaveDto);
            notification.RegistrationDate = DateTime.Now;
            notification.State = true;
             await _notificationRepository.SaveAsync(notification);

            return _mapper.Map<NotificationDto>(notification);
        }

        public async Task<NotificationDto> DisabledAsync(int id)
        {
            Notification notification = await _notificationRepository.FindByIdAsync(id);
            if (notification == null)
            {
                _logger.LogWarning("Notificación no encontrada para el id " + id);
                throw NotificationNotFound(id);
            }

            notification.State = false;

            await _notificationRepository.SaveAsync(notification);

            return _mapper.Map<NotificationDto>(notification);
        }

        public async Task<NotificationDto?> EditAsync(int id, NotificationSaveDto notificationSaveDto)
        {
            Notification notification = await _notificationRepository.FindByIdAsync(id);
            if (notification == null)
            {

                _logger.LogWarning("Notificación no encontrada para el id " + id);
                throw NotificationNotFound(id);
            }

            _mapper.Map<NotificationSaveDto, Notification>(notificationSaveDto, notification);
            
            return _mapper.Map<NotificationDto>(notification);
        }

        public async Task<IReadOnlyList<NotificationDto>> FindAllAsync()
        {
            IReadOnlyList<Notification> notifications = await _notificationRepository.FindAllAsync();
            
            return _mapper.Map<IReadOnlyList<NotificationDto>>(notifications);
        }

        public async Task<NotificationDto?> FindByIdAsync(int id)
        {
            Notification? notification = await _notificationRepository.FindByIdAsync(id);
            if (notification == null)
            {
                _logger.LogWarning("Notificación no encontrada para el id " + id);
                throw NotificationNotFound(id);
            }

            return _mapper.Map<NotificationDto>(notification);
        }
        private NotFoundCoreException NotificationNotFound(int id)
        {
            return new NotFoundCoreException("Notificación no encontrado para el id " + id);
        }
    }
}
