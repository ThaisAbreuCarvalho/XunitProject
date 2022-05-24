using AutoMapper;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApiDomain.Interfaces.Logic;
using WebApiDomain.Model;

namespace WebApiDomain
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IMapper _mapper;

        public LoginLogic(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<AccessTokenResponse> GetAccessTokenAsync(AccessTokenRequest request)
        {
            var accessTokenRequest = _mapper.Map<AccessToken>(request);

            return null;
        }
    }
}
