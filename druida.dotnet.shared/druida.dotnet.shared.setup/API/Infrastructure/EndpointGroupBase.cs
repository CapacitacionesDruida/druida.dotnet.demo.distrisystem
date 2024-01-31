using Microsoft.AspNetCore.Builder;

namespace druida.dotnet.shared.setup.API.Infrastructure;

public abstract class EndpointGroupBase
{
    public abstract void Map(WebApplication app);
}

