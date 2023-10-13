using JazaniT1.Core.Securities.Entities;

namespace JazaniT1.Application.Admins.Dtos.Users
{
    public class UserSecurityDto : UserDto
    {
       public SecurityEntity Security { get; set; }
    }
}
