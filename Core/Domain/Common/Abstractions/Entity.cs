using Domain.Entities;

namespace Domain.Common.Abstractions
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; } = default!;

        public int CreatedById { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; } = null!;

        public DateTime DateTimeCreated { get; set; }
    }
}
