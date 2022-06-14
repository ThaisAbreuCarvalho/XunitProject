using WebApi.DTO;

namespace WebApiDomain.Interfaces.Services
{
    public interface ITokenGenerator
    {
        AccessTokenResponse GenerateToken(string userName, string password);
    }
}
