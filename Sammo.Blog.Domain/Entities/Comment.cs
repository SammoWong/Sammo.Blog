using System;

namespace Sammo.Blog.Domain.Entities
{
    public class Comment : EntityBase
    {
        public string Content { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public virtual User Author { get; set; }

        public virtual Article Article { get; set; }
    }
}
