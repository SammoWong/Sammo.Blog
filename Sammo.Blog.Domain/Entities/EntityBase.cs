using System;

namespace Sammo.Blog.Domain.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
