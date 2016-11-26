using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sammo.Blog.Repository.EntityFramework.Mapping
{
    public class TagMapping : EntityTypeConfiguration<Tag>
    {
        public TagMapping()
        {
            ToTable("Tag");

            HasKey(t => t.Id);

            Property(t => t.Id).HasColumnName("Id").IsRequired();
            Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(SammoConstants.Validation.TagNameMaxLength);
            Property(t => t.Description).HasColumnName("Description").IsOptional().HasMaxLength(SammoConstants.Validation.TagDescriptionMaxLength);
            Property(t => t.CreatedTime).HasColumnName("CreatedTime").IsRequired();
            Property(t => t.LastEditTime).HasColumnName("LastEditTime").IsOptional();
        }
    }
}
