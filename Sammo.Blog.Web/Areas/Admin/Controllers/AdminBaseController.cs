using Sammo.Blog.Web.Common.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sammo.Blog.Web.Areas.Admin.Controllers
{

    public class AdminBaseController : Controller
    {
        protected bool UserIsAuthenticated
        {
            get
            {
                return System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        protected virtual async Task CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                var msg = await Task.Run(() => ModelState.AllModelStateErrors().FirstOrDefault());
                throw new Exception(msg.Message);
            }
        }
    }
}