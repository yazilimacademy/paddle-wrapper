namespace PaddleWrapper;

public enum Environment
{
    Sandbox,
    Production
}

public static class EnvironmentExtensions
{
    public static string GetBaseUrl(this Environment environment)
    {
        return environment switch
        {
            Environment.Production => "https://api.paddle.com",
            Environment.Sandbox => "https://sandbox-api.paddle.com",
            _ => throw new ArgumentOutOfRangeException(nameof(environment))
        };
    }
}