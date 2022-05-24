using System.Threading.Tasks;
using WebApi.DTO;

namespace WebApiDomain.Interfaces.Logic
{
    public interface ILoginLogic
    {
        Task<AccessTokenResponse> GetAccessTokenAsync(AccessTokenRequest request);
    }
}
