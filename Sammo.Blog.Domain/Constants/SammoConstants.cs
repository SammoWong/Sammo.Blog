namespace Sammo.Blog.Domain.Constants
{
    public sealed class SammoConstants
    {
        public static class Validation
        {
            public const int SaltSize = 24;

            public const int ArticleTitleMinLength = 5;
            public const int ArticleTitleMaxLength = 30;
            public const int ArticleContentMinLength = 50;
            public const int BlogNameMinLength = 5;
            public const int BlogNameMaxLength = 30;
            public const int BlogDescriptionMaxLength = 140;
            public const int CategoryNameMinLength = 2;
            public const int CategoryNameMaxLength = 10;
            public const int CagegoryDescriptionMaxLength = 30;
            public const int RoleTypeMaxLength = 10;
            public const int RoleNameMinLength = 2;
            public const int RoleNameMaxLength = 10;
            public const int RoleDescriptionMaxLength = 30;
            public const int TagNameMinLength = 2;
            public const int TagNameMaxLength = 10;
            public const int TagDescriptionMaxLength = 30;
            public const int UserNameOrNickNameMinLength = 4;
            public const int UserNameOrNickNameMaxLength = 20;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 16;
            public const int EncryptedPasswordMaxLength = 64;
            public const int SaltMaxLength = 64;
            public const int EmailMaxLength = 30;
            public const int CommentMinLength = 5;
            public const int CommentMaxLength = 200;
            public const int UrlMaxLength = 250;
            public const int IpAddressMaxLength = 16;
        }

        public static class Error
        {
            public const string UserNameOrEmailFormatError = "用户名或邮箱必须为4-20个字符，支持中文、英文、数字";
            public const string PasswordFormatError = "密码必须为6~20个字符，字母+数字组合";
            public const string UserNameFormatError = "用户名必须为4-20个字符，支持中文、英文、数字";
            public const string NickNameFormatError = "昵称必须为4-20个字符，支持中文、英文、数字";
            public const string EmailFormatError = "邮箱格式不正确";
            public const string UserNameOrEmailNotFound = "用户名或邮箱不存在";
        }

        public static class RegularPattern
        {
            public const string Password = "((?=.*\\d)(?=.*[a-zA-Z]).{6,20})";
            public const string Email = "^[_a-zA-Z0-9-]+(\\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*(\\.[a-zA-Z]{2,4})$";

        }

        public static class Roles
        {
            public const string User = "User";
            public const string Admin = "Admin";
        }
    }
}
