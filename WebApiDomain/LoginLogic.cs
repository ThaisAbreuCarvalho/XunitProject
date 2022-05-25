using AutoMapper;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApiDomain.DTO;
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

        public async Task<Result<AccessTokenResponse>> GetAccessTokenAsync(WebApi.DTO.AccessTokenRequest request)
        {
            var result = new Result<AccessTokenResponse>();
            var accessTokenRequest = _mapper.Map<Model.AccessTokenRequest>(request);
            var validate = await accessTokenRequest.IsValid().ConfigureAwait(false);

            if (!validate.IsValid)
            {
                validate.Errors.ForEach(x => result.ErrorMessages.Add(x.ErrorMessage));
                return result;
            }


            return null;
        }
    }
}
