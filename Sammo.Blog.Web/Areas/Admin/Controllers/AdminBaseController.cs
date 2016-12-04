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

        
    }
}