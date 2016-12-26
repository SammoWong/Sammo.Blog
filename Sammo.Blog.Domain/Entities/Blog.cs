using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Blog : EntityBase
    {
        public Blog()
        {
            Visits = 1;
            PageViews = 1;
            CreatedOn = DateTime.Now;
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int Visits { get; set; }

        public int PageViews { get; set; }

        public bool IsEnabled { get; set; } = false;

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
