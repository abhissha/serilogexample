using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace HttpContextMiddleware.Extensions
{
    public static class SerilogConfigurationExtension
    {
        public static void ConfigureSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            // configure serilog with singleton
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Debug()
                                .Enrich.FromLogContext()
                                .WriteTo.Console()
                                .WriteTo.ApplicationInsights(configuration.GetInstrumentationKey(), TelemetryConverter.Traces)
                                .CreateLogger();

            services.AddSingleton<Serilog.ILogger>(Log.Logger);
        }
    }
}
