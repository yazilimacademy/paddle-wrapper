using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Interfaces;

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
                var contentLength = await GetContentLength(request.Content);
                if (contentLength >= _options.MinimumSizeToCompress)
                {
                    await CompressRequestContentAsync(request);
                }
            }

            if (_options.EnableResponseCompression && !request.Headers.Contains("Accept-Encoding"))
            {
                request.Headers.Add("Accept-Encoding", _options.SupportedEncodings);
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.Content != null && _options.EnableResponseCompression)
            {
                var contentLength = await GetContentLength(response.Content);
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
                var data = await content.ReadAsByteArrayAsync();
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
                var originalContent = request.Content;
                var originalData = await originalContent.ReadAsByteArrayAsync();

                using var compressedStream = new MemoryStream();
                using (var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    await gzipStream.WriteAsync(originalData, 0, originalData.Length);
                }

                var compressedData = compressedStream.ToArray();
                var compressedContent = new ByteArrayContent(compressedData);

                foreach (var header in originalContent.Headers)
                {
                    compressedContent.Headers.Add(header.Key, header.Value);
                }

                compressedContent.Headers.ContentEncoding.Add("gzip");
                request.Content = compressedContent;

                var compressionRatio = (1 - ((double)compressedData.Length / originalData.Length)) * 100;
                _logger.LogDebug($"Request compressed: {originalData.Length} -> {compressedData.Length} bytes ({compressionRatio:F1}% reduction)");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error compressing request content", ex);
            }
        }

        private async Task DecompressResponseContentAsync(HttpResponseMessage response)
        {
            var content = response.Content;
            var encoding = content.Headers.ContentEncoding.FirstOrDefault();

            if (string.IsNullOrEmpty(encoding) || !_options.SupportedEncodings.Contains(encoding.ToLower()))
            {
                return;
            }

            try
            {
                var compressedData = await content.ReadAsByteArrayAsync();
                using var decompressedStream = new MemoryStream();

                using (var compressedStream = new MemoryStream(compressedData))
                {
                    using Stream decompressionStream = encoding.ToLower() switch
                    {
                        "gzip" => new GZipStream(compressedStream, CompressionMode.Decompress),
                        "deflate" => new DeflateStream(compressedStream, CompressionMode.Decompress),
                        _ => throw new NotSupportedException($"Unsupported encoding: {encoding}")
                    };

                    await decompressionStream.CopyToAsync(decompressedStream);
                }

                var decompressedData = decompressedStream.ToArray();
                var decompressedContent = new ByteArrayContent(decompressedData);

                foreach (var header in content.Headers)
                {
                    if (header.Key != "Content-Encoding")
                    {
                        decompressedContent.Headers.Add(header.Key, header.Value);
                    }
                }

                response.Content = decompressedContent;

                var decompressionRatio = (((double)decompressedData.Length / compressedData.Length) - 1) * 100;
                _logger.LogDebug($"Response decompressed: {compressedData.Length} -> {decompressedData.Length} bytes ({decompressionRatio:F1}% expansion)");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error decompressing response content with encoding {encoding}", ex);
            }
        }
    }
} 