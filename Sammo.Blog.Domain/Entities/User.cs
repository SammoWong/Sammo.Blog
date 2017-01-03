using System;
using System.Collections.Generic;

namespace Sammo.Blog.Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            IsComfirmed = false;
            IsLocked = false;
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }
        public string UserName { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Email { get; set; }

        public short Gender { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsComfirmed { get; set; }

        public bool IsLocked { get; set; } 

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string LastLoginIp { get; set; }

        public virtual Role Role { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
