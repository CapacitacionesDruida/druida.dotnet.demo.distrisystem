using Serilog.Events;

namespace druida.dotnet.shared.logging.appinsights.Interfaces;

public interface ILoggerConfiguration
{
    public bool Enabled { get; set; }
    public LogEventLevel MinimumLevel { get; set; }
}
