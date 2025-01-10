using System;

namespace PaddleWrapper.Core.Interfaces
{
    public interface IPaddleLogger
    {
        void LogDebug(string message);
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception exception = null);
        void LogCritical(string message, Exception exception = null);
    }
} 