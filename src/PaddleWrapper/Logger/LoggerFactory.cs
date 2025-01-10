using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace PaddleWrapper.Logger
{
    public static class LoggerFactory
    {
        public static ILogger GetLogger(LogLevel logLevel = LogLevel.Information, string logFilePath = null)
        {
            if (string.IsNullOrEmpty(logFilePath))
            {
                return new NullLogger();
            }

            Serilog.Core.Logger serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Is(ConvertLogLevel(logLevel))
                .WriteTo.File(logFilePath,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day)
                .Enrich.With(new CustomLogEnricher())
                .CreateLogger();

            ILoggerFactory factory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder
                    .SetMinimumLevel(logLevel)
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddSerilog(serilogLogger, dispose: true);
            });

            return factory.CreateLogger("PaddleWrapper");
        }

        private static LogEventLevel ConvertLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => LogEventLevel.Verbose,
                LogLevel.Debug => LogEventLevel.Debug,
                LogLevel.Information => LogEventLevel.Information,
                LogLevel.Warning => LogEventLevel.Warning,
                LogLevel.Error => LogEventLevel.Error,
                LogLevel.Critical => LogEventLevel.Fatal,
                _ => LogEventLevel.Information
            };
        }
    }

    internal class CustomLogEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            string renderedMessage = logEvent.RenderMessage();
            string filteredMessage = CustomLogger.FilterSensitiveData(renderedMessage);

            logEvent.AddOrUpdateProperty(new LogEventProperty(
                "Message",
                new ScalarValue(filteredMessage)
            ));
        }
    }
}