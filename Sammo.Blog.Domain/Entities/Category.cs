using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Category
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastEditTime { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
