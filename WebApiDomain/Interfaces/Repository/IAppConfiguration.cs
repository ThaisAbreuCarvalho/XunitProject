namespace WebApiDomain.Interfaces.Repository
{
    public interface IAppConfiguration
    {
        string GetProperty(string value);
    }
}
