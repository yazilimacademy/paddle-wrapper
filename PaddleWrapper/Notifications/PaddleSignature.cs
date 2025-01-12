using System.Security.Cryptography;
using System.Text;

namespace PaddleWrapper.Notifications;

public sealed class PaddleSignature
{
    public const string TIMESTAMP = "ts";
    public const string HASH_ALGORITHM_1 = "h1";
    public const string HEADER = "Paddle-Signature";

    private readonly Dictionary<string, List<string>> _hashes;
    public int Timestamp { get; }

    private PaddleSignature(int timestamp, Dictionary<string, List<string>> hashes)
    {
        _hashes = hashes;
        Timestamp = timestamp;
    }

    /// <summary>
    /// Verifies the signature against the provided data and secrets.
    /// See: https://developer.paddle.com/webhooks/signature-verification
    /// </summary>
    public bool Verify(string data, params Secret[] secrets)
    {
        foreach (Secret secret in secrets)
        {
            foreach ((string hashAlgorithm, List<string> possibleHashes) in _hashes)
            {
                string hash = hashAlgorithm switch
                {
                    HASH_ALGORITHM_1 => CalculateHMAC($"{Timestamp}:{data}", secret.Key),
                    _ => throw new InvalidOperationException($"Unknown hash algorithm {hashAlgorithm}")
                };

                foreach (string possibleHash in possibleHashes)
                {
                    if (CryptographicOperations.FixedTimeEquals(
                        Convert.FromHexString(hash),
                        Convert.FromHexString(possibleHash)))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public static string CalculateHMAC(string data, string key)
    {
        using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(key));
        byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
        return Convert.ToHexString(hash).ToLower();
    }

    public static PaddleSignature Parse(string header)
    {
        Dictionary<string, object> components = new()
        {
            [TIMESTAMP] = 0,
            ["hashes"] = new Dictionary<string, List<string>>()
        };

        string[] parts = header.Split(';', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            if (part.Contains('='))
            {
                string[] keyValue = part.Split('=', 2);
                string key = keyValue[0];
                string value = keyValue[1];

                switch (key)
                {
                    case TIMESTAMP:
                        components[TIMESTAMP] = int.Parse(value);
                        break;
                    case HASH_ALGORITHM_1:
                        Dictionary<string, List<string>> hashes = (Dictionary<string, List<string>>)components["hashes"];
                        if (!hashes.ContainsKey(HASH_ALGORITHM_1))
                        {
                            hashes[HASH_ALGORITHM_1] = new List<string>();
                        }
                        hashes[HASH_ALGORITHM_1].Add(value);
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown key {key}");
                }
            }
        }

        return new PaddleSignature(
            (int)components[TIMESTAMP],
            (Dictionary<string, List<string>>)components["hashes"]
        );
    }
}