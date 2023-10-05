﻿using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Notifications;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        private readonly IMapper _mapper;
        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;

            _mapper = mapper;
        }

        public async Task<NotificationDto> CreateAsync(NotificationSaveDto notificationSaveDto)
        {
            Notification notification = _mapper.Map<Notification>(notificationSaveDto);
            notification.RegistrationDate = DateTime.Now;
            notification.State = true;

            Notification notificationSaved = await _notificationRepository.SaveAsync(notification);

            return _mapper.Map<NotificationDto>(notificationSaved);
        }

        public async Task<NotificationDto> DisabledAsync(int id)
        {
            Notification notification = await _notificationRepository.FindByIdAsync(id);
            notification.State = false;

            Notification notificationSaved = await _notificationRepository.SaveAsync(notification);

            return _mapper.Map<NotificationDto>(notificationSaved);
        }

        public async Task<NotificationDto?> EditAsync(int id, NotificationSaveDto notificationSaveDto)
        {
            Notification notification = await _notificationRepository.FindByIdAsync(id);

            _mapper.Map<NotificationSaveDto, Notification>(notificationSaveDto, notification);
            Notification notificationSaved = await _notificationRepository.SaveAsync(notification);

            return _mapper.Map<NotificationDto>(notificationSaved);
        }

        public async Task<IReadOnlyList<NotificationDto>> FindAllAsync()
        {
            IReadOnlyList<Notification> notifications = await _notificationRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<NotificationDto>>(notifications);
        }

        public async Task<NotificationDto?> FindByIdAsync(int id)
        {
            Notification? notification = await _notificationRepository.FindByIdAsync(id);

            return _mapper.Map<NotificationDto>(notification);
        }
    }
}
