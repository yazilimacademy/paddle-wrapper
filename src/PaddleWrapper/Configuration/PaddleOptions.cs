using System;

namespace PaddleWrapper.Configuration
{
    /// <summary>
    /// Configuration options for the Paddle API client
    /// </summary>
    public class PaddleOptions
    {
        /// <summary>
        /// The Paddle API key used for authentication
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The base URL for the Paddle API. Defaults to https://api.paddle.com
        /// </summary>
        public string BaseUrl { get; set; } = "https://api.paddle.com";

        /// <summary>
        /// Whether to use the sandbox environment. If true, uses https://sandbox-api.paddle.com
        /// </summary>
        public bool UseSandbox { get; set; }

        /// <summary>
        /// Timeout for API requests in seconds. Defaults to 30 seconds
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30;

        /// <summary>
        /// Maximum number of retry attempts for failed requests. Defaults to 3
        /// </summary>
        public int MaxRetryAttempts { get; set; } = 3;

        /// <summary>
        /// Validates the configuration options
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
            {
                throw new ArgumentException("API key must be provided", nameof(ApiKey));
            }

            if (string.IsNullOrWhiteSpace(BaseUrl))
            {
                throw new ArgumentException("Base URL must be provided", nameof(BaseUrl));
            }

            if (TimeoutSeconds <= 0)
            {
                throw new ArgumentException("Timeout must be greater than 0", nameof(TimeoutSeconds));
            }

            if (MaxRetryAttempts < 0)
            {
                throw new ArgumentException("Max retry attempts must be greater than or equal to 0", nameof(MaxRetryAttempts));
            }
        }

        /// <summary>
        /// Gets the effective base URL based on whether sandbox mode is enabled
        /// </summary>
        public string GetEffectiveBaseUrl()
        {
            return UseSandbox ? "https://sandbox-api.paddle.com" : BaseUrl;
        }
    }
}