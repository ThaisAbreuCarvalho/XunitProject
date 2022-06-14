using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApiDomain.DTO;
using WebApiDomain.Entity;
using WebApiDomain.Interface.Repository;
using WebApiDomain.Interfaces.Logic;
using WebApiDomain.Interfaces.Services;
using WebApiDomain.Utilities;

namespace WebApiDomain
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;
        public LoginLogic(IMapper mapper, IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
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

            var user = await GetUser(accessTokenRequest.UserEmail, accessTokenRequest.Password).ConfigureAwait(false);
           
            if (user == null)
            {
                result.ErrorMessages.Add("User register not found.");
                return result;
            }

            result.Response = _tokenGenerator.GenerateToken(user.Name, user.Password);

            return result;
        }

        private async Task<User> GetUser(string email, string password)
        {
            var user = await _userRepository.SelectAsync(new User { Email = email, Password = password }).ConfigureAwait(false);
            return user?.FirstOrDefault();
        }
    }
}
