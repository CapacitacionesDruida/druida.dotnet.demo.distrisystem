using druida.dotnet.shared.logging.appinsights.Interfaces;
using Microsoft.ApplicationInsights.Extensibility;
using Serilog.Events;

namespace druida.dotnet.shared.logging.appinsights.Loggers;

public class AppInsightsLoggerConfiguration : ILoggerConfiguration
{
    public bool Enabled { get; set; } = false;
    public LogEventLevel MinimumLevel { get; set; }
    public required TelemetryConfiguration telemetryConfiguration { get; set; }
}
