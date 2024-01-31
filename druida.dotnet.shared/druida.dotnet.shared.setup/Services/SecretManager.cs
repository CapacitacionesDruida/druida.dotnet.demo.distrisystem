using druida.dotnet.shared.discovery.consul;
using druida.dotnet.shared.secrets.hashicorpvault;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace druida.dotnet.shared.setup.Services;

public static class SecretManager
{
    public static void AddSecretManager(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        //TODO: create an awaiter project instead of .result everywhere in the config
        string discoveredUrl = GetVaultUrl(serviceCollection.BuildServiceProvider()).Result;
        serviceCollection.AddVaultService(configuration, discoveredUrl);
    }

    private static async Task<string> GetVaultUrl(IServiceProvider serviceProvider)
    {
        var serviceDiscovery = serviceProvider.GetService<IServiceDiscovery>();
        return await serviceDiscovery?.GetFullAddress(DiscoveryServices.Secrets)!;
    }
}
