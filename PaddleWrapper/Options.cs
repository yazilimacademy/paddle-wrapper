namespace PaddleWrapper;

public sealed class Options
{
    public string ApiKey { get; }
    public Environment Environment { get; }

    public Options(string apiKey = null, Environment environment = Environment.Production)
    {
        ApiKey = apiKey;
        Environment = environment;
    }
}