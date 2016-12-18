using Sammo.Blog.Application.Account;
using Sammo.Blog.Application.Account.Dto;
using Sammo.Blog.Domain.Enums;
using Sammo.Blog.Web.Common.Results;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Sammo.Blog.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class AccountController : AdminBaseController
    {
        private AccountAppService _service;
        public AccountController()
        {
            _service = IoCConfig.Get<AccountAppService>();
        }
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
        public async Task<ActionResult> RegisterAsync(RegisterInput input)
        {
            await CheckModelStateAsync();
            var result = await _service.RegisterAsync(input);
            switch (result)
            {
                case RegisterResult.Success:
                    FormsAuthentication.SetAuthCookie(input.UserName, true);
                    return new Json(true, "注册成功", null);
                case RegisterResult.UserNameExists:
                    break;
                case RegisterResult.EmailExists:
                    break;
                default:
                    break;
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginInput input)
        {
            await CheckModelStateAsync();

            return View();
        }
    }
}