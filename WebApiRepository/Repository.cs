using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApiDomain.Interfaces.Repository;
using Dapper;
using System.Linq;
using WebApiRepository.Utilities;
using System.Threading.Tasks;

namespace WebApiRepository
{
    public abstract class Repository<T> : IRepository<T>
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

        public async Task DeleteAsync(T entity)
        {
            var query = QueriesHelper<T>.Delete(entity);
            await _dbConnection.QueryAsync<T>(query).ConfigureAwait(false);
        }

        public async Task<List<T>> SelectAsync(T entity)
        {
            var query = await _dbConnection.QueryAsync<T>(QueriesHelper<T>.Select(entity)).ConfigureAwait(false);
            return query.ToList();
        }

        public async Task InsertAsync(List<T> entity)
        {
            var query = QueriesHelper<T>.Insert(entity);
            await _dbConnection.ExecuteAsync(query).ConfigureAwait(false);
        }

        public async Task<int> InsertAsync(T entity)
        {
            var query = QueriesHelper<T>.Insert(entity);
            return await _dbConnection.QuerySingleAsync<int>(query).ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            var query = QueriesHelper<T>.Update(entity);
            await _dbConnection.QueryAsync<T>(query).ConfigureAwait(false);
        }
    }
}
