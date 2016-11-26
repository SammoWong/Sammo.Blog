using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Article : EntityBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public int PageViews { get; set; } = 1;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime LastEditTime { get; set; }

        public virtual Category Category { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
