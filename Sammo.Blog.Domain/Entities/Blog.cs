using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Blog : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int Visits { get; set; } = 1;

        public int PageViews { get; set; } = 1;

        public bool IsEnabled { get; set; } = false;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime LastEditTime { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
