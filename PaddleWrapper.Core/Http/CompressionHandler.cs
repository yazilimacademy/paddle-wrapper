using Microsoft.Extensions.Options;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;
using System.IO.Compression;

namespace PaddleWrapper.Core.Http
{
    /// <summary>
    /// HTTP isteklerinde GZIP sıkıştırma desteği sağlayan handler.
    /// </summary>
    public class CompressionHandler : DelegatingHandler
    {
        private readonly IPaddleLogger _logger;
        private readonly CompressionOptions _options;

        public CompressionHandler(IPaddleLogger logger, IOptions<PaddleOptions> options)
        {
            _logger = logger;
            _options = options.Value.CompressionOptions;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Content != null && _options.EnableRequestCompression)
            {
                long contentLength = await GetContentLength(request.Content);
                if (contentLength >= _options.MinimumSizeToCompress)
                {
                    await CompressRequestContentAsync(request);
                }
            }

            if (_options.EnableResponseCompression && !request.Headers.Contains("Accept-Encoding"))
            {
                request.Headers.Add("Accept-Encoding", _options.SupportedEncodings);
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (response.Content != null && _options.EnableResponseCompression)
            {
                long contentLength = await GetContentLength(response.Content);
                if (contentLength >= _options.MinimumSizeToCompress)
                {
                    await DecompressResponseContentAsync(response);
                }
            }

            return response;
        }

        private async Task<long> GetContentLength(HttpContent content)
        {
            try
            {
                byte[] data = await content.ReadAsByteArrayAsync();
                return data.Length;
            }
            catch
            {
                return 0;
            }
        }

        private async Task CompressRequestContentAsync(HttpRequestMessage request)
        {
            try
            {
                HttpContent originalContent = request.Content;
                byte[] originalData = await originalContent.ReadAsByteArrayAsync();

                using MemoryStream compressedStream = new();
                using (GZipStream gzipStream = new(compressedStream, CompressionMode.Compress))
                {
                    await gzipStream.WriteAsync(originalData, 0, originalData.Length);
                }

                byte[] compressedData = compressedStream.ToArray();
                ByteArrayContent compressedContent = new(compressedData);

                foreach (KeyValuePair<string, IEnumerable<string>> header in originalContent.Headers)
                {
                    compressedContent.Headers.Add(header.Key, header.Value);
                }

                compressedContent.Headers.ContentEncoding.Add("gzip");
                request.Content = compressedContent;

                double compressionRatio = (1 - ((double)compressedData.Length / originalData.Length)) * 100;
                _logger.LogDebug($"Request compressed: {originalData.Length} -> {compressedData.Length} bytes ({compressionRatio:F1}% reduction)");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error compressing request content", ex);
            }
        }

        private async Task DecompressResponseContentAsync(HttpResponseMessage response)
        {
            HttpContent content = response.Content;
            string encoding = content.Headers.ContentEncoding.FirstOrDefault();

            if (string.IsNullOrEmpty(encoding) || !_options.SupportedEncodings.Contains(encoding.ToLower()))
            {
                return;
            }

            try
            {
                byte[] compressedData = await content.ReadAsByteArrayAsync();
                using MemoryStream decompressedStream = new();

                using (MemoryStream compressedStream = new(compressedData))
                {
                    using Stream decompressionStream = encoding.ToLower() switch
                    {
                        "gzip" => new GZipStream(compressedStream, CompressionMode.Decompress),
                        "deflate" => new DeflateStream(compressedStream, CompressionMode.Decompress),
                        _ => throw new NotSupportedException($"Unsupported encoding: {encoding}")
                    };

                    await decompressionStream.CopyToAsync(decompressedStream);
                }

                byte[] decompressedData = decompressedStream.ToArray();
                ByteArrayContent decompressedContent = new(decompressedData);

                foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
                {
                    if (header.Key != "Content-Encoding")
                    {
                        decompressedContent.Headers.Add(header.Key, header.Value);
                    }
                }

                response.Content = decompressedContent;

                double decompressionRatio = (((double)decompressedData.Length / compressedData.Length) - 1) * 100;
                _logger.LogDebug($"Response decompressed: {compressedData.Length} -> {decompressedData.Length} bytes ({decompressionRatio:F1}% expansion)");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error decompressing response content with encoding {encoding}", ex);
            }
        }
    }
}