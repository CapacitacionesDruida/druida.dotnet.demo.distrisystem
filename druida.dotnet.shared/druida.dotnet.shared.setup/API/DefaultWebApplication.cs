using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using druida.dotnet.shared.serialization;
using Microsoft.AspNetCore.Http;
using druida.dotnet.shared.setup.API.Infrastructure;
using System.Reflection;

namespace druida.dotnet.shared.setup.API
{
    public static class DefaultWebApplication
    {
        public static WebApplication Create(string[] args, Action<WebApplicationBuilder>? webappBuilder = null)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddConfiguration(HealthCheckHelper.BuildBasicHealthCheck());
            builder.Services.AddHealthChecks();
            builder.Services.AddHealthChecksUI().AddInMemoryStorage();
            builder.Services.AddControllers();            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApiDocument((configure, sp) =>
                configure.Title = "Druida DistriSystem Order API"
            );
            builder.Services.AddRouting(x => x.LowercaseUrls = true);
            builder.Services.AddSerializer();

            //builder.Services.AddServiceDiscovery(builder.Configuration);
            //builder.Services.AddSecretManager(builder.Configuration);
            //builder.Services.AddLogging(logger => logger.AddSerilog());
            //builder.Services.AddTracing(builder.Configuration);
            //builder.Services.AddMetrics(builder.Configuration);



            //builder.Host.ConfigureSerilog(builder.Services.BuildServiceProvider().GetRequiredService<IServiceDiscovery>());

            if (webappBuilder != null)
            {
                webappBuilder.Invoke(builder);
            }

            return builder.Build();
        }

        public static void Run(WebApplication webApp, Assembly assembly)
        {
            webApp.UseHttpsRedirection();
            webApp.UseStaticFiles();

            webApp.UseSwaggerUi(settings =>
            {                
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            webApp.MapHealthChecks("/health");
            webApp.UseHealthChecks("/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            webApp.UseHealthChecksUI(config =>
            {
                config.UIPath = "/health-ui";
            });


            webApp.Map("/", () => Results.Redirect("/api"));

            webApp.UseAuthorization();
            webApp.MapControllers();
            webApp.MapEndpoints(assembly);
            webApp.Run();
        }
    }
}
