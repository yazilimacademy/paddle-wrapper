using Microsoft.Extensions.Logging;
using PaddleWrapper.Core.Interfaces;

namespace PaddleWrapper.Core.Services
{
    public class DefaultPaddleLogger : IPaddleLogger
    {
        private readonly ILogger<DefaultPaddleLogger> _logger;

        public DefaultPaddleLogger(ILogger<DefaultPaddleLogger> logger)
        {
            _logger = logger;
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message, Exception exception = null)
        {
            if (exception != null)
            {
                _logger.LogError(exception, message);
            }
            else
            {
                _logger.LogError(message);
            }
        }

        public void LogCritical(string message, Exception exception = null)
        {
            if (exception != null)
            {
                _logger.LogCritical(exception, message);
            }
            else
            {
                _logger.LogCritical(message);
            }
        }
    }
}