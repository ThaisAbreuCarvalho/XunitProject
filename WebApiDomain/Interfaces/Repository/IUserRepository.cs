using WebApiDomain.Entity;
using WebApiDomain.Interfaces.Repository;

namespace WebApiDomain.Interface.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public void teste();
    }
}
