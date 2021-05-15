using FruitStore.Infrastructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace FruitStore.Infrastructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
