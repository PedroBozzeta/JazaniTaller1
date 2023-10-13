using JazaniT1.Core.Securities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace JazaniT1.Core.Securities.Services.Implementations
{
    public class SecurityService : ISecurityService
    {
        public string HashPassword(string userName, string hashedPassword)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
            return passwordHasher.HashPassword(userName, hashedPassword);
        }


        public bool VerifyHashedPassword(string userName, string hashedPassword, string providedPassword)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(userName, hashedPassword, providedPassword);
            if(result==PasswordVerificationResult.Success)  return true;
            return false;

        }
        public SecurityEntity JwtSecurity(string JwtSecurityKey)
        {
            DateTime utcNow = DateTime.UtcNow;

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,utcNow.ToString())
            };
            DateTime expireDateTime = utcNow.AddDays(1);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //key

            byte[] key = Encoding.ASCII.GetBytes(JwtSecurityKey);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: expireDateTime,
                notBefore: utcNow,
                signingCredentials:signingCredentials
                );

            string token=jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return new SecurityEntity()
            {
                TokenType = "Bearer",
                AccessToken = token,
                ExpireOn = expireDateTime
            };

        }
    }
}
