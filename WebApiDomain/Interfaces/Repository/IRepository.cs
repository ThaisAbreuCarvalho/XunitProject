using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiDomain.Interfaces.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> SelectAsync(T entity);
        Task InsertAsync(List<T> entity);
        Task<int> InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
