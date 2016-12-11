using Sammo.Blog.Application.Account.Dto;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sammo.Blog.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class AccountController : AdminBaseController
    {
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterInput input)
        {
            await CheckModelState();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginInput input)
        {
            await CheckModelState();

            return View();
        }
    }
}