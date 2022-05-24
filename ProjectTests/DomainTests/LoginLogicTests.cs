using AutoMapper;
using Moq;
using WebApiDomain;
using Xunit;

namespace ProjectTests.DomainTests
{
    public class LoginLogicTests
    {
        private readonly LoginLogic _loginLogic;

        public LoginLogicTests()
        {
            _loginLogic = new LoginLogic(new Mock<IMapper>().Object);
        }

        [Fact(DisplayName = "ShouldNotAcceptInvalidTokenRequest")]
        public void ShouldNotAcceptInvalidTokenRequest()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "ShouldAcceptValidTokenRequest")]
        public void ShouldAcceptValidTokenRequest()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "ShouldNotAcceptInvalidUserEmail")]
        public void ShouldNotAcceptInvalidUserEmail()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "ShouldNotAcceptValidUserEmail")]
        public void ShouldNotAcceptValidUserEmail()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "ShouldNotAcceptInvalidUserPassword")]
        public void ShouldNotAcceptInvalidUserPassword()
        {
            Assert.True(false);
        }

        [Fact(DisplayName = "ShouldNotAcceptValidUserPassword")]
        public void ShouldNotAcceptValidUserPassword()
        {
            Assert.True(false);
        }
    }
}
