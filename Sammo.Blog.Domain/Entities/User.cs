using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Email { get; set; }

        public short Gender { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsComfirmed { get; set; } = false;

        public bool IsLocked { get; set; } = true;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime LastEditTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        public string LastLoginIp { get; set; }

        public virtual Role Role { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
