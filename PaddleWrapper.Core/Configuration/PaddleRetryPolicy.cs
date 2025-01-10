using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using PaddleWrapper.Core.Interfaces;

namespace PaddleWrapper.Core.Configuration
{
    public static class PaddleRetryPolicy
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(IPaddleLogger logger)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
#if NETSTANDARD2_1_OR_GREATER
                .OrResult(msg => msg.StatusCode == HttpStatusCode.TooManyRequests)
#else
                .OrResult(msg => msg.StatusCode == (HttpStatusCode)429)
#endif
                .WaitAndRetryAsync(
                    3, // Retry count
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // Exponential backoff
                    onRetry: (exception, timeSpan, retryCount, context) =>
                    {
                        logger.LogWarning(
                            $"Retry {retryCount} of {context.OperationKey} " +
                            $"after {timeSpan.TotalSeconds} seconds due to: {exception.Exception?.Message ?? exception.Result.StatusCode.ToString()}");
                    }
                );
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(IPaddleLogger logger)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30),
                    onBreak: (exception, duration) =>
                    {
                        logger.LogError($"Circuit breaker opened for {duration.TotalSeconds} seconds due to: {exception.Exception?.Message ?? exception.Result.StatusCode.ToString()}");
                    },
                    onReset: () =>
                    {
                        logger.LogInformation("Circuit breaker reset");
                    }
                );
        }

        public static IHttpClientBuilder AddPaddleRetryPolicies(
            this IHttpClientBuilder builder,
            IPaddleLogger logger)
        {
            return builder
                .AddPolicyHandler(GetRetryPolicy(logger))
                .AddPolicyHandler(GetCircuitBreakerPolicy(logger));
        }
    }
} 