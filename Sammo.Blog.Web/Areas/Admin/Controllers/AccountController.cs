using System.Web.Mvc;

namespace Sammo.Blog.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class AccountController : AdminBaseController
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
    }
}