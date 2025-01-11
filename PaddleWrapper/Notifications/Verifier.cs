using PaddleWrapper.Http;

namespace PaddleWrapper.Notifications;

public sealed class Verifier
{
    private readonly int? _maximumVariance;

    public Verifier(int? maximumVariance = 5)
    {
        _maximumVariance = maximumVariance;
    }

    public async Task<bool> VerifyAsync(IHttpRequest request, params Secret[] secrets)
    {
        if (!request.Headers.TryGetValue(PaddleSignature.HEADER, out var signatureData) || !signatureData.Any())
        {
            return false;
        }

        var signature = PaddleSignature.Parse(signatureData.First());

        if (_maximumVariance > 0 && DateTimeOffset.UtcNow.ToUnixTimeSeconds() > signature.Timestamp + _maximumVariance)
        {
            return false;
        }

        request.Body.Position = 0;
        using var reader = new StreamReader(request.Body);
        var body = await reader.ReadToEndAsync();

        return signature.Verify(body, secrets);
    }

    public bool Verify(IHttpRequest request, params Secret[] secrets)
    {
        return VerifyAsync(request, secrets).GetAwaiter().GetResult();
    }
} 