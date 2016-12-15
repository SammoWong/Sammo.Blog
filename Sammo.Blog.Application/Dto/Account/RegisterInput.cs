using Sammo.Blog.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace Sammo.Blog.Application.Dto.Account
{
    public class RegisterInput
    {
        [StringLength(SammoConstants.Validation.UserNameOrNickNameMaxLength, MinimumLength = SammoConstants.Validation.UserNameOrNickNameMinLength
            , ErrorMessage = SammoConstants.Error.UserNameFormatError)]
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "邮箱")]
        [RegularExpression(SammoConstants.RegularPattern.Email, ErrorMessage = SammoConstants.Error.EmailFormatError)]
        public string Email { get; set; }

        [StringLength(SammoConstants.Validation.UserNameOrNickNameMaxLength, MinimumLength = SammoConstants.Validation.UserNameOrNickNameMinLength
            , ErrorMessage = SammoConstants.Error.NickNameFormatError)]
        [Display(Name = "昵称")]
        public string NickName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "密码")]
        [RegularExpression(SammoConstants.RegularPattern.Password, ErrorMessage = SammoConstants.Error.PasswordFormatError)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配")]
        public string ConfirmPassword { get; set; }
    }
}
