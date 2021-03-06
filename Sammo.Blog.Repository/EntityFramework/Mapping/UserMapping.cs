﻿using Sammo.Blog.Domain.Constants;
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

            Property(u => u.Id).HasColumnName("Id").IsRequired();
            Property(u => u.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(SammoConstants.Validation.UserNameOrNickNameMaxLength);
            Property(u => u.NickName).HasColumnName("NickName").IsOptional().HasMaxLength(SammoConstants.Validation.UserNameOrNickNameMaxLength);
            Property(u => u.Password).HasColumnName("Password").IsRequired().HasMaxLength(SammoConstants.Validation.EncryptedPasswordMaxLength);
            Property(u => u.Salt).HasColumnName("Salt").IsRequired().HasMaxLength(SammoConstants.Validation.SaltMaxLength);
            Property(u => u.Email).HasColumnName("Email").IsRequired().HasMaxLength(SammoConstants.Validation.EmailMaxLength);
            Property(u => u.Gender).HasColumnName("Gender").IsOptional();
            Property(u => u.AvatarUrl).HasColumnName("AvatarUrl").IsOptional().HasMaxLength(SammoConstants.Validation.UrlMaxLength);
            Property(u => u.IsComfirmed).HasColumnName("IsComfirmed").IsRequired();
            Property(u => u.IsLocked).HasColumnName("IsLocked").IsRequired();
            Property(u => u.CreatedOn).HasColumnName("CreatedOn").IsRequired();
            Property(u => u.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();
            Property(u => u.LastLoginTime).HasColumnName("LastLoginTime").IsOptional();
            Property(u => u.LastLoginIp).HasColumnName("LastLoginIp").IsOptional().HasMaxLength(SammoConstants.Validation.IpAddressMaxLength);

            HasOptional(u => u.Blog).WithRequired(u => u.Author).Map(u => u.MapKey("UserId")).WillCascadeOnDelete(false);
            HasMany(u => u.Comments).WithRequired(u => u.Author).Map(u => u.MapKey("UserId")).WillCascadeOnDelete(false);
        }
    }
}
