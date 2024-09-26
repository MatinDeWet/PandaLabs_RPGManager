namespace Domain.Common.Abstractions
{
    public interface IEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }

    public interface IEntity
    {
        public int CreatedById { get; set; }

        public DateTime DateTimeCreated { get; set; }
    }
}
