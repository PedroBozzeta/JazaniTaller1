using JazaniT1.Core.Securities.Entities;

namespace JazaniT1.Core.Securities.Services
{
    public interface ISecurityService
    {
        string HashPassword(string userName, string hashedPassword);
        bool VerifyHashedPassword(string userName, string hashedPassword, string providerPassword);

        SecurityEntity JwtSecurity(string JwtSecurityKey);
    }
}
