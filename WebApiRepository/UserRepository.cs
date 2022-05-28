using System.Data;
using WebApiDomain.Interface.Repository;
using WebApiDomain.Interfaces.Repository;
using Dapper;
using System.Data.SqlClient;
using WebApiDomain.Entity;
using System.Linq;

namespace WebApiRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IAppConfiguration configuration) : base(configuration)
        {
        }

        public void teste()
        {
            var teste = _dbConnection.Query<User>("Select * from [dbo].[User];").ToList();
        }
    }
}