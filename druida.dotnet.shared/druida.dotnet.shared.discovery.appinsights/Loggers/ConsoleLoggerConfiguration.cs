using druida.dotnet.shared.logging.appinsights.Interfaces;
using Serilog.Events;

namespace druida.dotnet.shared.logging.appinsights.Loggers;

public class ConsoleLoggerConfiguration: ILoggerConfiguration
{
    public bool Enabled { get; set; } = false;
    public LogEventLevel MinimumLevel { get; set; }
}
