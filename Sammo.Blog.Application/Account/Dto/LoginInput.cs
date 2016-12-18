using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sammo.Blog.Application.Account.Dto
{
    public class LoginInput
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "用户名或邮箱")]
        public string UserNameOrEmail { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "记住我？")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
