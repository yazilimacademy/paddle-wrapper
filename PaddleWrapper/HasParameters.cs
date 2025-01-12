namespace PaddleWrapper;

public interface IHasParameters
{
    IDictionary<string, object> GetParameters();
}

public abstract class HasParameters : IHasParameters
{
    protected readonly IDictionary<string, object> Parameters;

    protected HasParameters()
    {
        Parameters = new Dictionary<string, object>();
    }

    public IDictionary<string, object> GetParameters()
    {
        return Parameters;
    }
}