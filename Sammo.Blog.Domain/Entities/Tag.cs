using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Tag:EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime LastEditTime { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Article>  Articles { get; set; }
    }
}
