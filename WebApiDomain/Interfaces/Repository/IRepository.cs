using System.Collections.Generic;

namespace WebApiDomain.Interfaces.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAsync(T entity);
        List<int> InsertAsync(List<T> entity);
        int InsertAsync(T entity);
        int DeleteAsync(T entity);
        void UpdateAsync(T entity);
    }
}
