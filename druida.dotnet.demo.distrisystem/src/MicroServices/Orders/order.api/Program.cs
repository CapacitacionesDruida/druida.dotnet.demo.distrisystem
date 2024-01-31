using druida.dotnet.shared.setup;
using druida.dotnet.shared.setup.API;
using System.Reflection;

WebApplication app = DefaultWebApplication.Create(args, builder =>
{
    
});


var assembly = Assembly.GetExecutingAssembly();

DefaultWebApplication.Run(app, assembly);