using druida.dotnet.shared.databases.mysql;
using druida.dotnet.shared.discovery.consul;
using druida.dotnet.shared.secrets.hashicorpvault;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace druida.dotnet.shared.setup.Databases;

public static class MySql
{
    public static IServiceCollection AddMySql<T>(this IServiceCollection serviceCollection, string databaseName)
        where T : DbContext
    {
        return serviceCollection
            .AddMySqlDbContext<T>(serviceProvider => GetConnectionString(serviceProvider, databaseName))
            .AddMysqlHealthCheck(serviceProvider => GetConnectionString(serviceProvider, databaseName));
    }

    private static async Task<string> GetConnectionString(IServiceProvider serviceProvider, string databaseName)
    {
        ISecretManager secretManager = serviceProvider.GetRequiredService<ISecretManager>();
        IServiceDiscovery serviceDiscovery = serviceProvider.GetRequiredService<IServiceDiscovery>();

        DiscoveryData mysqlData = await serviceDiscovery.GetDiscoveryData(DiscoveryServices.MySql);
        MySqlCredentials credentials = await secretManager.Get<MySqlCredentials>("mysql");

        return
            $"Server={mysqlData.Server};Port={mysqlData.Port};Database={databaseName};Uid={credentials.username};password={credentials.password};";
    }


    private record MySqlCredentials
    {
        public string username { get; init; } = null!;
        public string password { get; init; } = null!;
    }
}