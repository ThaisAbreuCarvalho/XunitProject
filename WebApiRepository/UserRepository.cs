using WebApiDomain.Interface.Repository;
using WebApiDomain.Interfaces.Repository;

namespace WebApiRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppConfiguration _appConfig;
        private readonly string _connection;

        public UserRepository(IAppConfiguration appConfiguration)
        {
            _appConfig = appConfiguration;
            _connection = _appConfig.GetProperty("ConnectionStrings:secret");
        }

        public void teste()
        {
            var teste = _connection;
        }
    }
}
