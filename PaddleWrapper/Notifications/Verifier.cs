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
        if (!request.Headers.TryGetValue(PaddleSignature.HEADER, out IList<string>? signatureData) || !signatureData.Any())
        {
            return false;
        }

        PaddleSignature signature = PaddleSignature.Parse(signatureData.First());

        if (_maximumVariance > 0 && DateTimeOffset.UtcNow.ToUnixTimeSeconds() > signature.Timestamp + _maximumVariance)
        {
            return false;
        }

        request.Body.Position = 0;
        using StreamReader reader = new(request.Body);
        string body = await reader.ReadToEndAsync();

        return signature.Verify(body, secrets);
    }

    public bool Verify(IHttpRequest request, params Secret[] secrets)
    {
        return VerifyAsync(request, secrets).GetAwaiter().GetResult();
    }
}