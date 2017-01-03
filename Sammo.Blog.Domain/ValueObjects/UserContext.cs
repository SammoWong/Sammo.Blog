using System;

namespace Sammo.Blog.Domain.ValueObjects
{
    public class UserContext
    {
        public static User Current { get; set; }

        public void Set(Guid id, string userName, string nickName, string role)
        {
            
        }

        public class User
        {
            public Guid Id { get; set; }

            public string UserName { get; set; }

            public string NickName { get; set; }

            public string Role { get; set; }
        }
    }
}
