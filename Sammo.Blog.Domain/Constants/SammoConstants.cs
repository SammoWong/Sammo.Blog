namespace Sammo.Blog.Domain.Constants
{
    public sealed class SammoConstants
    {
        public static class Validation
        {
            public const int ArticleTitleMinLength = 5;
            public const int ArticleTitleMaxLength = 30;
            public const int ArticleContentMinLength = 50;
            public const int BlogNameMinLength = 5;
            public const int BlogNameMaxLength = 30;
            public const int BlogDescriptionMaxLength = 140;
            public const int CategoryNameMinLength = 2;
            public const int CategoryNameMaxLength = 10;
            public const int CagegoryDescriptionMaxLength = 30;
            public const int RoleNameMinLength = 2;
            public const int RoleNameMaxLength = 10;
            public const int RoleDescriptionMaxLength = 30;
            public const int TagNameMinLength = 2;
            public const int TagNameMaxLength = 10;
            public const int TagDescriptionMaxLength = 30;
            public const int UserNameOrNickNameMinLength = 2;
            public const int UserNameOrNickNameMaxLength = 10;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 16;
            public const int EmailMaxLength = 30;
        }
    }
}
