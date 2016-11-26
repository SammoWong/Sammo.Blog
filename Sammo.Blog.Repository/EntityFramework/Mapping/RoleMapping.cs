using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sammo.Blog.Repository.EntityFramework.Mapping
{
    public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            ToTable("Role");

            HasKey(r => r.Id);
            HasKey(r => r.Type);

            Property(r => r.Id).HasColumnName("Id").IsRequired();
            Property(r => r.Type).HasColumnName("Type").IsRequired();
            Property(r => r.Name).HasColumnName("Name").IsRequired().HasMaxLength(SammoConstants.Validation.RoleNameMaxLength);
            Property(r => r.Description).HasColumnName("Description").IsOptional().HasMaxLength(SammoConstants.Validation.RoleDescriptionMaxLength);
            Property(r => r.CreatedTime).HasColumnName("CreatedTime").IsRequired();
            Property(r => r.LastEditTime).HasColumnName("LastEditTime").IsOptional();

            HasMany(r => r.Users).WithRequired(r => r.Role).Map(r => r.MapKey("RoleType")).WillCascadeOnDelete(false);
        }
    }
}
