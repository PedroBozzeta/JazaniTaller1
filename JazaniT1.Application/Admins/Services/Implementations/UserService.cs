using AutoMapper;
using JazaniT1.Application.Admins.Dtos.Users;
using JazaniT1.Application.Cores.Exceptions;
using JazaniT1.Core.Securities.Services;
using JazaniT1.Domain.Admins.Models;
using JazaniT1.Domain.Admins.Repositories;
using Microsoft.Extensions.Configuration;

namespace JazaniT1.Application.Admins.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IMapper mapper, ISecurityService securityService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _securityService = securityService;
            _configuration = configuration;
        }

        public async Task<UserDto> CreateAsync(UserSaveDto saveDto)
        {
            User user = _mapper.Map<User>(saveDto);
            user.State = true;
            user.RegistrationDate=DateTime.Now;

            user.Password = _securityService.HashPassword(saveDto.Email, saveDto.Password);
            await _userRepository.SaveAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public Task<UserDto> EditAsync(int id, UserSaveDto saveDto)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSecurityDto> LoginAsync(UserAuthDto userAuthDto)
        {
            User? user = await _userRepository.FindByEmailAsync(userAuthDto.Email);
            if (user is null) throw new NotFoundCoreException("Usuario no registrado");
            bool isCorrect = _securityService.VerifyHashedPassword(user.Email, user.Password, userAuthDto.Password);

            if (!isCorrect) throw new NotFoundCoreException("La contraseña no es correcta");

            if (!user.State) throw new NotFoundCoreException("Usuario inactivo");
            UserSecurityDto userSecurity = _mapper.Map<UserSecurityDto>(user);
            string jwtSecretKey = _configuration.GetSection("Security:JwtSecretKey").Get<string>();

            userSecurity.Security = _securityService.JwtSecurity(jwtSecretKey);

            return userSecurity;

        }
    }
}
