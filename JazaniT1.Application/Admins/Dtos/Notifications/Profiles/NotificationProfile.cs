using JazaniT1.Domain.Admins.Models;
using AutoMapper;

namespace JazaniT1.Application.Admins.Dtos.Notifications.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationDto, NotificationSaveDto>().ReverseMap();
        }
    }
}
