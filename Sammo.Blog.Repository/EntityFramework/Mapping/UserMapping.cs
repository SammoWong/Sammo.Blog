using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sammo.Blog.Repository.EntityFramework.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");

            HasKey(u => u.Id);

            Property(u => u.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(SammoConstants.Validation.UserNameOrNickNameMaxLength);
            Property(u => u.NickName).HasColumnName("NickName").IsOptional().HasMaxLength(SammoConstants.Validation.UserNameOrNickNameMaxLength);
            Property(u => u.Password).HasColumnName("Password").IsRequired();
            Property(u => u.Email).HasColumnName("Email").IsRequired().HasMaxLength(SammoConstants.Validation.EmailMaxLength);
            Property(u => u.Gender).HasColumnName("Gender").IsOptional();
            Property(u => u.AvatarUrl).HasColumnName("AvatarUrl").IsOptional();
            Property(u => u.IsComfirmed).HasColumnName("IsComfirmed").IsRequired();
            Property(u => u.IsLocked).HasColumnName("IsLocked").IsRequired();
            Property(u => u.CreatedTime).HasColumnName("CreatedTime").IsRequired();
            Property(u => u.LastEditTime).HasColumnName("LastEditTime").IsOptional();
            Property(u => u.LastLoginTime).HasColumnName("LastEditTime").IsOptional();
            Property(u => u.LastLoginIp).HasColumnName("LastEditTime").IsOptional();

            HasOptional(u => u.Blog).WithRequired(u => u.Author).Map(u=>u.MapKey("UserId"));
        }
    }
}
