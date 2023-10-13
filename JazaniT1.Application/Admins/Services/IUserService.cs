using Jazani.Application.Cores.Services;
using JazaniT1.Application.Admins.Dtos.Users;

namespace JazaniT1.Application.Admins.Services
{
    public interface IUserService: ISaveService<UserDto,UserSaveDto,int>
    {
        Task<UserSecurityDto> LoginAsync(UserAuthDto userAuthDto);
    }
}
