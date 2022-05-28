using AutoMapper;
using System;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApiDomain.DTO;
using WebApiDomain.Entity;
using WebApiDomain.Interface.Repository;
using WebApiDomain.Interfaces.Logic;
using WebApiDomain.Utilities;

namespace WebApiDomain
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public LoginLogic(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
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

            var userValidated = await GetUser(accessTokenRequest.UserEmail, accessTokenRequest.Password).ConfigureAwait(false);

            if (!userValidated.Sucess)
            {
                result.ErrorMessages.AddRange(userValidated.ErrorMessages);
                return result;
            }

            return result;
        }

        private async Task<Result<User>> GetUser(string email, string password)
        {
            var result = new Result<User>();

            try
            {
                _userRepository.GetAsync(new User { Name = "Thais" });
            }
            catch (Exception e)
            {
                result.ErrorMessages.AddRange(ErrorFormatter.FormatException(e));
            }

            return result;
        }
    }
}
