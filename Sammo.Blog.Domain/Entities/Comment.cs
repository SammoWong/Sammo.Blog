using System;

namespace Sammo.Blog.Domain.Entities
{
    public class Comment : EntityBase
    {
        public Comment()
        {
            CreatedOn = DateTime.Now;
        }
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual User Author { get; set; }

        public virtual Article Article { get; set; }
    }
}
