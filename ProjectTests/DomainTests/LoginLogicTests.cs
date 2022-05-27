using AutoMapper;
using Moq;
using ProjectTests.Builder;
using System.Threading.Tasks;
using WebApiDomain;
using WebApiDomain.Automapper;
using WebApiDomain.Interface.Repository;
using Xunit;

namespace ProjectTests.DomainTests
{
    public class LoginLogicTests
    {
        private readonly LoginLogic _loginLogic;
        private static IMapper _mapper;

        public LoginLogicTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AccessTokenAutomapper());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _loginLogic = new LoginLogic(_mapper, new Mock<IUserRepository>().Object);
        }

        [Fact(DisplayName = "ShouldNotReturnTokenWhenRequestIsValid")]
        public void ShouldNotReturnTokenWhenRequestIsValid()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "ShouldReturnTokenWhenRequestIsValid")]
        public async Task ShouldReturnTokenWhenRequestIsValid()
        {
            var accessTokenRequest = new AccessTokenBuilder().BuildValidAcessTokenRequest();
            var result = await _loginLogic.GetAccessTokenAsync(accessTokenRequest).ConfigureAwait(false);

            Assert.True(false);
        }

        [Theory(DisplayName = "ShouldNotAcceptInvalidUserEmail")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("654653453")]
        [InlineData("asdfsdefwes")]
        [InlineData("Select * from dbo.\"User\"")]
        [InlineData("user@")]
        [InlineData("user.com")]
        public async Task ShouldNotAcceptInvalidUserEmail(string userEmail)
        {
            var accessTokenRequest = new AccessTokenBuilder().BuildValidAcessTokenRequest();
            accessTokenRequest.UserEmail = userEmail;

            var result = await _loginLogic.GetAccessTokenAsync(accessTokenRequest).ConfigureAwait(false);
            var sucess = result.ErrorMessages.Contains("Invalid user email");
            Assert.True(sucess);
        }

        [Theory(DisplayName = "ShouldNotAcceptInvalidUserPassword")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("asddddd54655445645ddddddddassssssssssregw")]
        [InlineData("asd")]
        [InlineData("asd 476464")]
        [InlineData("Select * from dbo.\"Users\"")]
        public async Task ShouldNotAcceptInvalidUserPassword(string password)
        {
            var accessTokenRequest = new AccessTokenBuilder().BuildValidAcessTokenRequest();
            accessTokenRequest.Password = password;

            var result = await _loginLogic.GetAccessTokenAsync(accessTokenRequest).ConfigureAwait(false);
            var sucess = result.ErrorMessages.Contains("Invalid password");
            Assert.True(sucess);
        }

        [Fact(DisplayName = "ShouldAcceptValidUserCredentials")]
        public async Task ShouldAcceptValidUserCredentials()
        {
            var accessTokenRequest = new AccessTokenBuilder().BuildValidAcessTokenRequest();
            var result = await _loginLogic.GetAccessTokenAsync(accessTokenRequest).ConfigureAwait(false);
            Assert.True(result.Sucess);
        }
    }
}
