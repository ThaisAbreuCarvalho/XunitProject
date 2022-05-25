using System.Threading.Tasks;
using WebApi.DTO;
using WebApiDomain.DTO;

namespace WebApiDomain.Interfaces.Logic
{
    public interface ILoginLogic
    {
        Task<Result<AccessTokenResponse>> GetAccessTokenAsync(AccessTokenRequest request);
    }
}
