namespace PaddleWrapper.Entities
{
    public abstract class Entity : IEntity
    {
        public string Id { get; protected set; }
    }
} 