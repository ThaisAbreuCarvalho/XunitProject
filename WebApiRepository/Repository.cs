using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiDomain.Interfaces.Repository;
using Dapper;
using System.Linq;

namespace WebApiRepository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly IAppConfiguration _appConfig;
        private readonly string _connection;
        public IDbConnection _dbConnection;

        public Repository(IAppConfiguration appConfiguration)
        {
            _appConfig = appConfiguration;
            _connection = _appConfig.GetProperty("ConnectionStrings:secret");
            _dbConnection = new SqlConnection(_connection);
        }

        public int DeleteAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAsync(T entity)
        {
            return _dbConnection.Query<T>("").ToList();
        }

        public List<int> InsertAsync(List<T> entity)
        {
            throw new System.NotImplementedException();
        }

        public int InsertAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
