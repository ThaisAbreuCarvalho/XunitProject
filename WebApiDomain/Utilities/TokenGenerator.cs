using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DTO;
using WebApiDomain.Interfaces.Repository;

namespace WebApiDomain.Utilities
{
    public static class TokenGenerator
    {
        private static readonly IAppConfiguration _appConfig;
        private static string API_KEY => _appConfig.GetProperty("ConnectionStrings.ApiSecret");

        public static AccessTokenResponse GenerateToken(string userName, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(API_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.Name, userName),
                     new Claim(ClaimTypes.Role, password)
                 }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AccessTokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                Type = "bearer",
                ExpirationTime = tokenDescriptor.Expires.ToString(),
                RefreshToken = tokenHandler.WriteToken(token)
            };
        }
    }
}
