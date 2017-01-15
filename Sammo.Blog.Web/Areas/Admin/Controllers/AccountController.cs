using Sammo.Blog.Application.Account;
using Sammo.Blog.Application.Account.Dto;
using Sammo.Blog.Domain.Enums;
using Sammo.Blog.Web.Common.Results;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sammo.Blog.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class AccountController : AdminBaseController
    {
        private readonly AccountAppService _service;
        public AccountController()
        {
            _service = IoCConfig.Get<AccountAppService>();
        }

        [AllowAnonymous]
        [Route("Account/Register")]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("Account/Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost,AllowAnonymous]
        [Route("Account/Register")]
        public async Task<ActionResult> RegisterAsync(RegisterInput input)
        {
            await CheckModelStateAsync();
            var result = await _service.RegisterAsync(input);
            var user = result.Item2;
            switch (result.Item1)
            {
                case RegisterResult.Success:
                    //FormsAuthentication.SetAuthCookie(input.UserName, true);
                    SetAuthCookie(user.Id, user.UserName, user.NickName, user.Role.Name, false);
                    return new Json(true, "注册成功", null);
                case RegisterResult.UserNameExists:
                    return new Json(false, "用户名已注册", null);
                case RegisterResult.EmailExists:
                    return new Json(false, "邮箱已注册", null);
                default:
                    return new Json(false, "注册失败", null);
            }
        }

        [HttpPost]
        [Route("Account/Login")]
        public async Task<ActionResult> Login(LoginInput input)
        {
            await CheckModelStateAsync();
            var result = await _service.LoginAsync(input.UserNameOrEmail, input.Password);
            var user = result.Item2;
            switch (result.Item1)
            {
                case LoginResult.UserNameOrEmailNotFound:
                case LoginResult.PasswordIncorrect:
                    return new Json(false, "登陆失败", null);
                case LoginResult.IsLocked:
                    return new Json(false, "账号被锁定", null);
                case LoginResult.Success:
                    SetAuthCookie(user.Id, user.UserName, user.NickName, user.Role.Name, input.RememberMe);
                    return new Json(true, "登陆成功", null);
                default:
                    return new Json(false, "登陆失败", null);
            }
        }

        [Route("Account/Confirm")]
        public async Task<JsonResult> ConfirmAsync(string userId)
        {
            var result = await _service.ConfirmAsync(userId);
            if (result)
                return new Json(true, "注册成功", null);

            return new Json(false, "注册失败", null);
        }

        private void SetAuthCookie(Guid id, string userName, string nickName, string role, bool rememberMe = false)
        {
            var timeout = rememberMe ? 10080 : 30;
            var userData = string.Join("|", id, userName, nickName, role);
            var ticket = new FormsAuthenticationTicket(userData, rememberMe, timeout);
            var encrypted = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
            {
                Expires = DateTime.Now.AddMinutes(timeout),
                HttpOnly = true
            };

            Response.Cookies.Add(cookie);
        }
    }
}