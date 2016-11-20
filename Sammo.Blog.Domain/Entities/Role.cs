using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class Role : EntityBase
    {
        public short Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime LastEditTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
