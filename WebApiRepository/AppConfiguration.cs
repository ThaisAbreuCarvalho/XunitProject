using Microsoft.Extensions.Configuration;
using System.IO;
using WebApiDomain.Interfaces.Repository;

namespace WebApiRepository
{
    public class AppConfiguration : IAppConfiguration
    {
        public string GetProperty(string configKeyName)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = config.Build();
            return configuration.GetSection(configKeyName).Value;
        }
    }
}
