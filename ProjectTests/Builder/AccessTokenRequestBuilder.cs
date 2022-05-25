using WebApi.DTO;

namespace ProjectTests.Builder
{
    public class AccessTokenRequestBuilder
    {
        public static AccessTokenRequestBuilder AccessTokenBuilder()
        {
            return new AccessTokenRequestBuilder();
        }

        public AccessTokenRequest BuildValidAcessTokenRequest()
        {
            return new AccessTokenRequest
            {
               
            };
        }

        public AccessTokenRequest BuildInvalidAcessTokenRequest()
        {
            return new AccessTokenRequest
            {

            };
        }
    }
}
