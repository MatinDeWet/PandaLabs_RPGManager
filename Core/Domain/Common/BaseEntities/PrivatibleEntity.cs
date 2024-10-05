namespace Domain.Common.BaseEntities
{
    public abstract class PrivatibleEntity<TKey> : Entity<TKey>
    {
        public bool IsPrivate { get; set; } = true;
    }
}
