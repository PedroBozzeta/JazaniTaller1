using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Notifications;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Admins.Dtos.NotificationActions.Profiles
{
    public class NotificationActionProfile:Profile
    {
        public NotificationActionProfile()
        {
            CreateMap<NotificationAction, NotificationActionDto>();
            CreateMap<NotificationAction, NotificationActionSimpleDto>().ReverseMap();
            CreateMap<NotificationAction, NotificationActionSaveDto>();
            CreateMap<NotificationActionSaveDto, NotificationAction>();
        }
    }
}
