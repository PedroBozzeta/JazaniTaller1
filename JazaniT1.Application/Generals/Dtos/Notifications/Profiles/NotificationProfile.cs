using JazaniT1.Domain.Admins.Models;
using AutoMapper;
using JazaniT1.Application.Generals.Dtos.Notifications;

namespace JazaniT1.Application.Generals.Dtos.Notifications.Profiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationDto, NotificationSaveDto>().ReverseMap();
            CreateMap<NotificationSaveDto, Notification>();
        }
    }
}
