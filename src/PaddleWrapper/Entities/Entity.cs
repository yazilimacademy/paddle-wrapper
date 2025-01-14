namespace PaddleWrapper.Entities
{
    public interface IEntity
    {
        static abstract IEntity From(dynamic data);
    }
}