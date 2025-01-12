namespace PaddleWrapper;

public sealed class Undefined
{
    private Undefined() { }

    public static Undefined Instance { get; } = new();
}