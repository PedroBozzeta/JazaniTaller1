using AutoMapper;
using JazaniT1.Domain.Admins.Models;

namespace JazaniT1.Application.Admins.Dtos.Users.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserSecurityDto>();
            CreateMap<User,UserSaveDto>().ReverseMap();     
        }
    }
}
