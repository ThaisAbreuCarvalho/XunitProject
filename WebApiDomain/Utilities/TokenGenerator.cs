using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DTO;
using WebApiDomain.Interfaces.Repository;
using WebApiDomain.Interfaces.Services;

namespace WebApiDomain.Utilities
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IAppConfiguration _appConfig;
        private string API_KEY => _appConfig.GetProperty("ConnectionStrings:ApiSecret");

        public TokenGenerator(IAppConfiguration appConfiguration)
        {
            _appConfig = appConfiguration;
        }

        public AccessTokenResponse GenerateToken(string userName, string password)
        {
            var claims = new Claim[] { new Claim(ClaimTypes.Name, userName), new Claim(ClaimTypes.Role, password) };
            var securityToken = GenerateToken(claims);
            return securityToken;
        }

        private AccessTokenResponse GenerateToken(Claim[] info)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(API_KEY);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(info),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token  =  tokenHandler.CreateToken(tokenDescriptor);

            return new AccessTokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                Type = "bearer",
                ExpirationTime = DateTime.Now.AddMinutes(15).ToString()
            };
        }
    }
}
