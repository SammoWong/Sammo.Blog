using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Tag:EntityBase
    {
        public Tag()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Article>  Articles { get; set; }
    }
}
