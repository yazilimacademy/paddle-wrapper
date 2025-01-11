using Microsoft.AspNetCore.Http;

namespace PaddleWrapper.Notifications;

public sealed class Verifier
{
    private readonly int? _maximumVariance;

    public Verifier(int? maximumVariance = 5)
    {
        _maximumVariance = maximumVariance;
    }

    public bool Verify(HttpRequest request, params Secret[] secrets)
    {
        if (!request.Headers.TryGetValue(PaddleSignature.HEADER, out var signatureData) || signatureData.Count == 0)
        {
            return false;
        }

        var signature = PaddleSignature.Parse(signatureData[0]!);

        if (_maximumVariance > 0 && DateTimeOffset.UtcNow.ToUnixTimeSeconds() > signature.Timestamp + _maximumVariance)
        {
            return false;
        }

        request.Body.Position = 0;
        using var reader = new StreamReader(request.Body);
        var body = reader.ReadToEndAsync().Result;

        return signature.Verify(body, secrets);
    }
} 