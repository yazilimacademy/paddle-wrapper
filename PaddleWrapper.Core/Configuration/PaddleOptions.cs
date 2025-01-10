namespace PaddleWrapper.Core.Configuration
{
    public class PaddleOptions
    {
        public string ApiKey { get; set; }
        public string VendorId { get; set; }
        public string WebhookSecret { get; set; }
        public int TimeoutSeconds { get; set; } = 30;

        public RetryOptions RetryOptions { get; set; } = new RetryOptions();
        public string BaseUrl { get; set; } = "https://vendors.paddle.com/api/2.0";
        public CompressionOptions CompressionOptions { get; set; } = new CompressionOptions();
    }

    public class RetryOptions
    {
        public int MaxRetries { get; set; } = 3;
        public int CircuitBreakerThreshold { get; set; } = 5;
        public bool EnableCircuitBreaker { get; set; } = true;
        public int CircuitBreakerDurationSeconds { get; set; } = 30;
    }

    public class CompressionOptions
    {
        /// <summary>
        /// İsteklerde sıkıştırma kullanılıp kullanılmayacağı.
        /// </summary>
        public bool EnableRequestCompression { get; set; } = true;

        /// <summary>
        /// Yanıtlarda sıkıştırma kullanılıp kullanılmayacağı.
        /// </summary>
        public bool EnableResponseCompression { get; set; } = true;

        /// <summary>
        /// Sıkıştırma için minimum boyut (bytes).
        /// Bu boyutun altındaki içerikler sıkıştırılmaz.
        /// </summary>
        public int MinimumSizeToCompress { get; set; } = 1024; // 1KB

        /// <summary>
        /// Desteklenen sıkıştırma yöntemleri.
        /// </summary>
        public string[] SupportedEncodings { get; set; } = new[] { "gzip", "deflate" };
    }
}