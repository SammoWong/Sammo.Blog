using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sammo.Blog.Web.Common
{
    public class UserContext
    {
        public static User Current
        {
            get
            {
                var userData = HttpContext.Current.User.Identity.Name.Split('|');
                return HttpContext.Current.User.Identity.IsAuthenticated
                    ? new User { Id = userData[0], UserName = userData[1], NickName = userData[2], Role = userData[3] }
                    : null;
            }
        }

    }
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public string Role { get; set; }
    }
}