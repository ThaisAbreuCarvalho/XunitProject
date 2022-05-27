using Bogus;
using System;
using WebApi.DTO;
using WebApiDomain.Constant;

namespace ProjectTests.Builder
{
    public class AccessTokenBuilder
    {
        private Faker _faker = new Faker();

        public static AccessTokenBuilder Builder()
        {
            return new AccessTokenBuilder();
        }

        public AccessTokenRequest BuildValidAcessTokenRequest()
        {
            return new AccessTokenRequest
            {
                UserEmail = _faker.Person.Email,
                Password = _faker.Random.AlphaNumeric(7) + "*",
            };
        }

        public AccessTokenRequest BuildInvalidAcessTokenRequest()
        {
            return new AccessTokenRequest
            {
                UserEmail = "",
                Password = _faker.Random.AlphaNumeric(9)
            };
        }

        public AccessTokenResponse BuildValidAcessTokenResponse()
        {
            return new AccessTokenResponse
            {
                Type = DomainConst.TokenType,
                ExpirationTime = DateTime.Now.AddMinutes(30).ToString(),
            };
        }
    }
}
