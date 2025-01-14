namespace PaddleWrapper;

public sealed class Options
{
    public Environment Environment { get; }

    public Options(Environment environment = Environment.Production)
    {
        Environment = environment;
    }
}