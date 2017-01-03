using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Role : EntityBase
    {
        public Role()
        {
            CreatedOn = DateTime.Now;
        }
        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } 

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
