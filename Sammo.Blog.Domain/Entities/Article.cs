using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Article : EntityBase
    {
        public Article()
        {
            CreatedOn = DateTime.Now;
            PageViews = 1;
            IsTop = false;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public int PageViews { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual Category Category { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
